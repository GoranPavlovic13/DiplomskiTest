using Entitites.Models;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Lectures
{
    [ExtendObjectType("Mutation")]
    public class LectureMutation
    {
        public async Task<AddLecturePayload> AddLectureAsync(AddLectureInput input, [Service] RepositoryContext context)
        {
            // 1. Kreiramo novu lekciju
            var lecture = new Lecture
            {
                LectureName = input.LectureName,
                LectureDescription = input.LectureDescription,
            };

            if (context.Lectures != null)
            {
                // Proveri da li već postoji ista po imenu (opciono)
                if (!context.Lectures.Any(l => l.LectureName == input.LectureName))
                {
                    await context.Lectures.AddAsync(lecture);
                    await context.SaveChangesAsync(); // obavezno da bi dobio LectureId
                }
                else
                {
                    throw new GraphQLException($"Lecture with name '{input.LectureName}' already exists.");
                }
            }

            // 2. Ako su prosleđeni jezici – napravimo relacije
            if (input.selectedProgrammingLanguageIds != null && input.selectedProgrammingLanguageIds.Any())
            {
                foreach (var programmingLanguageId in input.selectedProgrammingLanguageIds)
                {
                    var foundLanguage = await context.ProgrammingLanguages!
                        .FirstOrDefaultAsync(pl => pl.LanguageId == programmingLanguageId);

                    if (foundLanguage != null)
                    {
                        var lectureProgrammingLanguage = new LectureProgrammingLanguage
                        {
                            LectureProgrammingLanguageId = Guid.NewGuid(),
                            LanguageId = foundLanguage.LanguageId,
                            ProgrammingLanguage = foundLanguage,
                            LectureId = lecture.LectureId,
                            Lecture = lecture
                        };

                        if (context.LectureProgrammingLanguages != null)
                        {
                            await context.LectureProgrammingLanguages.AddAsync(lectureProgrammingLanguage);
                        }
                    }
                }

                await context.SaveChangesAsync();
            }

            // 3. Ponovo učitaj lekciju sa povezanim jezicima
            var lectureWithLanguages = await context.Lectures!
                .Include(l => l.ProgrammingLanguages!)
                    .ThenInclude(lp => lp.ProgrammingLanguage!)
                .FirstOrDefaultAsync(l => l.LectureId == lecture.LectureId);

            return new AddLecturePayload(lectureWithLanguages!);
        }

        public async Task<AddLecturePayload?> UpdateLectureAsync(UpdateLectureInput input, [Service] RepositoryContext context)
        {
            if (context.Lectures == null)
                return null;

            var lecture = await context.Lectures!
                .Include(l => l.ProgrammingLanguages!)
                    .ThenInclude(lp => lp.ProgrammingLanguage!)
                .FirstOrDefaultAsync(l => l.LectureId == input.LectureId);

            if (lecture == null)
                throw new GraphQLException("Lecture not found.");

            lecture.LectureName = input.LectureName;
            lecture.LectureDescription = input.LectureDescription;

            if (context.LectureProgrammingLanguages != null)
            {
                var oldRelations = context.LectureProgrammingLanguages
                    .Where(lp => lp.LectureId == input.LectureId)
                    .ToList();

                context.LectureProgrammingLanguages.RemoveRange(oldRelations);
            }

            if (input.selectedProgrammingLanguageIds != null && input.selectedProgrammingLanguageIds.Any())
            {
                var newRelations = input.selectedProgrammingLanguageIds
                    .Select(langId => new LectureProgrammingLanguage
                    {
                        LectureProgrammingLanguageId = Guid.NewGuid(),
                        LectureId = input.LectureId,
                        LanguageId = langId
                    });

                await context.LectureProgrammingLanguages!.AddRangeAsync(newRelations);
            }

            await context.SaveChangesAsync();

            await context.Entry(lecture)
            .Collection(l => l.ProgrammingLanguages!)
            .Query()
            .Include(lp => lp.ProgrammingLanguage!)
            .LoadAsync();

            return new AddLecturePayload(lecture);
        }

        public async Task<DeleteLecturePayload> DeleteLectureAsync(Guid lectureId, [Service] RepositoryContext context)
        {
            if (context.Lectures == null)
                throw new ArgumentNullException(nameof(context));

            var lecture = await context.Lectures.FindAsync(lectureId);
            if (lecture == null)
                throw new GraphQLException("Lecture not found");

            context.Lectures.Remove(lecture);
            await context.SaveChangesAsync();

            return new DeleteLecturePayload(true, lectureId);
        }
    }
}

