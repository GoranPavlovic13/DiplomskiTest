import Modal from "../UI/Modal";
import classes from "./TestResult.module.css";
import { useNavigate } from "react-router-dom";

const TestResult = (props) => {
  const score = `${props.score}/4`;

  const navigate = useNavigate();

  const handleStartClick = () => {
    navigate(`/`);
  };

  return (
    <Modal>
      <div className={classes.result}>
        <span>{props.message}</span>
        <span>{score}</span>
      </div>
      <div className={classes.actions}>
        <button className={classes["button--alt"]} onClick={handleStartClick}>
          Go To Start
        </button>
      </div>
    </Modal>
  );
};

export default TestResult;
