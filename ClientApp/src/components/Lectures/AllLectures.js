import { useQuery } from "@apollo/client";
import { GET_LECTURES } from "../../Graphql/Queries/query";
import SingleLecture from "./Lecture/SingleLecture";
import classes from "./AllLectures.module.css";
import Card from "../UI/Card";
import React, { useState } from "react";
import AddLecture from "./AddLecture"
import AddLectureSummary from  "./Lecture/AddLectureSummary";

const AllLectures = () => {
  const { loading, error, data } = useQuery(GET_LECTURES);
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

  const lecturesList = data.lecture.edges.map((lecture) => (
    <SingleLecture
      key={lecture.node.lectureId}
      id={lecture.node.lectureId}
      name={lecture.node.lectureName}
      description={lecture.node.lectureDescription}
    ></SingleLecture>
  ));

  return (
    <>
      <AddLectureSummary></AddLectureSummary>
      {isFormVisible && <AddLecture onClose={toggleFormVisibility}/>}  
      <section className={classes.lectures}>
        <button className={classes.button} onClick={toggleFormVisibility}>
        {isFormVisible ? "^ Hide Form" : "+ Add Lecture"}
        </button>
        <Card>
          <ul>{lecturesList}</ul>
        </Card>
      </section>
    </>
  );
};

export default AllLectures;
