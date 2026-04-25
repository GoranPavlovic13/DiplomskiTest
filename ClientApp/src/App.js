import { ApolloProvider } from "@apollo/client";
import "./App.css";
import Client from "./Graphql/graphqlService/Client";
import { BrowserRouter as Router} from "react-router-dom";
import { AuthProvider } from "./context/AuthContext";
import AppRoutes from "./AppRoutes";

function App() {
  return (
    <ApolloProvider client={Client}>
      <AuthProvider>
        <Router>
          <AppRoutes/>
        </Router>
      </AuthProvider>
    </ApolloProvider>
  );
}

export default App;
