import { useMutation } from "@apollo/client";
import { useNavigate, Link } from "react-router-dom";
import { LOGIN_MUTATION } from "../../../Graphql/Mutations/mutation";
import { useAuth } from "../../../context/AuthContext";
import classes from "./LoginForm.module.css";

const LoginForm = () => {
  const navigate = useNavigate();
  const { login: authLogin } = useAuth(); // AuthContext
  const [loginMutation, { loading, error }] = useMutation(LOGIN_MUTATION);

  // Kontrolisana poruka greške
  const getErrorMessage = (error) => {
    if (!error) return null;
    const graphQLError = error.graphQLErrors?.[0];
    if (!graphQLError) return "Login failed. Please try again.";

    switch (graphQLError.extensions?.code) {
      case "AUTH_NOT_AUTHORIZED":
        return "Invalid username or password.";
      case "AUTH_ACCOUNT_LOCKED":
        return "Your account is locked. Contact support.";
      case "AUTH_TOO_MANY_ATTEMPTS":
        return "Too many login attempts. Try again later.";
      default:
        return "Login failed. Please try again.";
    }
  };

  const errorMessage = getErrorMessage(error);

  const handleSubmit = async (event) => {
    event.preventDefault();
    const userName = event.target.userName.value;
    const password = event.target.password.value;

    try {
      const { data } = await loginMutation({ variables: { userName, password } });
      const token = data?.login?.token;

      if (token) {
        authLogin(token); // CENTRALIZOVANO
        navigate("/programming-languages"); // redirect nakon uspešnog login-a
      }
    } catch {
      console.error("Login failed");
    }
  };

  return (
    <div className={classes["form-container"]}>
      <form className={classes.form} onSubmit={handleSubmit}>
        <div className={classes["form-row"]}>
          <div className={classes["form-group"]}>
            <label htmlFor="userName">Username</label>
            <input type="text" id="userName" required />
          </div>

          <div className={classes["form-group"]}>
            <label htmlFor="password">Password</label>
            <input type="password" id="password" required />
          </div>
        </div>

        {errorMessage && <p className={classes.error}>{errorMessage}</p>}

        <div className={classes["form-actions"]}>
          <button type="submit" disabled={loading}>
            {loading ? "Logging in..." : "Login"}
          </button>
        </div>

        <div className={classes["form-footer"]}>
          <p>
            Don’t have an account? <Link to="/register">Register</Link>
          </p>
        </div>
      </form>
    </div>
  );
};

export default LoginForm;
