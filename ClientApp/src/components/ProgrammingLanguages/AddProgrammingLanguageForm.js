import { useMutation, useQuery } from "@apollo/client";
import { GET_LECTURES } from "../../Graphql/Queries/query";
import classes from "./AddProgrammingLanguageForm.module.css";
import { ADD_LANGUAGE } from "../../Graphql/Mutations/mutation";

const AddProgrammingLanguageForm = ({ onClose, refetchLanguages }) => {
  const { loading, error, data } = useQuery(GET_LECTURES);
  const [addProgrammingLanguage] = useMutation(ADD_LANGUAGE);

  const handleSubmit = async (event) => {
    event.preventDefault();

    const languageName = event.target.languageName.value;
    const languageType = event.target.languageType.value;
    const languageDescription = event.target.languageDescription.value;
    const selectedLectureIds = Array.from(event.target.lectures.selectedOptions).map(
      (option) => option.value
    );

    try {
      const result = await addProgrammingLanguage({
        variables: {
          languageName,
          languageType,
          languageDescription,
          selectedLectureIds,
        },
      });

      // Opcionalno: Mozes obraditi response ovde, na primer resetovati formu ili zatvoriti modal.
      console.log("Added language:", result.data);

      refetchLanguages();

      onClose(); // Zatvori formu ako je potrebno
    } catch (error) {
      console.error("Error adding language:", error);
    }
  };
 
  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error.message}</p>;

  return (
    <div className={classes['form-container']}>
      <form className={classes.form} onSubmit={handleSubmit}>
        <div className={classes["form-row"]}>
          <div className={classes["form-group"]}>
            <label htmlFor="languageName">Language Name:</label>
            <input
              type="text"
              id="languageName"
              placeholder="Language Name"
            />
          </div>
          <div className={classes["form-group"]}>
            <label htmlFor="languageType">Language Type:</label>
            <select id="languageType">
              <option value="OBJECT_ORIENTED">Object-Oriented</option>
              <option value="PROCEDURAL">Procedural</option>
              <option value="OTHER">Other</option>
            </select>
          </div>
        </div>

        
        <div className={classes["form-row"]}>
          <div className={classes["form-group"]}>
            <label htmlFor="lectures">Lectures:</label>
            <select
              id="lectures"
              className={classes['custom-select']}
              multiple
            >
              {data.lecture.map((lec) => (
                <option key={lec.lectureId} value={lec.lectureId}>
                  {lec.lectureName}
                </option>
              ))}
            </select>
          </div>
          <div className={classes["form-group"]}>
            <label htmlFor="languageDescription">Language Description:</label>
            <textarea
              id="languageDescription"
              placeholder="Language Description"
              rows="4"
            ></textarea>
          </div>
        </div>
        
        
        <div className={classes["form-actions"]}>
          <button type="submit">Add Language</button>
        </div>
      </form>
    </div>
  );
};

export default AddProgrammingLanguageForm;
