import { useQuery, useMutation } from "@apollo/client";
import { useParams, useNavigate } from "react-router-dom";
import { GET_LECTURE_BY_ID, GET_PROGRAMMING_LANGUAGES } from "../../Graphql/Queries/query";
import { UPDATE_LECTURE } from "../../Graphql/Mutations/mutation";
import classes from "./AddLecture.module.css";

const UpdateLecture = () => {
  const { id } = useParams();
  const navigate = useNavigate();

  // Dobavljanje lekcije po id
  const { loading: lectureLoading, error: lectureError, data: lectureData } = useQuery(GET_LECTURE_BY_ID, {
    variables: { id },
  });

  // Dobavljanje svih programskih jezika
  const { loading: langLoading, error: langError, data: langData } = useQuery(GET_PROGRAMMING_LANGUAGES);

  const [updateLecture] = useMutation(UPDATE_LECTURE, {
    refetchQueries: ["Lecture"], // ili query koji refreshuje listu lekcija
  });

  if (lectureLoading || langLoading) return <p>Loading...</p>;
  if (lectureError) return <p>Error: {lectureError.message}</p>;
  if (langError) return <p>Error: {langError.message}</p>;

  const lecture = lectureData?.lecture?.edges[0]?.node;
  const programmingLanguages = langData?.programmingLanguage?.edges || [];

  // Lista ID-jeva jezika koji trenutno pripadaju lekciji
  const selectedLanguageIds = lecture?.programmingLanguages?.edges?.map(edge => String(edge.node.languageId)) || [];

  const handleSubmit = async (event) => {
    event.preventDefault();

    const lectureName = event.target.lectureName.value;
    const lectureDescription = event.target.lectureDescription.value;
    const selectedProgrammingLanguageIds = Array.from(
      event.target.programmingLanguages.selectedOptions
    ).map(option => option.value); // već string, poklapa se sa option value

    try {
      await updateLecture({
        variables: {
          lectureId: lecture.lectureId,
          lectureName,
          lectureDescription,
          selectedProgrammingLanguageIds,
        },
      });

      navigate("/lectures"); // vraćanje na listu lekcija
    } catch (err) {
      console.error("Error updating lecture:", err);
    }
  };

  return (
    <div className={classes["form-container"]}>
      <form className={classes.form} onSubmit={handleSubmit}>
        <div className={classes["form-row"]}>
          <div className={classes["form-group"]}>
            <label htmlFor="lectureName">Lecture Name:</label>
            <input
              type="text"
              id="lectureName"
              defaultValue={lecture?.lectureName || ""}
              placeholder="Lecture Name"
            />
          </div>
          <div className={classes["form-group"]}>
            <label htmlFor="lectureDescription">Lecture Description:</label>
            <textarea
              id="lectureDescription"
              defaultValue={lecture?.lectureDescription || ""}
              placeholder="Lecture Description"
              rows="4"
            />
          </div>
        </div>

        <div className={classes["form-row"]}>
          <div className={classes["form-group"]}>
            <label htmlFor="programmingLanguages">Programming Languages:</label>
            <select
              id="programmingLanguages"
              className={classes["custom-select"]}
              multiple
              defaultValue={selectedLanguageIds}
            >
              {programmingLanguages.map(edge => (
                <option key={edge.node.languageId} value={String(edge.node.languageId)}>
                  {edge.node.languageName}
                </option>
              ))}
            </select>
          </div>
        </div>

        <div className={classes["form-actions"]}>
          <button type="submit">Update Lecture</button>
        </div>
      </form>
    </div>
  );
};

export default UpdateLecture;
