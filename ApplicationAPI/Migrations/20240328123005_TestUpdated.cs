using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationAPI.Migrations
{
    public partial class TestUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("31afb526-2592-4229-93d0-3f7f7d01cc9f"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("50f43d5b-a914-4136-abda-becb65d9cdf1"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("5c33be83-7643-4022-9bbf-b94777c0aefe"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("872a4c87-65be-4895-b462-32a2b05995b9"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("a4f9586f-3da8-4526-b0c5-9031a663c931"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("b0dccbce-599b-44d5-af6b-c5c5ca96e3c9"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("b6a87691-5b93-4e17-a874-ece1e4f94f1e"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("d834e0e2-884d-4ba5-a86b-9e8384cb8d1a"));

            migrationBuilder.RenameColumn(
                name: "Option",
                table: "Answer",
                newName: "Content");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TestName",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExerciseDescription",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "LectureProgrammingLanguages",
                columns: new[] { "LectureProgrammingLanguageId", "LanguageId", "LectureId" },
                values: new object[,]
                {
                    { new Guid("0f2f5d51-5703-4b8b-bf83-cc0911499038"), new Guid("3a9723c8-af2c-46b9-a4cd-bcb32f5a90b6"), new Guid("7e78b348-7834-44d3-ad9b-93155079e9be") },
                    { new Guid("170c7f74-cca2-44a0-87d9-5d2d7be21b6e"), new Guid("48e36ba7-6216-4b19-a671-066c0f5a8e0a"), new Guid("7c36d05c-333e-4970-8377-e5c96d25578f") },
                    { new Guid("46519ca8-18f9-4bc6-89fc-0f23d5112915"), new Guid("bcd4aaec-f236-451a-92eb-7642471c8ecc"), new Guid("7c36d05c-333e-4970-8377-e5c96d25578f") },
                    { new Guid("527de6ee-2bfc-481e-9560-611cfc50817d"), new Guid("8665c6cb-7dc0-4058-9bc7-7c65c7869d47"), new Guid("7c36d05c-333e-4970-8377-e5c96d25578f") },
                    { new Guid("a0b21428-ae2b-4ce3-8664-4fcc76627c1b"), new Guid("bcd4aaec-f236-451a-92eb-7642471c8ecc"), new Guid("7e78b348-7834-44d3-ad9b-93155079e9be") },
                    { new Guid("af8b17bf-f77d-48fb-a456-0e419aa94e67"), new Guid("3a9723c8-af2c-46b9-a4cd-bcb32f5a90b6"), new Guid("7c36d05c-333e-4970-8377-e5c96d25578f") },
                    { new Guid("beb9d4c5-3c96-4c76-bad6-ea651d584941"), new Guid("8665c6cb-7dc0-4058-9bc7-7c65c7869d47"), new Guid("7e78b348-7834-44d3-ad9b-93155079e9be") },
                    { new Guid("ffae9f11-e408-43cf-90c7-7c730bc405e1"), new Guid("48e36ba7-6216-4b19-a671-066c0f5a8e0a"), new Guid("7e78b348-7834-44d3-ad9b-93155079e9be") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("0f2f5d51-5703-4b8b-bf83-cc0911499038"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("170c7f74-cca2-44a0-87d9-5d2d7be21b6e"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("46519ca8-18f9-4bc6-89fc-0f23d5112915"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("527de6ee-2bfc-481e-9560-611cfc50817d"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("a0b21428-ae2b-4ce3-8664-4fcc76627c1b"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("af8b17bf-f77d-48fb-a456-0e419aa94e67"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("beb9d4c5-3c96-4c76-bad6-ea651d584941"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("ffae9f11-e408-43cf-90c7-7c730bc405e1"));

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "TestName",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "ExerciseDescription",
                table: "Exercises");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Answer",
                newName: "Option");

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
        }
    }
}
