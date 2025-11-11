import React, { useState } from "react";
import classes from "./Answer.module.css";


const Answer = (props) => {
  const [isActive, setIsActive] = useState(false);

  const handleClick = () => {
    const newState = !isActive;
    setIsActive(newState);
    props.onSelectAnswer(props.id, newState);
  };

  return (
    <div className={`${classes.answer} ${isActive ? classes.active : ""}`} onClick={handleClick}>
      {props.content}
    </div>
  );
};

export default Answer;
