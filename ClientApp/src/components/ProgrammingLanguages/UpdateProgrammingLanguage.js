import { useMutation, useQuery } from "@apollo/client";
import { useParams, useNavigate } from "react-router-dom";
import { useEffect, useState } from "react";
import { GET_PROGRAMMING_LANGUAGE_BY_ID, GET_LECTURES } from "../../Graphql/Queries/query";
import { UPDATE_LANGUAGE } from "../../Graphql/Mutations/mutation";
import classes from "./UpdateProgrammingLanguage.module.css";

const UpdateProgrammingLanguage = () => {
  const { id } = useParams();
  const navigate = useNavigate();

  const [selectedLectures, setSelectedLectures] = useState([]);

  // Dobavljanje jezika po ID
  const { loading: langLoading, error: langError, data: langData } = useQuery(
    GET_PROGRAMMING_LANGUAGE_BY_ID,
    { variables: { id } }
  );

  // Dobavljanje svih lekcija
  const { loading: lecLoading, error: lecError, data: lecData } = useQuery(GET_LECTURES);

  // Postavljanje inicijalno selektovanih lekcija
  useEffect(() => {
    if (langData) {
      const language = langData?.programmingLanguage?.edges?.[0]?.node;
      const lectureIds = language?.lectures?.edges?.map(edge => String(edge.node.lectureId)) || [];
      setSelectedLectures(lectureIds);
    }
  }, [langData]);

  const [updateProgrammingLanguage] = useMutation(UPDATE_LANGUAGE, {
    refetchQueries: ["ProgrammingLanguage"],
  });

  if (langLoading || lecLoading) return <p>Loading...</p>;
  if (langError) return <p>Error: {langError.message}</p>;
  if (lecError) return <p>Error: {lecError.message}</p>;

  const language = langData?.programmingLanguage?.edges?.[0]?.node;
  const lectures = lecData?.lecture?.edges || [];

  const handleLectureChange = (e) => {
    const values = Array.from(e.target.selectedOptions).map(opt => opt.value);
    setSelectedLectures(values);
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    const languageName = event.target.languageName.value;
    const languageType = event.target.languageType.value;
    const languageDescription = event.target.languageDescription.value;

    try {
      await updateProgrammingLanguage({
        variables: {
          languageId: language.languageId,
          languageName,
          languageType,
          languageDescription,
          selectedLectureIds: selectedLectures,
        },
      });

      navigate("/");
    } catch (error) {
      console.error("Error updating language:", error);
    }
  };

  return (
    <div className={classes["form-container"]}>
      <form className={classes.form} onSubmit={handleSubmit}>
        {/* Prvi red: Ime i tip jezika */}
        <div className={classes["form-row"]}>
          <div className={classes["form-group"]}>
            <label htmlFor="languageName">Language Name:</label>
            <input
              type="text"
              id="languageName"
              defaultValue={language?.languageName || ""}
              placeholder="Language Name"
            />
          </div>

          <div className={classes["form-group"]}>
            <label htmlFor="languageType">Language Type:</label>
            <select id="languageType" defaultValue={language?.languageType || "OTHER"}>
              <option value="OBJECT_ORIENTED">Object-Oriented</option>
              <option value="PROCEDURAL">Procedural</option>
              <option value="OTHER">Other</option>
            </select>
          </div>
        </div>

        {/* Drugi red: Lekcije i opis */}
        <div className={classes["form-row"]}>
          <div className={classes["form-group"]}>
            <label htmlFor="lectures">Lectures:</label>
            <select
              id="lectures"
              className={classes["custom-select"]}
              multiple
              value={selectedLectures} // kontrolisana vrednost
              onChange={handleLectureChange}
            >
              {lectures.map(edge => (
                <option key={edge.node.lectureId} value={String(edge.node.lectureId)}>
                  {edge.node.lectureName}
                </option>
              ))}
            </select>
          </div>

          <div className={classes["form-group"]}>
            <label htmlFor="languageDescription">Language Description:</label>
            <textarea
              id="languageDescription"
              defaultValue={language?.languageDescription || ""}
              placeholder="Language Description"
              rows="4"
            />
          </div>
        </div>

        <div className={classes["form-actions"]}>
          <button type="submit">Update Language</button>
        </div>
      </form>
    </div>
  );
};

export default UpdateProgrammingLanguage;
