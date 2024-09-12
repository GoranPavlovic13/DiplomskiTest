import { gql } from "@apollo/client";

export const GET_PROGRAMMING_LANGUAGES = gql`
query ProgrammingLanguage {
    programmingLanguage {
        languageId
        languageName
        languageDescription
        languageType
    }
}
`;

export const GET_LECTURES = gql`
query Lecture {
    lecture {
        lectureId
        lectureName
    }
}
`;

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

export const GET_TEST = gql`
query Test($testId: UUID!){
    test (where: { testId: {eq: $testId } }){
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
}`
