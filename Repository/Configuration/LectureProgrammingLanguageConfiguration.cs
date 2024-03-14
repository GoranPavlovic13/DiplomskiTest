using Entitites.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class LectureProgrammingLanguageConfiguration : IEntityTypeConfiguration<LectureProgrammingLanguage>
    {
        public void Configure(EntityTypeBuilder<LectureProgrammingLanguage> builder)
        {
            builder.HasData(
                new LectureProgrammingLanguage
                {
                    LectureId = new Guid("7e78b348-7834-44d3-ad9b-93155079e9be"),
                    LanguageId = new Guid("8665c6cb-7dc0-4058-9bc7-7c65c7869d47")
                },
                new LectureProgrammingLanguage
                {
                    LectureId = new Guid("7e78b348-7834-44d3-ad9b-93155079e9be"),
                    LanguageId = new Guid("48e36ba7-6216-4b19-a671-066c0f5a8e0a")
                },
                new LectureProgrammingLanguage
                {
                    LectureId = new Guid("7e78b348-7834-44d3-ad9b-93155079e9be"),
                    LanguageId = new Guid("3a9723c8-af2c-46b9-a4cd-bcb32f5a90b6")
                },
                new LectureProgrammingLanguage
                {
                    LectureId = new Guid("7e78b348-7834-44d3-ad9b-93155079e9be"),
                    LanguageId = new Guid("bcd4aaec-f236-451a-92eb-7642471c8ecc")
                },

                new LectureProgrammingLanguage
                {
                    LectureId = new Guid("7c36d05c-333e-4970-8377-e5c96d25578f"),
                    LanguageId = new Guid("8665c6cb-7dc0-4058-9bc7-7c65c7869d47")
                },
                new LectureProgrammingLanguage
                {
                    LectureId = new Guid("7c36d05c-333e-4970-8377-e5c96d25578f"),
                    LanguageId = new Guid("48e36ba7-6216-4b19-a671-066c0f5a8e0a")
                },
                new LectureProgrammingLanguage
                {
                    LectureId = new Guid("7c36d05c-333e-4970-8377-e5c96d25578f"),
                    LanguageId = new Guid("3a9723c8-af2c-46b9-a4cd-bcb32f5a90b6")
                },
                new LectureProgrammingLanguage
                {
                    LectureId = new Guid("7c36d05c-333e-4970-8377-e5c96d25578f"),
                    LanguageId = new Guid("bcd4aaec-f236-451a-92eb-7642471c8ecc")
                }
                );
        }
    }
}
