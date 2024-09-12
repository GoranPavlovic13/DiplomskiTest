import classes from "./ProgrammingLanguageItem.module.css";
import { useNavigate } from "react-router-dom";

const ProgrammingLanguageItem = (props) => {

  const navigate = useNavigate();

  const handleLearnClick = () => {
    navigate(`/programming-languages/${props.id}/lectures`);
  }

  function humanize(str) {
    var i, frags = str.split('_');
    for (i=0; i<frags.length; i++) {
      frags[i] = frags[i].charAt(0).toUpperCase() + frags[i].slice(1);
    }
    return frags.join(' ');
  }

  return (
    <li className={classes.language}>
      <div>
        <h3>{props.name}</h3>
        <div className={classes.description}>{props.description}</div>
        <div className={classes.type}>{humanize(props.type)}</div>
      </div>
      <div className={classes.buttons}>
        <button className={classes.button} onClick={handleLearnClick}>
          Learn
        </button>
      </div>
    </li>
  );
};

export default ProgrammingLanguageItem;
