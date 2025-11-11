import { gql } from "@apollo/client";

export const GET_PROGRAMMING_LANGUAGES = gql`
query ProgrammingLanguage {
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
    }
}
`;

export const GET_LECTURES = gql`
query Lecture {
    lecture {
        edges{
            node{
                lectureId
                lectureName
            }
        }
    }
}
`;

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

export const GET_TEST = gql`
query Test($testId: UUID!){
    test (where: { testId: {eq: $testId } }){
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
            }
        }
    }
}`
