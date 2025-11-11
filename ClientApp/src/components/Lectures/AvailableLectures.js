import classes from './Availablelectures.module.css';
import { useQuery } from '@apollo/client';
import './Availablelectures.module.css';
import { GET_LECTURES_FOR_LANGUAGE } from "../../Graphql/Queries/query";
import { useParams } from 'react-router-dom';
import LectureItem from './Lecture/LectureItem';
import Card from '../UI/Card';

const AvailableLectures = () => {
    const { id } = useParams();
    
    const { loading, error, data } = useQuery(GET_LECTURES_FOR_LANGUAGE, {
        variables: { id },
        fetchPolicy: "cache-and-network"

      });

      if (loading) {
        return (
          <div className={classes.loadingContainer}>
            <div className={classes.spinner}></div>
            <div className={classes.loadingText}>Loading</div>
          </div>
        );
      }
      
      if (error) {
        return (
          <section className={classes.errorContainer}>
            <p className={classes.errorText}>Error: {error.message}</p>
          </section>
        );
      }

      const language = data.programmingLanguage.edges[0];

      const lecturesList = language.node.lectures.edges.map((lecture) => (
        <LectureItem
        key={lecture.node.lectureId}
        id={lecture.node.lectureId}
        name={lecture.node.lectureName}                    
        description={lecture.node.lectureDescription}
        languageId = {id}
        languageName={language.node.languageName}>                    
        </LectureItem>
      ));

      return(
        <section className={classes.lectures}>
            <Card>
                <ul>{lecturesList}</ul>
            </Card>
        </section>
      );
}

export default AvailableLectures;