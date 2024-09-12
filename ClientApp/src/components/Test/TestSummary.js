import classes from "./TestSummary.module.css";

const TestSummary = (props) => {
  return (
    <section className={classes.summary}>
      <h2>{props.name}</h2>
      <p>
      Choose the correct answers for each task and finish the test by clicking the "Finish Test" button.
      </p>
    </section>
  );
};

export default TestSummary;
