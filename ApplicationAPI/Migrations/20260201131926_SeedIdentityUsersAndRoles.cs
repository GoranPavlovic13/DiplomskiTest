using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationAPI.Migrations
{
    public partial class SeedIdentityUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("1d03852e-6f0b-4514-98d2-e56157fcc590"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("271835cf-cd8c-4c3e-8d55-a188e2e30620"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("60a26c35-b7ea-4ccc-b64f-f70ded9706d5"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("629c6c3d-ca0e-4c29-8914-c273429de6ff"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("891df6dc-9a4d-4b7e-a04a-3aca702c239a"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("c4e2c461-2e36-44b3-88c1-a2a25f9019c7"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("f2469c1b-540f-4e74-a311-73507239aadb"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("f700e4eb-c07f-43d8-9675-42d4455b968f"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b549254-d114-4132-b4f2-2e606080e507",
                column: "ConcurrencyStamp",
                value: "b4455b11-5ca6-4b06-94e2-421a759dbb04");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23763795-6463-49b2-bc48-1348ce231ab0",
                column: "ConcurrencyStamp",
                value: "cbcc2410-a358-45c1-bf20-c07763f4e737");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a3da7156-4cca-44c8-ac03-2d6995589237", 0, "90bc5ebe-27cf-4f20-a969-dd1823e3dcb0", "user@test.com", true, "Basic", "User", false, null, "USER@TEST.COM", "USER", "AQAAAAEAACcQAAAAEHMgNlTJvpDGJVTe61wq3RR1O2f0TteTHqzJUD00XBFWlMoQ9XYD9P101pK6k0hCjg==", null, false, "127f26d4-21c1-4056-b545-9531ee7c982c", false, "user" },
                    { "f0091af6-14ee-4c5e-b913-30f987bac393", 0, "b31df396-439a-4bb0-839b-1459b47a897f", "admin@test.com", true, "System", "Administrator", false, null, "ADMIN@TEST.COM", "ADMIN", "AQAAAAEAACcQAAAAEPn31T7ZRlMTRN6mE2K9N7QuD9qfnrt/zdDTh6k7hvm37xFSyDhDfpHpcj+K+lZc7w==", null, false, "499dca4d-8888-4d90-be11-50733e3cb42b", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "LectureProgrammingLanguages",
                columns: new[] { "LectureProgrammingLanguageId", "LanguageId", "LectureId" },
                values: new object[,]
                {
                    { new Guid("1699efb5-0875-4b08-91de-0c62ad8767ef"), new Guid("48e36ba7-6216-4b19-a671-066c0f5a8e0a"), new Guid("7c36d05c-333e-4970-8377-e5c96d25578f") },
                    { new Guid("308a118a-6f6a-440c-afa2-88895049e6ca"), new Guid("8665c6cb-7dc0-4058-9bc7-7c65c7869d47"), new Guid("7e78b348-7834-44d3-ad9b-93155079e9be") },
                    { new Guid("61f7059c-734a-4496-8d80-b83f07b967b1"), new Guid("48e36ba7-6216-4b19-a671-066c0f5a8e0a"), new Guid("7e78b348-7834-44d3-ad9b-93155079e9be") },
                    { new Guid("9e7a5855-785b-4bc7-9251-28db028fd706"), new Guid("bcd4aaec-f236-451a-92eb-7642471c8ecc"), new Guid("7e78b348-7834-44d3-ad9b-93155079e9be") },
                    { new Guid("d1fcf51a-06d8-43f2-9434-d0d36528bb5e"), new Guid("bcd4aaec-f236-451a-92eb-7642471c8ecc"), new Guid("7c36d05c-333e-4970-8377-e5c96d25578f") },
                    { new Guid("f0cc5ad3-f0a7-462c-9ebc-52638be5b74c"), new Guid("3a9723c8-af2c-46b9-a4cd-bcb32f5a90b6"), new Guid("7c36d05c-333e-4970-8377-e5c96d25578f") },
                    { new Guid("f11956ae-db05-466e-bde0-471115927e09"), new Guid("3a9723c8-af2c-46b9-a4cd-bcb32f5a90b6"), new Guid("7e78b348-7834-44d3-ad9b-93155079e9be") },
                    { new Guid("fbd37832-32a2-4939-87d2-3189070538a8"), new Guid("8665c6cb-7dc0-4058-9bc7-7c65c7869d47"), new Guid("7c36d05c-333e-4970-8377-e5c96d25578f") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "23763795-6463-49b2-bc48-1348ce231ab0", "a3da7156-4cca-44c8-ac03-2d6995589237" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0b549254-d114-4132-b4f2-2e606080e507", "f0091af6-14ee-4c5e-b913-30f987bac393" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "23763795-6463-49b2-bc48-1348ce231ab0", "a3da7156-4cca-44c8-ac03-2d6995589237" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0b549254-d114-4132-b4f2-2e606080e507", "f0091af6-14ee-4c5e-b913-30f987bac393" });

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("1699efb5-0875-4b08-91de-0c62ad8767ef"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("308a118a-6f6a-440c-afa2-88895049e6ca"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("61f7059c-734a-4496-8d80-b83f07b967b1"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("9e7a5855-785b-4bc7-9251-28db028fd706"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("d1fcf51a-06d8-43f2-9434-d0d36528bb5e"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("f0cc5ad3-f0a7-462c-9ebc-52638be5b74c"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("f11956ae-db05-466e-bde0-471115927e09"));

            migrationBuilder.DeleteData(
                table: "LectureProgrammingLanguages",
                keyColumn: "LectureProgrammingLanguageId",
                keyValue: new Guid("fbd37832-32a2-4939-87d2-3189070538a8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3da7156-4cca-44c8-ac03-2d6995589237");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0091af6-14ee-4c5e-b913-30f987bac393");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b549254-d114-4132-b4f2-2e606080e507",
                column: "ConcurrencyStamp",
                value: "92465c40-315d-4f37-ab18-2f53b62434a8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23763795-6463-49b2-bc48-1348ce231ab0",
                column: "ConcurrencyStamp",
                value: "9bf679d1-7533-4603-a95d-1a6ad19387bb");

            migrationBuilder.InsertData(
                table: "LectureProgrammingLanguages",
                columns: new[] { "LectureProgrammingLanguageId", "LanguageId", "LectureId" },
                values: new object[,]
                {
                    { new Guid("1d03852e-6f0b-4514-98d2-e56157fcc590"), new Guid("8665c6cb-7dc0-4058-9bc7-7c65c7869d47"), new Guid("7e78b348-7834-44d3-ad9b-93155079e9be") },
                    { new Guid("271835cf-cd8c-4c3e-8d55-a188e2e30620"), new Guid("3a9723c8-af2c-46b9-a4cd-bcb32f5a90b6"), new Guid("7c36d05c-333e-4970-8377-e5c96d25578f") },
                    { new Guid("60a26c35-b7ea-4ccc-b64f-f70ded9706d5"), new Guid("bcd4aaec-f236-451a-92eb-7642471c8ecc"), new Guid("7c36d05c-333e-4970-8377-e5c96d25578f") },
                    { new Guid("629c6c3d-ca0e-4c29-8914-c273429de6ff"), new Guid("3a9723c8-af2c-46b9-a4cd-bcb32f5a90b6"), new Guid("7e78b348-7834-44d3-ad9b-93155079e9be") },
                    { new Guid("891df6dc-9a4d-4b7e-a04a-3aca702c239a"), new Guid("48e36ba7-6216-4b19-a671-066c0f5a8e0a"), new Guid("7e78b348-7834-44d3-ad9b-93155079e9be") },
                    { new Guid("c4e2c461-2e36-44b3-88c1-a2a25f9019c7"), new Guid("48e36ba7-6216-4b19-a671-066c0f5a8e0a"), new Guid("7c36d05c-333e-4970-8377-e5c96d25578f") },
                    { new Guid("f2469c1b-540f-4e74-a311-73507239aadb"), new Guid("bcd4aaec-f236-451a-92eb-7642471c8ecc"), new Guid("7e78b348-7834-44d3-ad9b-93155079e9be") },
                    { new Guid("f700e4eb-c07f-43d8-9675-42d4455b968f"), new Guid("8665c6cb-7dc0-4058-9bc7-7c65c7869d47"), new Guid("7c36d05c-333e-4970-8377-e5c96d25578f") }
                });
        }
    }
}
