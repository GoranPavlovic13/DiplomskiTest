import classes from "./ProgrammingLanguageItem.module.css";
import { useNavigate } from "react-router-dom";
<<<<<<< HEAD
import { useMutation } from "@apollo/client";
import { DELETE_LANGUAGE } from "../../../Graphql/Mutations/mutation";
import { GET_PROGRAMMING_LANGUAGES } from "../../../Graphql/Queries/query";
=======
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7

const ProgrammingLanguageItem = (props) => {

  const navigate = useNavigate();

<<<<<<< HEAD
   const [deleteProgrammingLanguage] = useMutation(DELETE_LANGUAGE, {
    refetchQueries: [{ query: GET_PROGRAMMING_LANGUAGES }],
  });

=======
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7
  const handleLearnClick = () => {
    navigate(`/programming-languages/${props.id}/lectures`);
  }

<<<<<<< HEAD
  const handleEditClick = () => {
    navigate(`/programming-languages/${props.id}/edit`); // nova ruta za update
  };

  const handleDeleteClick = async () => {
    
    const confirmDelete = window.confirm(
      `Are you sure you want to delete "${props.name}"?`
    );

    if (!confirmDelete) return;

    try {
      await deleteProgrammingLanguage({
        variables: { languageId: props.id },
      });
    } catch (error) {
      console.error("Error deleting programming language:", error);
    }
  };

=======
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7
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
<<<<<<< HEAD
        <button
          className={`${classes.button} ${classes.editButton}`}
          onClick={handleEditClick}
        >
          Edit
        </button>
        <button
          className={`${classes.button} ${classes.deleteButton}`}
          onClick={handleDeleteClick}
        >
          Delete
        </button>
=======
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7
      </div>
    </li>
  );
};

export default ProgrammingLanguageItem;
