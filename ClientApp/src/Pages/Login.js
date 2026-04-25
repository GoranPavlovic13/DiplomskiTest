import { Fragment } from "react";
import LoginForm from "../components/Auth/Login/LoginForm"
import LoginFormSummary from '../components/Auth/Login/LoginFormSummary'


const Login = () => {
    return <Fragment>
        <LoginFormSummary></LoginFormSummary>
        <LoginForm></LoginForm>
    </Fragment>
};

export default Login;