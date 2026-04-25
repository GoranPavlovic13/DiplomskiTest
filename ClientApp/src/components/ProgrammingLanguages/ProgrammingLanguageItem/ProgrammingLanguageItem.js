import classes from "./ProgrammingLanguageItem.module.css";
import { useNavigate } from "react-router-dom";
import { useMutation } from "@apollo/client";
import { DELETE_LANGUAGE } from "../../../Graphql/Mutations/mutation";
import { GET_PROGRAMMING_LANGUAGES } from "../../../Graphql/Queries/query";
import { useAuth } from "../../../context/AuthContext";
const ProgrammingLanguageItem = (props) => {
  const navigate = useNavigate();
  const { userRole, isAuthenticated } = useAuth();

  const [deleteProgrammingLanguage] = useMutation(DELETE_LANGUAGE, {
    refetchQueries: [{ query: GET_PROGRAMMING_LANGUAGES }],
  });

  const handleLearnClick = () => {
    navigate(`/programming-languages/${props.id}/lectures`);
  };

  const handleEditClick = () => {
    navigate(`/programming-languages/${props.id}/edit`);
  };

  const handleDeleteClick = async () => {
    const confirmDelete = window.confirm(
      `Are you sure you want to delete "${props.name}"?`
    );
    if (!confirmDelete) return;

    try {
      await deleteProgrammingLanguage({ variables: { languageId: props.id } });
    } catch (error) {
      console.error("Error deleting programming language:", error);
    }
  };

  function humanize(str) {
    return str
      .split("_")
      .map((s) => s.charAt(0).toUpperCase() + s.slice(1))
      .join(" ");
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

        
        {isAuthenticated && userRole === "Administrator" && (
          <>
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
          </>
        )}
      </div>
    </li>
  );
};

export default ProgrammingLanguageItem;
