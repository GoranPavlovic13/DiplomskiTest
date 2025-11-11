import classes from "./LectureItem.module.css";
import { useNavigate } from "react-router-dom";
import { useMutation } from "@apollo/client";
import { GET_LECTURES, GET_LECTURES_FOR_LANGUAGE } from "../../../Graphql/Queries/query";
import { DELETE_LECTURE } from "../../../Graphql/Mutations/mutation";

const SingleLecture = (props) => {
  const navigate = useNavigate();

  const [deleteLecture] = useMutation(DELETE_LECTURE, {
    update: (cache, { data }) => {
      if (!data?.deleteLecture?.success) return;

      const deletedId = data.deleteLecture.deletedLectureId;

      // ✅ 1. Ažuriraj globalni cache (GET_LECTURES)
      try {
        const existingLectures = cache.readQuery({ query: GET_LECTURES });
        if (existingLectures?.lecture?.edges) {
          const newEdges = existingLectures.lecture.edges.filter(
            (edge) => edge.node.lectureId !== deletedId
          );
          cache.writeQuery({
            query: GET_LECTURES,
            data: {
              lecture: {
                ...existingLectures.lecture,
                edges: newEdges,
              },
            },
          });
        }
      } catch {
        // GET_LECTURES možda nije učitan – ignoriši
      }

      // ✅ 2. Ažuriraj cache lekcija za konkretan programski jezik
      try {
        const langId = props.languageId;
        const existingLang = cache.readQuery({
          query: GET_LECTURES_FOR_LANGUAGE,
          variables: { id: langId },
        });

        if (existingLang?.programmingLanguage?.edges?.length > 0) {
          const oldLangNode = existingLang.programmingLanguage.edges[0].node;
          const filteredLectures =
            oldLangNode.lectures.edges.filter(
              (edge) => edge.node.lectureId !== deletedId
            );

          // 🔥 Ovo je ključno — kreiramo potpuno novu referencu
          const newData = {
            programmingLanguage: {
              ...existingLang.programmingLanguage,
              edges: [
                {
                  ...existingLang.programmingLanguage.edges[0],
                  node: {
                    ...oldLangNode,
                    lectures: {
                      ...oldLangNode.lectures,
                      edges: filteredLectures,
                    },
                  },
                },
              ],
            },
          };

          cache.writeQuery({
            query: GET_LECTURES_FOR_LANGUAGE,
            variables: { id: langId },
            data: newData,
          });
        }
      } catch (err) {
        console.warn("Could not update lecture list inside language cache:", err);
      }
    },
  });

  const handleEditClick = () => {
    navigate(`/edit-lecture/${props.id}`);
  };

  const handleDeleteClick = async () => {
    const confirmDelete = window.confirm(
      `Are you sure you want to delete lecture "${props.name}"?`
    );
    if (!confirmDelete) return;

    try {
      await deleteLecture({
        variables: { lectureId: props.id },
      });
    } catch (error) {
      console.error("Error deleting lecture:", error);
    }
  };

  return (
    <li className={classes.lecture}>
      <div>
        <h3>{props.name}</h3>
        <div className={classes.description}>{props.description}</div>
      </div>
      <div className={classes.buttons}>
        <button
          className={classes.button}
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
      </div>
    </li>
  );
};

export default SingleLecture;
