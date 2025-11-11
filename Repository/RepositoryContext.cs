using Entitites.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.ApplyConfiguration(new ProgrammingLanguageConfiguration());
            modelBuilder.ApplyConfiguration(new LectureConfiguration());
          
            modelBuilder.Entity<LectureProgrammingLanguage>()
                .HasOne(lp => lp.Lecture)
                .WithMany(l => l.ProgrammingLanguages)
                .HasForeignKey(lp => lp.LectureId);

            modelBuilder.Entity<LectureProgrammingLanguage>()
                .HasOne(lp => lp.ProgrammingLanguage)
                .WithMany(p => p.Lectures)
                .HasForeignKey(lp => lp.LanguageId);
            

            modelBuilder.ApplyConfiguration(new LectureProgrammingLanguageConfiguration());
        }

        public DbSet<Lecture>? Lectures { get; set; }
        public DbSet<ProgrammingLanguage>? ProgrammingLanguages { get; set; }
        public DbSet<LectureProgrammingLanguage>? LectureProgrammingLanguages { get; set; }
        public DbSet<Exercise>? Exercises { get; set; }
        public DbSet<Answer>? Answers { get; set; }
        
        public DbSet<Answer>? CorrectAnswers { get; set; }
        public DbSet<Test>? Tests { get; set; }
    }
}
