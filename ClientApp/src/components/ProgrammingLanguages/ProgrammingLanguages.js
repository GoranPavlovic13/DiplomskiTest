import { Fragment } from "react";
import ProgrammingLanguagesSummary from "./ProgrammingLanguagesSummary";
import AvailableProgrammingLanguages from "./AvailableProgrammingLanguages";

const ProgrammingLanguages = () => {
    return <Fragment>
        <ProgrammingLanguagesSummary></ProgrammingLanguagesSummary>
        <AvailableProgrammingLanguages></AvailableProgrammingLanguages>
    </Fragment>
};

export default ProgrammingLanguages;