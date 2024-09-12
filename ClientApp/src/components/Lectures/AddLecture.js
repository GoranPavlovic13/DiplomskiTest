import { useMutation, useQuery } from "@apollo/client";
import { GET_PROGRAMMING_LANGUAGES } from "../../Graphql/Queries/query";
import classes from "./AddLecture.module.css";
import { ADD_LECTURE } from "../../Graphql/Mutations/mutation";
import AddLectureSummary from "./Lecture/AddLectureSummary";

const AddLecture = ({ onClose, refetchLectures }) => {
  const { loading, error, data } = useQuery(GET_PROGRAMMING_LANGUAGES);
  const [addLecture] = useMutation(ADD_LECTURE);

  const handleSubmit = async (event) => {
    event.preventDefault();

    const lectureName = event.target.lectureName.value;
    const lectureDescription = event.target.lectureDescription.value;
    const selectedProgrammingLanguageIds = Array.from(
      event.target.programmingLanguages.selectedOptions
    ).map((option) => option.value);

    try {
      const result = await addLecture({
        variables: {
          lectureName,
          lectureDescription,
          selectedProgrammingLanguageIds,
        },
      });

      console.log("Added lecture:", result.data);

      refetchLectures(); // Osvježavanje liste lekcija nakon dodavanja nove

      onClose(); // Zatvori formu
    } catch (error) {
      console.error("Error adding lecture:", error);
    }
  };

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error.message}</p>;

  // Proveri da li je data.programmingLanguages dostupno pre nego što koristiš map
  if (!data || !data.programmingLanguage) {
    return <p>No programming languages available.</p>;
  }

  return (
    <>
      <AddLectureSummary></AddLectureSummary>
      <div className={classes["form-container"]}>
        <form className={classes.form} onSubmit={handleSubmit}>
          <div className={classes["form-row"]}>
            <div className={classes["form-group"]}>
              <label htmlFor="lectureName">Lecture Name:</label>
              <input type="text" id="lectureName" placeholder="Lecture Name" />
            </div>
            <div className={classes["form-group"]}>
              <label htmlFor="lectureDescription">Lecture Description:</label>
              <textarea
                id="lectureDescription"
                placeholder="Lecture Description"
                rows="4"
              ></textarea>
            </div>
          </div>

          <div className={classes["form-row"]}>
            <div className={classes["form-group"]}>
              <label htmlFor="programmingLanguages">
                Programming Languages:
              </label>
              <select
                id="programmingLanguages"
                className={classes["custom-select"]}
                multiple
              >
                {data.programmingLanguage.map((lang) => (
                  <option key={lang.languageId} value={lang.languageId}>
                    {lang.languageName}
                  </option>
                ))}
              </select>
            </div>
          </div>

          <div className={classes["form-actions"]}>
            <button type="submit">Add Lecture</button>
          </div>
        </form>
      </div>
    </>
  );
};

export default AddLecture;
