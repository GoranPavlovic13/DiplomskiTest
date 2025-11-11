using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    LectureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LectureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LectureDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.LectureId);
                });

            migrationBuilder.CreateTable(
                name: "ProgrammingLanguages",
                columns: table => new
                {
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageType = table.Column<int>(type: "int", nullable: true),
                    LanguageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingLanguages", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "LectureProgrammingLanguages",
                columns: table => new
                {
                    LectureProgrammingLanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LectureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureProgrammingLanguages", x => x.LectureProgrammingLanguageId);
                    table.ForeignKey(
                        name: "FK_LectureProgrammingLanguages_Lectures_LectureId",
                        column: x => x.LectureId,
                        principalTable: "Lectures",
                        principalColumn: "LectureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LectureProgrammingLanguages_ProgrammingLanguages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    TestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LectureProgrammingLanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_Tests_LectureProgrammingLanguages_LectureProgrammingLanguageId",
                        column: x => x.LectureProgrammingLanguageId,
                        principalTable: "LectureProgrammingLanguages",
                        principalColumn: "LectureProgrammingLanguageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.ExerciseId);
                    table.ForeignKey(
                        name: "FK_Exercises_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    AnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_Answer_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Lectures",
                columns: new[] { "LectureId", "LectureDescription", "LectureName" },
                values: new object[,]
                {
                    { new Guid("7c36d05c-333e-4970-8377-e5c96d25578f"), null, "Functions" },
                    { new Guid("7e78b348-7834-44d3-ad9b-93155079e9be"), null, "Arrays" }
                });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "LanguageId", "LanguageDescription", "LanguageName", "LanguageType" },
                values: new object[,]
                {
                    { new Guid("3a9723c8-af2c-46b9-a4cd-bcb32f5a90b6"), "Opis: C# je moderan, objektno-orijentisan jezik razvijen od strane Microsoft-a. Namenjen je razvoju aplikacija na platformi .NET.\r\nKarakteristike: Objektno-orijentisan, podržava garbage collection, delegati, događaji, LINQ (Language Integrated Query), Lambda izraze.\r\nPrimeri upotrebe: Razvoj Windows aplikacija, web aplikacija, igara, mobilnih aplikacija.", "C#", 0 },
                    { new Guid("48e36ba7-6216-4b19-a671-066c0f5a8e0a"), "Opis: C++ je proširenje jezika C koje uvodi koncepte objektno-orijentisanog programiranja (OOP). Razvijen je kao unapređenje jezika C, omogućavajući programerima da koriste OOP paradigmu.\r\nKarakteristike: Objektno-orijentisan, podržava nasleđivanje, polimorfizam, apstrakciju i inkapsulaciju, bogata standardna biblioteka.\r\nPrimeri upotrebe: Razvoj softvera, igara, operativnih sistema, aplikacija za računarsko modelovanje.", "C++", 0 },
                    { new Guid("8665c6cb-7dc0-4058-9bc7-7c65c7869d47"), "Opis: C je opštepriznati proceduralni programski jezik koji je nastao u Bell Labs-u 1972. godine. Poznat je po svojoj efikasnosti, fleksibilnosti i mogućnosti direktnog pristupa hardveru.\r\nKarakteristike: Statički tipiziran, niskog nivoa apstrakcije, podržava pokazivače, omogućava direktno upravljanje memorijom.\r\nPrimeri upotrebe: Razvoj operativnih sistema, sistemske aplikacije, ugrađeni sistemi.", "C", 1 },
                    { new Guid("bcd4aaec-f236-451a-92eb-7642471c8ecc"), "Opis: Java je objektno-orijentisan, platformski nezavisan jezik razvijen od strane Sun Microsystems-a (sada deo Oracle-a). Poznat je po svojoj sigurnosti i portabilnosti.\r\nKarakteristike: Objektno-orijentisan, platformski nezavisan (rad na različitim operativnim sistemima), podržava garbage collection, izuzetno popularan u razvoju web i mobilnih aplikacija.\r\nPrimeri upotrebe: Razvoj web aplikacija, mobilnih aplikacija (Android), serverskih aplikacija, finansijskih sistema.", "Java", 0 }
                });

            migrationBuilder.InsertData(
                table: "LectureProgrammingLanguages",
                columns: new[] { "LectureProgrammingLanguageId", "LanguageId", "LectureId" },
                values: new object[,]
                {
                    { new Guid("31afb526-2592-4229-93d0-3f7f7d01cc9f"), new Guid("8665c6cb-7dc0-4058-9bc7-7c65c7869d47"), new Guid("7e78b348-7834-44d3-ad9b-93155079e9be") },
                    { new Guid("50f43d5b-a914-4136-abda-becb65d9cdf1"), new Guid("48e36ba7-6216-4b19-a671-066c0f5a8e0a"), new Guid("7c36d05c-333e-4970-8377-e5c96d25578f") },
                    { new Guid("5c33be83-7643-4022-9bbf-b94777c0aefe"), new Guid("bcd4aaec-f236-451a-92eb-7642471c8ecc"), new Guid("7e78b348-7834-44d3-ad9b-93155079e9be") },
                    { new Guid("872a4c87-65be-4895-b462-32a2b05995b9"), new Guid("48e36ba7-6216-4b19-a671-066c0f5a8e0a"), new Guid("7e78b348-7834-44d3-ad9b-93155079e9be") },
                    { new Guid("a4f9586f-3da8-4526-b0c5-9031a663c931"), new Guid("3a9723c8-af2c-46b9-a4cd-bcb32f5a90b6"), new Guid("7c36d05c-333e-4970-8377-e5c96d25578f") },
                    { new Guid("b0dccbce-599b-44d5-af6b-c5c5ca96e3c9"), new Guid("3a9723c8-af2c-46b9-a4cd-bcb32f5a90b6"), new Guid("7e78b348-7834-44d3-ad9b-93155079e9be") },
                    { new Guid("b6a87691-5b93-4e17-a874-ece1e4f94f1e"), new Guid("8665c6cb-7dc0-4058-9bc7-7c65c7869d47"), new Guid("7c36d05c-333e-4970-8377-e5c96d25578f") },
                    { new Guid("d834e0e2-884d-4ba5-a86b-9e8384cb8d1a"), new Guid("bcd4aaec-f236-451a-92eb-7642471c8ecc"), new Guid("7c36d05c-333e-4970-8377-e5c96d25578f") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_ExerciseId",
                table: "Answer",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TestId",
                table: "Exercises",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_LectureProgrammingLanguages_LanguageId",
                table: "LectureProgrammingLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LectureProgrammingLanguages_LectureId",
                table: "LectureProgrammingLanguages",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_LectureProgrammingLanguageId",
                table: "Tests",
                column: "LectureProgrammingLanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "LectureProgrammingLanguages");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "ProgrammingLanguages");
        }
    }
}
