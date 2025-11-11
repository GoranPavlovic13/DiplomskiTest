using Entitites.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository.Configuration
{
    public class LectureConfiguration : IEntityTypeConfiguration<Lecture>
    {
        public void Configure(EntityTypeBuilder<Lecture> builder)
        {
            builder.HasData
            (
                new Lecture
                {
                    LectureId = new Guid("7e78b348-7834-44d3-ad9b-93155079e9be"),
                    LectureName = "Arrays",
                    LectureDescription = "Some Description."
                },
                new Lecture
                {
                    LectureId = new Guid("7c36d05c-333e-4970-8377-e5c96d25578f"),
                    LectureName = "Functions",
                    LectureDescription = "Some Description."
                }
            );
        }
    }
}
