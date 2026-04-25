using Entitites.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProgrammingLanguageConfiguration());
            modelBuilder.ApplyConfiguration(new LectureConfiguration());
          
            modelBuilder.Entity<LectureProgrammingLanguage>()
                .HasOne(lp => lp.Lecture)
                .WithMany(l => l.ProgrammingLanguages)
                .HasForeignKey(lp => lp.LectureId);

            modelBuilder.Entity<LectureProgrammingLanguage>()
                .HasOne(lp => lp.ProgrammingLanguage)
                .WithMany(p => p.LectureProgrammingLanguages)
                .HasForeignKey(lp => lp.LanguageId);
            

            modelBuilder.ApplyConfiguration(new LectureProgrammingLanguageConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
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
