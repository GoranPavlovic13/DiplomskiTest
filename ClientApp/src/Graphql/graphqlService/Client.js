import { ApolloClient, InMemoryCache, HttpLink, ApolloLink } from "@apollo/client";
import { onError } from "@apollo/client/link/error";

const httpLink = new HttpLink({ uri: 'https://localhost:5001/graphql' });

const loggerLink = new ApolloLink((operation, forward) => {
    console.log(`Starting request for ${operation.operationName}`);
    console.log('Query:', operation.query);
    console.log('Variables:', operation.variables);
  
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
  
  const Client = new ApolloClient({
    link: ApolloLink.from([loggerLink, errorLink, httpLink]),
    cache: new InMemoryCache()
  });

export default Client;