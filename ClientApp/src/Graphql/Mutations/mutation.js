import { gql } from "@apollo/client";

export const GENERATE_TEST = gql`
  mutation GenerateTestExample($languageId: UUID!, $languageName: String!, $lectureId: UUID!, $lectureName: String!, $difficultyLevel: String!) {
      generateTestExample(
      input: {
      languageId: $languageId, 
      languageName: $languageName, 
      lectureId: $lectureId, 
      lectureName: $lectureName, 
      difficultyLevel: $difficultyLevel
    }){
        test {
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
                isCorrect
            }
        }
    }
}
}
`;

export const EVALUATE_TEST = gql`
  mutation EvaluateTest($testId: UUID!, $selectedAnswers: [UUID!]!) {
    evaluateTest(input: { testId: $testId, selectedAnswers: $selectedAnswers }) {
      success
      message
      score
    }
  }
`;

export const ADD_LANGUAGE = gql`
  mutation AddProgrammingLanguage($languageName: String!, $languageType: LanguageType!, $languageDescription: String!, $selectedLectureIds: [UUID!]!) {
    addProgrammingLanguage(input: { languageName: $languageName, languageType: $languageType,  languageDescription: $languageDescription, selectedLectureIds: $selectedLectureIds}) {
      programmingLanguage{
            languageId
            languageName
            languageType
            languageDescription
        }
    }
  }
`;

export const ADD_LECTURE = gql`
  mutation AddLecture($lectureName: String!, $lectureDescription: String!, $selectedProgrammingLanguageIds: [UUID!]!) {
    addLecture(input: { lectureName: $lectureName, lectureDescription: $lectureDescription, selectedProgrammingLanguageIds: $selectedProgrammingLanguageIds}) {
      lecture {
            lectureId
            lectureName
            lectureDescription
        }
    }
  }
`;