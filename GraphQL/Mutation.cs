using Entitites.Models;
using GraphQL.Lectures;
using GraphQL.ProgrammingLanguages;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL
{
    public class Mutation
    {
        
        public async Task<AddProgrammingLanguagePayload> AddProgrammingLanguageAsync(AddProgrammingLanguageInput input, [Service] RepositoryContext context)
        {

            var programmingLanguage = new ProgrammingLanguage
            {
                LanguageName = input.LanguageName,
                LanguageType = input.LanguageType,
                LanguageDescription = input.LanguageDescription
            };

            if(input.selectedLectureIds != null)
            {
                foreach (var lectureId in input.selectedLectureIds)
                {
                    var lectureProgrammingLanguage = new LectureProgrammingLanguage
                    {                       
                        LanguageId = programmingLanguage.LanguageId
                    };

                    if (programmingLanguage.Lectures == null)
                    {
                        programmingLanguage.Lectures = new List<LectureProgrammingLanguage>();
                    }

                    programmingLanguage.Lectures.Add(lectureProgrammingLanguage);
                }
            }
                       
            if(context.ProgrammingLanguages is not null)
            {
                context.ProgrammingLanguages.Add(programmingLanguage);
                await context.SaveChangesAsync();
            }


            return new AddProgrammingLanguagePayload(programmingLanguage);
        }

        public async Task<AddLecturePayload> AddLectureAsync(AddLectureInput input, [Service] RepositoryContext context)
        {

            var lecture = new Lecture
            {
                LectureName = input.LectureName,             
                LectureDescription = input.LectureDescription
            };

            if (input.selectedProgrammingLanguageIds != null)
            {
                foreach (var programmingLanguageId in input.selectedProgrammingLanguageIds)
                {
                    var lectureProgrammingLanguage = new LectureProgrammingLanguage
                    {                       
                        LanguageId = programmingLanguageId
                    };

                    if (lecture.ProgrammingLanguages == null)
                    {
                        lecture.ProgrammingLanguages = new List<LectureProgrammingLanguage>();
                    }

                    lecture.ProgrammingLanguages.Add(lectureProgrammingLanguage);
                }
            }

            if (context.Lectures is not null)
            {
                context.Lectures.Add(lecture);
                await context.SaveChangesAsync();
            }


            return new AddLecturePayload(lecture);
        }
    }
}
