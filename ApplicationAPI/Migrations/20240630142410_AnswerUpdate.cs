using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationAPI.Migrations
{
    public partial class AnswerUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "Answer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "LectureProgrammingLanguages",
                columns: new[] { "LectureProgrammingLanguageId", "LanguageId", "LectureId" },
                values: new object[,]
                {
                    { new Guid("03393a25-ec23-4bdb-b184-3e5d0bc2fe35"), new Guid("8665c6cb-7dc0-4058-9bc7-7c65c7869d47"), new Guid("7e78b348-7834-44d3-ad9b-93155079e9be") },
                    { new Guid("19c68284-a3fa-402d-a1f4-5649b8c18b08"), new Guid("48e36ba7-6216-4b19-a671-066c0f5a8e0a"), new Guid("7e78b348-7834-44d3-ad9b-93155079e9be") },
                    { new Guid("20cf18f8-c473-4004-86ed-25fe37c01d1b"), new Guid("bcd4aaec-f236-451a-92eb-7642471c8ecc"), new Guid("7c36d05c-333e-4970-8377-e5c96d25578f") },
                    { new Guid("50118750-3894-4cb0-86c0-f6b3610a2be1"), new Guid("3a9723c8-af2c-46b9-a4cd-bcb32f5a90b6"), new Guid("7c36d05c-333e-4970-8377-e5c96d25578f") },
                    { new Guid("90b4f57a-18f5-488a-b845-bd00aaa996d0"), new Guid("3a9723c8-af2c-46b9-a4cd-bcb32f5a90b6"), new Guid("7e78b348-7834-44d3-ad9b-93155079e9be") },
                    { new Guid("a1a3437c-e0e8-464e-952e-3b4cc39c665b"), new Guid("8665c6cb-7dc0-4058-9bc7-7c65c7869d47"), new Guid("7c36d05c-333e-4970-8377-e5c96d25578f") },
                    { new Guid("af420390-3b21-4027-94a4-671fbd55af83"), new Guid("bcd4aaec-f236-451a-92eb-7642471c8ecc"), new Guid("7e78b348-7834-44d3-ad9b-93155079e9be") },
                    { new Guid("e0e6a27c-e642-4aff-9dd4-549d073ac5a6"), new Guid("48e36ba7-6216-4b19-a671-066c0f5a8e0a"), new Guid("7c36d05c-333e-4970-8377-e5c96d25578f") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("03393a25-ec23-4bdb-b184-3e5d0bc2fe35"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("19c68284-a3fa-402d-a1f4-5649b8c18b08"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("20cf18f8-c473-4004-86ed-25fe37c01d1b"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("50118750-3894-4cb0-86c0-f6b3610a2be1"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("90b4f57a-18f5-488a-b845-bd00aaa996d0"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("a1a3437c-e0e8-464e-952e-3b4cc39c665b"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("af420390-3b21-4027-94a4-671fbd55af83"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("e0e6a27c-e642-4aff-9dd4-549d073ac5a6"));

            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "Answer");

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
    }
}
