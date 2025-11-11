import { useMutation, useQuery } from "@apollo/client";
import { GET_LECTURES } from "../../Graphql/Queries/query";
import classes from "./AddProgrammingLanguageForm.module.css";
import { ADD_LANGUAGE } from "../../Graphql/Mutations/mutation";

<<<<<<< HEAD
const AddProgrammingLanguageForm = ({ onClose }) => {
  const { loading, error, data } = useQuery(GET_LECTURES);

  const [addProgrammingLanguage] = useMutation(ADD_LANGUAGE, {
    update(cache, { data: {addProgrammingLanguage}}){

      const newLanguage = addProgrammingLanguage.programmingLanguage;

       const newEdge = {
      __typename: "ProgrammingLanguageEdge", // mora da se poklapa sa query-em
      node: newLanguage
    };

      cache.modify({
        fields: {
          programmingLanguage(existing = { edges: [] }){
            return {
            ...existing,
            edges: [...existing.edges, newEdge],
          };
          }
        }
      })
    }
  });
=======
const AddProgrammingLanguageForm = ({ onClose, refetchLanguages }) => {
  const { loading, error, data } = useQuery(GET_LECTURES);
  const [addProgrammingLanguage] = useMutation(ADD_LANGUAGE);
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7

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

<<<<<<< HEAD
=======
      refetchLanguages();

>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7
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
<<<<<<< HEAD
              {data.lecture.edges.map((lec) => (
                <option key={lec.node.lectureId} value={lec.node.lectureId}>
                  {lec.node.lectureName}
=======
              {data.lecture.map((lec) => (
                <option key={lec.lectureId} value={lec.lectureId}>
                  {lec.lectureName}
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7
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
