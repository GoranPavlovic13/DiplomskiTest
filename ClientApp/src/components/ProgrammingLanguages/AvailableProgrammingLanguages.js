import { useQuery } from "@apollo/client";
import { GET_PROGRAMMING_LANGUAGES } from "../../Graphql/Queries/query";
import ProgrammingLanguageItem from "./ProgrammingLanguageItem/ProgrammingLanguageItem";
import classes from "./AvailableProgrammingLanguages.module.css";
import Card from "../UI/Card";
import React, { useState } from "react";
import AddProgrammingLanguageForm from "./AddProgrammingLanguageForm";

const AvailableProgrammingLanguages = () => {
<<<<<<< HEAD
  const { loading, error, data } = useQuery(GET_PROGRAMMING_LANGUAGES);
=======
  const { loading, error, data, refetch } = useQuery(GET_PROGRAMMING_LANGUAGES);
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7
  const [isFormVisible, setFormVisible] = useState(false);

  const toggleFormVisibility = () => {
    setFormVisible((prevState) => !prevState);
  };

<<<<<<< HEAD
  //console.log(data);

=======
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7
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

<<<<<<< HEAD
  const languagesList = data.programmingLanguage.edges.map((language) => (
    <ProgrammingLanguageItem
      key={language.node.languageId}
      id={language.node.languageId}
      name={language.node.languageName}
      description={language.node.languageDescription}
      type={language.node.languageType}
=======
  const languagesList = data.programmingLanguage.map((language) => (
    <ProgrammingLanguageItem
      key={language.languageId}
      id={language.languageId}
      name={language.languageName}
      description={language.languageDescription}
      type={language.languageType}
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7
    ></ProgrammingLanguageItem>
  ));

  return (
    <>
<<<<<<< HEAD
      {isFormVisible && <AddProgrammingLanguageForm onClose={toggleFormVisibility}/>}  
=======
      {isFormVisible && <AddProgrammingLanguageForm onClose={toggleFormVisibility} refetchLanguages={refetch}/>}  
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7
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
