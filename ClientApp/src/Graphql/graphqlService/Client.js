import { ApolloClient, InMemoryCache, HttpLink, ApolloLink } from "@apollo/client";
import { onError } from "@apollo/client/link/error";
import { setContext } from "@apollo/client/link/context";

const httpLink = new HttpLink({ uri: 'https://localhost:5001/graphql' });

const authLink = setContext((_, { headers }) => {
  const token = localStorage.getItem("token");

  return {
    headers: {
      ...headers,
      authorization: token ? `Bearer ${token}` : ""
    }
  };
});

// Funkcija za maskiranje osetljivih polja
const maskSensitiveData = (variables) => {
  const masked = { ...variables };
  const sensitiveKeys = ['password', 'token', 'accessToken'];

  for (const key of sensitiveKeys) {
    if (masked[key]) {
      masked[key] = "***"; // maskira vrednost
    }
  }

  return masked;
};

const loggerLink = new ApolloLink((operation, forward) => {
  console.log(`Starting request for ${operation.operationName}`);

  // Maskiramo osetljive podatke
  const safeVariables = maskSensitiveData(operation.variables);

  console.log('Query:', operation.query);
  console.log('Variables:', safeVariables);

  return forward(operation).map(result => {
    console.log(`Ending request for ${operation.operationName}`);
    return result;
  });
});

const errorLink = onError(({ graphQLErrors, networkError }) => {
  if (graphQLErrors) {
    graphQLErrors.forEach(({ message, locations, path }) =>
      console.log(`[GraphQL error]: Message: ${message}, Location: ${locations}, Path: ${path}`)
    );
  }

  if (networkError) {
    console.log(`[Network error]: ${networkError}`);
  }
});

// Sastavljamo linkove: logger samo u development
const link = process.env.NODE_ENV === 'development'
  ? ApolloLink.from([loggerLink, errorLink, authLink, httpLink])
  : ApolloLink.from([errorLink, authLink, httpLink]);

const Client = new ApolloClient({
  link,
  cache: new InMemoryCache()
});

export default Client;
