import { Fragment } from "react";
import { Link } from "react-router-dom";
import classes from "./header.module.css";
import codeImage from '../../assets/abstract-modern-tech-of-programming-code-screen-developer-free-photo.jpg';

const Header = () => {
  return (
    <Fragment>
      <header className={classes.header}>
        <div className={classes['title-and-link']}>
          <h1>Learn Programming</h1>
          <nav>
            <Link to="/add-lecture" className={classes.link}>
              Add Lecture
            </Link>
          </nav>
        </div>
      </header>
      <div className={classes["main-image"]}>
        <img src={codeImage} alt="Code"></img>
      </div>
    </Fragment>
  );
};

export default Header;
