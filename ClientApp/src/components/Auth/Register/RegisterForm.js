import { useMutation } from "@apollo/client";
import { useNavigate, Link } from "react-router-dom";
import { REGISTER_MUTATION } from "../../../Graphql/Mutations/mutation";
import classes from "./RegisterForm.module.css";

const RegisterForm = () => {
  const navigate = useNavigate();
  const [registerUser, { loading, error }] = useMutation(REGISTER_MUTATION);

  const getErrorMessage = (error) => {
    if (!error) return null;
    const graphQLError = error.graphQLErrors?.[0];
    if (!graphQLError) return "Registration failed. Please try again.";

    return graphQLError.message || "Registration failed.";
  };

  const errorMessage = getErrorMessage(error);

  const handleSubmit = async (event) => {
    event.preventDefault();

    const form = event.target;

    try {
      const { data } = await registerUser({
        variables: {
          firstName: form.firstName.value,
          lastName: form.lastName.value,
          userName: form.userName.value,
          email: form.email.value,
          password: form.password.value,
        },
      });

      if (data?.registerUser?.success) {
        navigate("/login");
      }
    } catch {
      console.error("Registration failed");
    }
  };

  return (
    <div className={classes["form-container"]}>
      <form className={classes.form} onSubmit={handleSubmit}>
        <div className={classes["form-row"]}>
          <div className={classes["form-group"]}>
            <label htmlFor="firstName">First name</label>
            <input type="text" id="firstName" required />
          </div>

          <div className={classes["form-group"]}>
            <label htmlFor="lastName">Last name</label>
            <input type="text" id="lastName" required />
          </div>
        </div>

        <div className={classes["form-row"]}>
          <div className={classes["form-group"]}>
            <label htmlFor="userName">Username</label>
            <input type="text" id="userName" required />
          </div>

          <div className={classes["form-group"]}>
            <label htmlFor="email">Email</label>
            <input type="email" id="email" />
          </div>
        </div>

        <div className={classes["form-row"]}>
          <div className={classes["form-group"]}>
            <label htmlFor="password">Password</label>
            <input type="password" id="password" required />
          </div>
        </div>

        {errorMessage && <p className={classes.error}>{errorMessage}</p>}

        <div className={classes["form-actions"]}>
          <button type="submit" disabled={loading}>
            {loading ? "Registering..." : "Register"}
          </button>
        </div>

        <div className={classes["form-footer"]}>
          <p>
            Already have an account?
            <Link to="/login">Login</Link>
          </p>
        </div>
      </form>
    </div>
  );
};

export default RegisterForm;
