import { useQuery } from "@apollo/client";
import { GET_PROGRAMMING_LANGUAGES } from "../../Graphql/Queries/query";
import ProgrammingLanguageItem from "./ProgrammingLanguageItem/ProgrammingLanguageItem";
import classes from "./AvailableProgrammingLanguages.module.css";
import Card from "../UI/Card";
import React, { useState } from "react";
import AddProgrammingLanguageForm from "./AddProgrammingLanguageForm";

const AvailableProgrammingLanguages = () => {

  const { loading, error, data } = useQuery(GET_PROGRAMMING_LANGUAGES);

  const [isFormVisible, setFormVisible] = useState(false);

  const toggleFormVisibility = () => {
    setFormVisible((prevState) => !prevState);
  };

  //console.log(data);

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


  const languagesList = data.programmingLanguage.edges.map((language) => (
    <ProgrammingLanguageItem
      key={language.node.languageId}
      id={language.node.languageId}
      name={language.node.languageName}
      description={language.node.languageDescription}
      type={language.node.languageType}
    ></ProgrammingLanguageItem>
  ));

  return (
    <>

      {isFormVisible && <AddProgrammingLanguageForm onClose={toggleFormVisibility}/>}  
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
