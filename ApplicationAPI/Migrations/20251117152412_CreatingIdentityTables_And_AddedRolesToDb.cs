using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationAPI.Migrations
{
    public partial class CreatingIdentityTables_And_AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b549254-d114-4132-b4f2-2e606080e507", "92465c40-315d-4f37-ab18-2f53b62434a8", "Administrator", "ADMINISTRATOR" },
                    { "23763795-6463-49b2-bc48-1348ce231ab0", "9bf679d1-7533-4603-a95d-1a6ad19387bb", "User", "USER" }
                });

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

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "LectureId",
                keyValue: new Guid("7c36d05c-333e-4970-8377-e5c96d25578f"),
                column: "LectureDescription",
                value: "Some Description.");

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "LectureId",
                keyValue: new Guid("7e78b348-7834-44d3-ad9b-93155079e9be"),
                column: "LectureDescription",
                value: "Some Description.");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "LectureId",
                keyValue: new Guid("7c36d05c-333e-4970-8377-e5c96d25578f"),
                column: "LectureDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "LectureId",
                keyValue: new Guid("7e78b348-7834-44d3-ad9b-93155079e9be"),
                column: "LectureDescription",
                value: null);
        }
    }
}
