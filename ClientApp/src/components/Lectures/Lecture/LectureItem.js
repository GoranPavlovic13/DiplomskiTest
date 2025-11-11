import classes from "./LectureItem.module.css";
import { useNavigate } from "react-router-dom";
import { useMutation } from "@apollo/client";
import { GENERATE_TEST } from "../../../Graphql/Mutations/mutation";
import { useState } from "react";
import Spinner from "../../UI/Spinner";
import Modal from "../../UI/Modal";

const LectureItem = (props) => {
  const navigate = useNavigate();
  const [showModal, setShowModal] = useState(false);

  const [generateTest, { loading, error }] = useMutation(GENERATE_TEST, {
    onCompleted: (data) => {
      setShowModal(false);
      navigate(`/test/${data.generateTestExample.test.testId}`);
    },
    onError: () => {
      setShowModal(true);
    },
  });

  const handleGenerateTest = async (difficultyLevel) => {
    setShowModal(true);
<<<<<<< HEAD
    console.log(props);
=======
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7
    try {
      await generateTest({
        variables: {
          languageId: props.languageId,
          languageName: props.languageName,
          lectureId: props.id,
          lectureName: props.name,
          difficultyLevel: difficultyLevel,
        },
      });
    } catch (err) {
      console.error("Error generating test: ", err);
      setShowModal(false);
    }
  };

  return (
    <>
      <li className={classes.lecture}>
        <div>
          <h3>{props.name}</h3>
          <div className={classes.description}>{props.description}</div>
        </div>
        <div className={classes.buttons}>
          <button
            className={`${classes.button} ${classes.buttonBasic}`}
            onClick={() => handleGenerateTest("Beginer")}
            disabled={loading}
          >
            Begginer
          </button>
          <button
            className={`${classes.button} ${classes.buttonIntermediate}`}
            onClick={() => handleGenerateTest("Intermediate")}
            disabled={loading}
          >
            Intermediate
          </button>
          <button
            className={`${classes.button} ${classes.buttonAdvanced}`}
            onClick={() => handleGenerateTest("Advanced")}
            disabled={loading}
          >
            Advanced
          </button>
        </div>
      </li>
      {showModal && (
        <Modal>
          {loading && <Spinner />}
          {error && <p className={classes.error}>Error: {error.message}</p>}
        </Modal>
      )}
    </>
  );
};

export default LectureItem;
