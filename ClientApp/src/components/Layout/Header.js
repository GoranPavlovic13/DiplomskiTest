import { Fragment } from "react";
import { Link } from "react-router-dom";
import classes from "./header.module.css";
import codeImage from '../../assets/abstract-modern-tech-of-programming-code-screen-developer-free-photo.jpg';

const Header = () => {
  return (
    <Fragment>
      <header className={classes.header}>
        <div className={classes['title-and-link']}>
<<<<<<< HEAD
          <h1>
            <Link to="/" className={classes.homeLink}>
              Learn Programming
            </Link>
          </h1>
          <nav>
            <Link to="/lectures" className={classes.link}>
              Lectures
            </Link>
          </nav>
        </div>
      </header> 
=======
          <h1>Learn Programming</h1>
          <nav>
            <Link to="/add-lecture" className={classes.link}>
              Add Lecture
            </Link>
          </nav>
        </div>
      </header>
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7
      <div className={classes["main-image"]}>
        <img src={codeImage} alt="Code"></img>
      </div>
    </Fragment>
  );
};

export default Header;
