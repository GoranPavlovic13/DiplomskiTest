import { gql } from "@apollo/client";

export const GET_PROGRAMMING_LANGUAGES = gql`
  query ProgrammingLanguage(
    $where: ProgrammingLanguageFilterInput
    $first: Int
    $after: String
  ) {
    programmingLanguage(where: $where, first: $first, after: $after) {
      edges {
        node {
          languageId
          languageName
          languageDescription
          languageType
          lectureProgrammingLanguages {
            lecture {
              lectureName
            }
          }
        }
      }
      pageInfo {
        hasNextPage
        endCursor
      }
    }
  }
`;

export const GET_LANGUAGES_PAGINATION = gql`
  query ProgrammingLanguage($first: Int, $after: String) {
    programmingLanguage(first: $first, after: $after) {
      edges {
        node {
          languageId
          languageName
          languageDescription
          languageType
        }
      }
      pageInfo {
        hasNextPage
        endCursor
      }
    }
  }
`;

export const GET_PROGRAMMING_LANGUAGE_BY_ID = gql`
  query ProgrammingLanguage($id: UUID!) {
    programmingLanguage(where: { languageId: { eq: $id } }) {
      edges {
        node {
          languageId
          languageName
          languageDescription
          languageType
          lectures {
            edges {
              node {
                lectureId
                lectureName
              }
            }
          }
        }
      }
    }
  }
`;

export const GET_LECTURE_BY_ID = gql`
  query Lecture($id: UUID!) {
    lecture(where: { lectureId: { eq: $id } }) {
      edges {
        node {
          lectureId
          lectureName
          lectureDescription
          programmingLanguages {
            programmingLanguage{
                        languageId
                        languageName
                    }
          }
        }
      }
    }
  }
`;

export const GET_LECTURES = gql`
  query Lecture {
    lecture {
      edges {
        node {
          lectureId
          lectureName
        }
      }
    }
  }
`;

export const GET_LECTURES_FOR_LANGUAGE = gql`
  query ProgrammingLanguage($id: UUID!) {
    programmingLanguage(where: { languageId: { eq: $id } }) {
      edges {
        node {
          languageId
          languageName
          languageDescription
          languageType
          lectureProgrammingLanguages{
                    lecture{
                        lectureId
                        lectureName
                        lectureDescription
                    }
            }
        }
      }
    }
  }
`;

export const GET_TEST = gql`
  query Test($testId: UUID!) {
    test(where: { testId: { eq: $testId } }) {
      edges {
        node {
          testId
          testName
          level
          lectureProgrammingLanguageId
          exercises {
            exerciseId
            exerciseDescription
            content
            answers {
              answerId
              content
            }
          }
        }
      }
    }
  }
`;
