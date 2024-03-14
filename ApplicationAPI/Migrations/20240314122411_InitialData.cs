using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationAPI.Migrations
{
    public partial class InitialData : Migration
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
                    LectureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureProgrammingLanguages", x => new { x.LectureId, x.LanguageId });
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
                columns: new[] { "LanguageId", "LectureId" },
                values: new object[,]
                {
                    { new Guid("3a9723c8-af2c-46b9-a4cd-bcb32f5a90b6"), new Guid("7c36d05c-333e-4970-8377-e5c96d25578f") },
                    { new Guid("48e36ba7-6216-4b19-a671-066c0f5a8e0a"), new Guid("7c36d05c-333e-4970-8377-e5c96d25578f") },
                    { new Guid("8665c6cb-7dc0-4058-9bc7-7c65c7869d47"), new Guid("7c36d05c-333e-4970-8377-e5c96d25578f") },
                    { new Guid("bcd4aaec-f236-451a-92eb-7642471c8ecc"), new Guid("7c36d05c-333e-4970-8377-e5c96d25578f") },
                    { new Guid("3a9723c8-af2c-46b9-a4cd-bcb32f5a90b6"), new Guid("7e78b348-7834-44d3-ad9b-93155079e9be") },
                    { new Guid("48e36ba7-6216-4b19-a671-066c0f5a8e0a"), new Guid("7e78b348-7834-44d3-ad9b-93155079e9be") },
                    { new Guid("8665c6cb-7dc0-4058-9bc7-7c65c7869d47"), new Guid("7e78b348-7834-44d3-ad9b-93155079e9be") },
                    { new Guid("bcd4aaec-f236-451a-92eb-7642471c8ecc"), new Guid("7e78b348-7834-44d3-ad9b-93155079e9be") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LectureProgrammingLanguages_LanguageId",
                table: "LectureProgrammingLanguages",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LectureProgrammingLanguages");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "ProgrammingLanguages");
        }
    }
}
