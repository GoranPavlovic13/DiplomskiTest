import { useMutation, useQuery } from "@apollo/client";
<<<<<<< HEAD
import { GET_PROGRAMMING_LANGUAGES, GET_LECTURES_FOR_LANGUAGE } from "../../Graphql/Queries/query";
import classes from "./AddLecture.module.css";
import { ADD_LECTURE } from "../../Graphql/Mutations/mutation";

const AddLecture = ({ onClose }) => {

  const { loading, error, data } = useQuery(GET_PROGRAMMING_LANGUAGES);

  const [addLecture] = useMutation(ADD_LECTURE, {
    update(cache, { data: { addLecture } }) {

      const newLecture = addLecture.lecture;

      // 📌 1. Kreiramo novi "edge" (standardni GraphQL format)
      const newEdge = {
        __typename: "LectureEdge",
        node: newLecture,
      };

      // 📌 2. Ažuriramo globalnu listu svih lekcija
      cache.modify({
        fields: {
          lecture(existing = { edges: [] }) {
            return {
              ...existing,
              edges: [...existing.edges, newEdge],
            };
          },
        },
      });

      // 📌 3. Ažuriramo svaku listu lekcija za programske jezike 
      // na koje je nova lekcija dodeljena
      const languageIds =
        newLecture.programmingLanguages?.map((pl) => pl.languageId) || [];

      languageIds.forEach((languageId) => {
        try {
          cache.modify({
            id: cache.identify({
              __typename: "ProgrammingLanguageType",
              languageId: languageId,
            }),
            fields: {
              lectures(existing = { edges: [] }) {
                // Proveri da li lekcija već postoji u listi (da izbegnemo duplikate)
                const alreadyExists = existing.edges.some(
                  (edge) => edge.node.lectureId === newLecture.lectureId
                );

                if (alreadyExists) return existing;

                return {
                  ...existing,
                  edges: [...existing.edges, newEdge],
                };
              },
            },
          });
        } catch (e) {
          console.warn(`Cache update failed for language ${languageId}`, e);
        }
      });
    },
  });

  // 📌 Forma za dodavanje
=======
import { GET_PROGRAMMING_LANGUAGES } from "../../Graphql/Queries/query";
import classes from "./AddLecture.module.css";
import { ADD_LECTURE } from "../../Graphql/Mutations/mutation";
import AddLectureSummary from "./Lecture/AddLectureSummary";

const AddLecture = ({ onClose, refetchLectures }) => {
  const { loading, error, data } = useQuery(GET_PROGRAMMING_LANGUAGES);
  const [addLecture] = useMutation(ADD_LECTURE);

>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7
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
<<<<<<< HEAD
      onClose(); // Zatvori formu

=======

      refetchLectures(); // Osvježavanje liste lekcija nakon dodavanja nove

      onClose(); // Zatvori formu
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7
    } catch (error) {
      console.error("Error adding lecture:", error);
    }
  };

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error.message}</p>;

<<<<<<< HEAD
=======
  // Proveri da li je data.programmingLanguages dostupno pre nego što koristiš map
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7
  if (!data || !data.programmingLanguage) {
    return <p>No programming languages available.</p>;
  }

  return (
<<<<<<< HEAD
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
              {data.programmingLanguage.edges.map((edge) => (
                <option
                  key={edge.node.languageId}
                  value={edge.node.languageId}
                >
                  {edge.node.languageName}
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
=======
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
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7
  );
};

export default AddLecture;
