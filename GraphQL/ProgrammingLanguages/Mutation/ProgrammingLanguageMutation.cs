using Entitites.Models;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.ProgrammingLanguages.Mutation
{
    [ExtendObjectType("Mutation")]
    public class ProgrammingLanguageMutation
    {
        public async Task<AddProgrammingLanguagePayload> AddProgrammingLanguageAsync(AddProgrammingLanguageInput input, [Service] RepositoryContext context)
        {

            var programmingLanguage = new ProgrammingLanguage
            {
                LanguageName = input.LanguageName,
                LanguageType = input.LanguageType,
                LanguageDescription = input.LanguageDescription,
            };

            if (input.SelectedLectureIds != null)
            {
                foreach (var lectureId in input.SelectedLectureIds)
                {
                    var lectureProgrammingLanguage = new LectureProgrammingLanguage
                    {
                        LanguageId = programmingLanguage.LanguageId,
                        LectureId = lectureId
                    };

                    if (programmingLanguage.Lectures == null)
                    {
                        programmingLanguage.Lectures = new List<LectureProgrammingLanguage>();
                    }

                    programmingLanguage.Lectures.Add(lectureProgrammingLanguage);
                }
            }

            if (context.ProgrammingLanguages is not null)
            {
                context.ProgrammingLanguages.Add(programmingLanguage);
                await context.SaveChangesAsync();
            }


            return new AddProgrammingLanguagePayload(programmingLanguage);
        }

        public async Task<AddProgrammingLanguagePayload> UpdateProgrammingLanguageAsync(UpdateProgrammingLanguageInput input, [Service] RepositoryContext context)
        {
            if (context.ProgrammingLanguages is null)
                throw new ArgumentNullException(nameof(context));

            if (context.LectureProgrammingLanguages is null)
                throw new ArgumentNullException(nameof(context));

            
            var existingLanguage = await context.ProgrammingLanguages
                .Include(pl => pl.Lectures)
                .FirstOrDefaultAsync(pl => pl.LanguageId == input.LanguageId)
                ?? throw new GraphQLException($"Programming language with ID '{input.LanguageId}' not found.");

            
            var duplicate = await context.ProgrammingLanguages
                .AnyAsync(pl => pl.LanguageName == input.LanguageName && pl.LanguageId != input.LanguageId);
            if (duplicate)
                throw new GraphQLException($"Programming language with name '{input.LanguageName}' already exists.");

            
            existingLanguage.LanguageName = input.LanguageName;
            existingLanguage.LanguageType = input.LanguageType;
            existingLanguage.LanguageDescription = input.LanguageDescription;

            
            var existingLectureIds = existingLanguage.Lectures?
                .Select(lp => lp.LectureId)
                .ToList()
                ?? new List<Guid>();

            
            var newLectureIds = input.SelectedLectureIds.Except(existingLectureIds).ToList();
            foreach (var lectureId in newLectureIds)
            {
                await context.LectureProgrammingLanguages.AddAsync(new LectureProgrammingLanguage
                {
                    LanguageId = existingLanguage.LanguageId,
                    LectureId = lectureId
                });
            }

            
            var removedLectureIds = existingLectureIds.Except(input.SelectedLectureIds).ToList();
            if (existingLanguage.Lectures != null && removedLectureIds.Count > 0)
            {
                var relationsToRemove = existingLanguage.Lectures
                    .Where(lp => removedLectureIds.Contains(lp.LectureId))
                    .ToList();

                foreach (var relation in relationsToRemove)
                {
                    if (relation != null)
                        context.LectureProgrammingLanguages.Remove(relation);
                }
            }

            await context.SaveChangesAsync();

            return new AddProgrammingLanguagePayload(existingLanguage);
        }

        public async Task<DeleteProgrammingLanguagePayload> DeleteProgrammingLanguageAsync(
        Guid languageId,
        [Service] RepositoryContext context)
        {
            if (context.ProgrammingLanguages is null)
                throw new ArgumentNullException(nameof(context));

            if (context.LectureProgrammingLanguages is null)
                throw new ArgumentNullException(nameof(context));

            var language = await context.ProgrammingLanguages
                .Include(l => l.Lectures)
                .FirstOrDefaultAsync(l => l.LanguageId == languageId);

            if (language is null)
            {
                throw new GraphQLException(new Error("Programming language not found.", "LANGUAGE_NOT_FOUND"));
            }

            if (language.Lectures != null && language.Lectures.Any())
            {
                context.LectureProgrammingLanguages.RemoveRange(language.Lectures);
            }

            context.ProgrammingLanguages.Remove(language);
            await context.SaveChangesAsync();

            return new DeleteProgrammingLanguagePayload(languageId);
        }
    }
}
