import React, { useState } from "react";
import { useMutation, useQuery } from "@apollo/client";
import { GET_TEST } from "../../Graphql/Queries/query";
import classes from "./Test.module.css";
import Exercise from "./Exercise/Exercise";
import { useParams } from "react-router-dom";
import TestSummary from "./TestSummary";
import { EVALUATE_TEST } from "../../Graphql/Mutations/mutation";
import TestResult from "./TestResult";

const Test = () => {
  const { testId } = useParams();
  const { loading, error, data } = useQuery(GET_TEST, {
    variables: { testId: testId },
  });

  const [selectedAnswers, setSelectedAnswers] = useState([]);

  const [evaluateTest, { data: evaluationData, error: evaluationError }] =
    useMutation(EVALUATE_TEST);

  const handleSelectAnswer = (answerId, isSelected) => {
    setSelectedAnswers((prevSelectedAnswers) => {
      if (isSelected) {
        return [...prevSelectedAnswers, answerId];
      } else {
        return prevSelectedAnswers.filter((id) => id !== answerId);
      }
    });
  };

  const handleFinishTest = async () => {
    try {
      const response = await evaluateTest({
        variables: {
          testId: testId,
          selectedAnswers: selectedAnswers,
        },
      });

      console.log("Evaluation result:", response.data.evaluateTest);
    } catch (err) {
      console.error("Error evaluating test:", err);
    }
  };

  if (loading) return <p className={classes.loading}>Loading...</p>;
  if (error) return <p className={classes.error}>Error: {error.message}</p>;

<<<<<<< HEAD
  const test = data.test.edges[0].node;
  console.log(test);
=======
  const test = data.test[0];
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7

  return (
    <>
      <TestSummary name={test.testName}></TestSummary>
      <div className={classes.test}>
        {test.exercises.map((exercise, index) => (
          <Exercise
            key={exercise.exerciseId}
            id={exercise.exerciseId}
            description={`${index + 1}. ${exercise.exerciseDescription}`}
            content={exercise.content}
            answers={exercise.answers}
            onSelectAnswer={handleSelectAnswer}
          />
        ))}
        <hr></hr>
        <button className={classes.button} onClick={handleFinishTest}>
          Finish Test
        </button>
        {evaluationError && (
          <p className={classes.error}>Error: {evaluationError.message}</p>
        )}

        {evaluationData && (
          <TestResult
            message={evaluationData.evaluateTest.message}
            score={evaluationData.evaluateTest.score}
          ></TestResult>
        )}
      </div>
    </>
  );
};

export default Test;
