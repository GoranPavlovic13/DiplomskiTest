import { Fragment } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useAuth } from "../../context/AuthContext";
import classes from "./header.module.css";
import codeImage from "../../assets/abstract-modern-tech-of-programming-code-screen-developer-free-photo.jpg";

const Header = () => {
  const navigate = useNavigate();
  const {userRole, isAuthenticated, logout } = useAuth();

  const handleLogout = () => {
    logout();
    navigate("/");
  };


  return (
    <Fragment>
      <header className={classes.header}>
        <div className={classes["title-and-link"]}>
          <h1>
            <Link
              to={isAuthenticated ? "/programming-languages" : "/login"}
              className={classes.homeLink}
            >
              Learn Programming
            </Link>
          </h1>

          {isAuthenticated && userRole === "Administrator" &&(
            <nav>
              <Link to="/lectures" className={classes.link}>
                Lectures
              </Link>
            </nav>
          )}
        </div>

        {isAuthenticated && (
          <button className={classes.logoutButton} onClick={handleLogout}>
            Logout
          </button>
        )}
      </header>

      <div className={classes["main-image"]}>
        <img src={codeImage} alt="Code" />
      </div>
    </Fragment>
  );
};

export default Header;
