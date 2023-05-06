using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_Labb4.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestID);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterestID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkID);
                    table.ForeignKey(
                        name: "FK_Links_Interests_InterestID",
                        column: x => x.InterestID,
                        principalTable: "Interests",
                        principalColumn: "InterestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonInterests",
                columns: table => new
                {
                    PersonInterestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    InterestID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInterests", x => x.PersonInterestID);
                    table.ForeignKey(
                        name: "FK_PersonInterests_Interests_InterestID",
                        column: x => x.InterestID,
                        principalTable: "Interests",
                        principalColumn: "InterestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonInterests_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Move that body", "Dancing" },
                    { 2, "Play games", "Gaming" },
                    { 3, "Hunting while standing still", "Fishing" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonID", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "attorney@law.com", "Justin Case", "0735466834" },
                    { 2, "patrikskattberg@fakemail.com", "Patrik Skattberg", "0761960876" },
                    { 3, "thismail@mail.com", "Mark Hammil", "0737754669" }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "LinkID", "InterestID", "URL" },
                values: new object[,]
                {
                    { 1, 1, "https://www.youtube.com/watch?v=aKv54g_v1mo&list=RD71XngoEKuGk&index=8" },
                    { 2, 2, "https://store.steampowered.com/" },
                    { 3, 3, "https://en.wikipedia.org/wiki/Fishing" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_InterestID",
                table: "Links",
                column: "InterestID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_InterestID",
                table: "PersonInterests",
                column: "InterestID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_PersonID",
                table: "PersonInterests",
                column: "PersonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "PersonInterests");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
