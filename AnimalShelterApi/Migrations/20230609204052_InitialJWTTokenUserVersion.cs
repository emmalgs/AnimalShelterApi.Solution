using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimaShelterApi.Migrations
{
    public partial class InitialJWTTokenUserVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Breed = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Available = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateAdmitted = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailAddress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GivenName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Available", "Breed", "DateAdmitted", "Name", "Type" },
                values: new object[,]
                {
                    { 1, true, "Scruffy", new DateTime(2018, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scratchy", "Cat" },
                    { 2, true, "Beagle/Sneaky", new DateTime(2022, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cranko", "Dog" },
                    { 3, false, "Feathered", new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sporty", "Bird" },
                    { 4, true, "Foxhound", new DateTime(2022, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stanley", "Dog" },
                    { 5, true, "Tabby/Stinky", new DateTime(2022, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Borgus", "Cat" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "EmailAddress", "GivenName", "Password", "Role", "Surname", "Username" },
                values: new object[,]
                {
                    { 1, "gogo@rob.com", "Gogo", "eggs", "Adminstrator", "Robinson", "gogorobinson" },
                    { 2, "stever@rob.com", "Stever", "eggs2", "Standard", "Scorpion", "stever" },
                    { 3, "dread@rob.com", "Dread", "eggs3", "Standard", "Veil", "dread" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
