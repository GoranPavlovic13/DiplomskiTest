import classes from "./LectureSummary.module.css";

const LecturesSummary = () => {
  return (
    <section className={classes.summary}>
      <h2>Available lectures</h2>
      <p>
        Choose lecture you want to learn from our selection of available
        lectures and level of difficulty.
      </p>
    </section>
  );
};

export default LecturesSummary;
