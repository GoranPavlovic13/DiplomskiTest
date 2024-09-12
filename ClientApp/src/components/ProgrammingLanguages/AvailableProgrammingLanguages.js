import { useQuery } from "@apollo/client";
import { GET_PROGRAMMING_LANGUAGES } from "../../Graphql/Queries/query";
import ProgrammingLanguageItem from "./ProgrammingLanguageItem/ProgrammingLanguageItem";
import classes from "./AvailableProgrammingLanguages.module.css";
import Card from "../UI/Card";
import React, { useState } from "react";
import AddProgrammingLanguageForm from "./AddProgrammingLanguageForm";

const AvailableProgrammingLanguages = () => {
  const { loading, error, data, refetch } = useQuery(GET_PROGRAMMING_LANGUAGES);
  const [isFormVisible, setFormVisible] = useState(false);

  const toggleFormVisibility = () => {
    setFormVisible((prevState) => !prevState);
  };

  if (loading) {
    return (
      <div className={classes.loadingContainer}>
        <div className={classes.spinner}></div>
        <div className={classes.loadingText}>Loading</div>
      </div>
    );
  }

  if (error) {
    return (
      <section className={classes.errorContainer}>
        <p className={classes.errorText}>Error: {error.message}</p>
      </section>
    );
  }

  const languagesList = data.programmingLanguage.map((language) => (
    <ProgrammingLanguageItem
      key={language.languageId}
      id={language.languageId}
      name={language.languageName}
      description={language.languageDescription}
      type={language.languageType}
    ></ProgrammingLanguageItem>
  ));

  return (
    <>
      {isFormVisible && <AddProgrammingLanguageForm onClose={toggleFormVisibility} refetchLanguages={refetch}/>}  
      <section className={classes.languages}>
        <button className={classes.button} onClick={toggleFormVisibility}>
        {isFormVisible ? "^ Hide Form" : "+ Add New Language"}
        </button>
        <Card>
          <ul>{languagesList}</ul>
        </Card>
      </section>
    </>
  );
};

export default AvailableProgrammingLanguages;
