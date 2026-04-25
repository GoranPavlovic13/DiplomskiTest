import { useQuery } from "@apollo/client";
import { GET_PROGRAMMING_LANGUAGES } from "../../Graphql/Queries/query";
import ProgrammingLanguageItem from "./ProgrammingLanguageItem/ProgrammingLanguageItem";
import classes from "./AvailableProgrammingLanguages.module.css";
import Card from "../UI/Card";
import React, { useState, useEffect } from "react";
import AddProgrammingLanguageForm from "./AddProgrammingLanguageForm";
import { useAuth } from "../../context/AuthContext";

const AvailableProgrammingLanguages = () => {
  const { userRole, isAuthenticated } = useAuth();

  //  SEARCH
  const [searchTerm, setSearchTerm] = useState("");

  //  FILTER
  const [selectedType, setSelectedType] = useState("");

  //  PAGINATION
  const [currentPage, setCurrentPage] = useState(1);
  const [cursorHistory, setCursorHistory] = useState([null]);
  const [cursor, setCursor] = useState(null); // 👈 KLJUČNO

  const [isFormVisible, setFormVisible] = useState(false);

  const toggleFormVisibility = () => {
    setFormVisible((prevState) => !prevState);
  };

  //  WHERE
  const where = {
    ...(searchTerm && {
      languageName: { contains: searchTerm },
    }),
    ...(selectedType && {
      languageType: { eq: selectedType },
    }),
  };

  //  QUERY (SVE ide kroz variables)
  const { loading, error, data, previousData, networkStatus } = useQuery(
    GET_PROGRAMMING_LANGUAGES,
    {
      variables: {
        first: 2,
        after: cursor, // 👈 sada vezano za state
        where,
      },
      notifyOnNetworkStatusChange: true,
    },
  );

  const safeData = data ?? previousData;

  //  RESET pagination kad se menja filter/search
  useEffect(() => {
    setCurrentPage(1);
    setCursorHistory([null]);
    setCursor(null);
  }, [searchTerm, selectedType]);

  //  loading
  if (loading && networkStatus === 1 && !safeData) {
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

  const isFetching = networkStatus === 4;

  const languages = safeData?.programmingLanguage?.edges ?? [];

  const languagesList = languages.map((language) => (
    <ProgrammingLanguageItem
      key={language.node.languageId}
      id={language.node.languageId}
      name={language.node.languageName}
      description={language.node.languageDescription}
      type={language.node.languageType}
    />
  ));

  //  NEXT
  const handleNext = () => {
    const endCursor = safeData?.programmingLanguage?.pageInfo?.endCursor;
    if (!endCursor) return;

    setCursorHistory((prev) => [...prev, endCursor]);
    setCursor(endCursor);
    setCurrentPage((prev) => prev + 1);
  };

  //  PREVIOUS
  const handlePrevious = () => {
    if (currentPage === 1) return;

    const prevCursor = cursorHistory[currentPage - 2];

    setCursor(prevCursor);
    setCurrentPage((prev) => prev - 1);
  };

  return (
    <>
      {isFormVisible && (
        <AddProgrammingLanguageForm onClose={toggleFormVisibility} />
      )}

      <section className={classes.languages}>
        {isAuthenticated && userRole === "Administrator" && (
          <button className={classes.button} onClick={toggleFormVisibility}>
            {isFormVisible ? "^ Hide Form" : "+ Add New Language"}
          </button>
        )}

        {/*  SEARCH + FILTER */}
        <div className={classes.controls}>
          <input
            type="text"
            placeholder="Search languages..."
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
            className={classes.searchInput}
          />

          <div className={classes.filterBox}>
            <label className={classes.filterLabel}>Filter by type</label>

            <select
              value={selectedType}
              onChange={(e) => setSelectedType(e.target.value)}
              className={classes.select}
            >
              <option value="">All</option>
              <option value="OBJECT_ORIENTED">Object Oriented</option>
              <option value="PROCEDURAL">Procedural</option>
              <option value="OTHER">Other</option>
            </select>
          </div>
        </div>

        <Card>
          <ul>{languagesList}</ul>
        </Card>
        {/* PAGINATION */}
        <div className={classes.pagination}>
          <button
            className={classes.navButton}
            onClick={handlePrevious}
            disabled={currentPage === 1 || isFetching}
          >
            ← Previous
          </button>

          <span className={classes.pageNumber}>
            Page {currentPage} {isFetching && "..."}
          </span>

          <button
            className={classes.navButton}
            onClick={handleNext}
            disabled={
              !safeData?.programmingLanguage?.pageInfo?.hasNextPage ||
              isFetching
            }
          >
            Next →
          </button>
        </div>
      </section>
    </>
  );
};

export default AvailableProgrammingLanguages;
