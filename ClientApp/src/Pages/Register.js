import { Fragment } from "react";
import RegisterForm from "../components/Auth/Register/RegisterForm";
import RegisterFormSummary from "../components/Auth/Register/RegisterFormSummary";


const Register = () => {
    return <Fragment>
        <RegisterFormSummary></RegisterFormSummary>
        <RegisterForm></RegisterForm>
    </Fragment>
};

export default Register;