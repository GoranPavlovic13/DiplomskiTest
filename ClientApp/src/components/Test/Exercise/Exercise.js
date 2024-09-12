import React from 'react';
import classes from './Exercise.module.css';
import Answer from '../Answer/Answer';
import Card from '../../UI/Card';

const Exercise = (props) => {

  const handleSelectAnswer = (answerId, isSelected) => {
    props.onSelectAnswer(answerId, isSelected);
  };

  return (
    <div className={classes.exercise}>
      <h3 className={classes.description}>{props.description}</h3>
      <Card>
        <pre className={classes.code}>{props.content}</pre>
      </Card>
      <p className={classes.answerText}>Answers:</p>
        <ul className={classes.answers}>
          {props.answers.map((answer) => (
            <li key={answer.answerId}>
              <Answer 
              key = {answer.answerId}
              id = {answer.answerId}
              content={answer.content}
              onSelectAnswer={handleSelectAnswer} />
            </li>
          ))}
        </ul>
      
    </div>
  );
};

export default Exercise;