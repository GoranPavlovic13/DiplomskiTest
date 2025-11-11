import React from 'react';
import classes from './Spinner.module.css';

const Spinner = () => {
  return (
    <div className={classes.spinner}>
      <div className={classes.ldsDualRing}></div>
      <p>Generating test...</p>
    </div>
  );
};

export default Spinner;