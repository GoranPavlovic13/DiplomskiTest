import classes from './LoginFormSummary.module.css'

const LoginFormSummary = () => {
    return (
        <section className={classes.summary}>
          <h2>Login</h2>
          <p>
            Please enter your credentials to access your account.
          </p>
        </section>
      );
};

export default LoginFormSummary;