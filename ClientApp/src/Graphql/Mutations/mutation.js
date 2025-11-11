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


export const UPDATE_LANGUAGE = gql`
  mutation UpdateProgrammingLanguage($languageId: UUID!, $languageName: String!, $languageType: LanguageType!, $languageDescription: String!, $selectedLectureIds: [UUID!]!) {
    updateProgrammingLanguage(input: {languageId: $languageId, languageName: $languageName, languageType: $languageType,  languageDescription: $languageDescription, selectedLectureIds: $selectedLectureIds}) {
      programmingLanguage{
            languageId
            languageName
            languageType
            languageDescription
        }
    }
  }
`;

export const DELETE_LANGUAGE = gql`
  mutation DeleteProgrammingLanguage($languageId: UUID!) {
    deleteProgrammingLanguage(languageId: $languageId) {
      deletedLanguageId
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

export const UPDATE_LECTURE = gql`
  mutation UpdateLecture($lectureId: UUID!, $lectureName: String!, $lectureDescription: String!, $selectedProgrammingLanguageIds: [UUID!]!) {
    updateLecture(input: { lectureId: $lectureId, lectureName: $lectureName, lectureDescription: $lectureDescription, selectedProgrammingLanguageIds: $selectedProgrammingLanguageIds}) {
      lecture {
            lectureId
            lectureName
            lectureDescription
        }
    }
  }
`;

export const DELETE_LECTURE = gql`
  mutation DeleteLecture($lectureId: UUID!) {
    deleteLecture(lectureId: $lectureId)
    {
      success
      deletedLectureId
    }
  }

`;