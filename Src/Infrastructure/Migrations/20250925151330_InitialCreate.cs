using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerosnID = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(20)",maxLength:20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MidName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_People_Contacts_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Contacts",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    TenantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.TenantId);
                    table.ForeignKey(
                        name: "FK_Tenants_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                    table.ForeignKey(
                        name: "FK_Admins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ManagerId);
                    table.ForeignKey(
                        name: "FK_Managers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Email", "PerosnID", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Sabri@gmail.com", 1, "0659861234" },
                    { 2, "Sabri22@gmail.com", 1, "0667234678" },
                    { 3, "Mohamed12@yahoo.com", 2, "0577539612" },
                    { 4, "Khalifa225@yahoo.com", 3, "0577134689" },
                    { 5, "BenSalim45@yahoo.com", 4, "0577530100" },
                    { 6, "Salma@gmial.com", 5, "0577339812" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Birthday", "FirstName", "LastName", "MidName" },
                values: new object[,]
                {
                    { 1, new DateOnly(2001, 8, 27), "Sabri", "Zekkour Ferhat", null },
                    { 2, new DateOnly(2002, 1, 10), "Mohammed", "Ali", null },
                    { 3, new DateOnly(1985, 11, 22), "Khalifa", "Abu-Salah", null },
                    { 4, new DateOnly(1970, 3, 15), "BenSalim", "Sahraoui", null },
                    { 5, new DateOnly(1993, 6, 1), "Salma", "Tdjany", null }
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "PersonId" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreateAt", "IsActive", "Password", "PersonId", "UpdateAt", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 20, 10, 22, 9, 0, DateTimeKind.Unspecified), true, "1234", 1, null, "Admin" },
                    { 2, new DateTime(2025, 8, 5, 18, 6, 45, 0, DateTimeKind.Unspecified), true, "absd", 2, null, "@Mo_15" },
                    { 3, new DateTime(2025, 8, 10, 0, 22, 1, 0, DateTimeKind.Unspecified), false, "Ka123", 3, null, "@Kalif_125" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "ManagerId", "UserId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserId",
                table: "Admins",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Managers_UserId",
                table: "Managers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_PersonId",
                table: "Tenants",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
