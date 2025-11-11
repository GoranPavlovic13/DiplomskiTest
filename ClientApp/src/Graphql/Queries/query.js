import { gql } from "@apollo/client";

export const GET_PROGRAMMING_LANGUAGES = gql`
query ProgrammingLanguage {
<<<<<<< HEAD
    programmingLanguage{
        edges{
            node{
                languageId
                languageName
                languageDescription
                languageType
                lectures{
                        edges{
                            node{
                                lectureName
                            }
                        }
                    }                                                           
            }
        }
    }
}
`;

export const GET_PROGRAMMING_LANGUAGE_BY_ID = gql`
query ProgrammingLanguage ($id: UUID!){
    programmingLanguage (where: { languageId: {eq: $id } }){
        edges{
            node{
                languageId
                languageName
                languageDescription
                languageType
                lectures{
                        edges{
                            node{
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
query Lecture ($id: UUID!){
    lecture (where: { lectureId: {eq: $id } }){
        edges{
            node{
                lectureId
                lectureName
                lectureDescription
                programmingLanguages{
                    edges{
                        node{
                            languageId
                            languageName
                        }
                    }
                }
            }
        }
=======
    programmingLanguage {
        languageId
        languageName
        languageDescription
        languageType
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7
    }
}
`;

export const GET_LECTURES = gql`
query Lecture {
    lecture {
<<<<<<< HEAD
        edges{
            node{
                lectureId
                lectureName
            }
        }
=======
        lectureId
        lectureName
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7
    }
}
`;

<<<<<<< HEAD
    export const GET_LECTURES_FOR_LANGUAGE = gql`
    query ProgrammingLanguage($id: UUID!) {
        programmingLanguage(where: { languageId: {eq: $id } }) {
            edges{
                node{
                    languageId
                    languageName
                    languageDescription
                    languageType
                    lectures{
                        edges{
                            node{
                                lectureId
                                lectureName
                                lectureDescription
                            }
                        }
                    }              
                }
            }
        }
    }
    `;
=======
export const GET_LECTURES_FOR_LANGUAGE = gql`
query ProgrammingLanguage($id: UUID!) {
    programmingLanguage(where: { languageId: {eq: $id } }) {
    languageId
    languageName
      lectures{
        lecture{
            lectureId
            lectureName
            lectureDescription
        }
    }
    }
  }
`;
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7

export const GET_TEST = gql`
query Test($testId: UUID!){
    test (where: { testId: {eq: $testId } }){
<<<<<<< HEAD
        edges{
            node{
                testId
                testName
                level
                lectureProgrammingLanguageId
                exercises{
                    exerciseId
                    exerciseDescription
                    content
                    answers{
                        answerId
                        content
                    }
                }
=======
        testId
        testName
        level
        lectureProgrammingLanguageId
        exercises{
            exerciseId
            exerciseDescription
            content
            answers{
                answerId
                content
>>>>>>> 9843978ab435edda7211d5a0e5926168a51e95d7
            }
        }
    }
}`
