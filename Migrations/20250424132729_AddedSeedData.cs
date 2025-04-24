using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb3_API.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_PersonInterests_PersonInterestId",
                table: "Links");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonInterests",
                table: "PersonInterests");

            migrationBuilder.DropIndex(
                name: "IX_PersonInterests_PersonId",
                table: "PersonInterests");

            migrationBuilder.DropIndex(
                name: "IX_Links_PersonInterestId",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PersonInterests");

            migrationBuilder.RenameColumn(
                name: "PersonInterestId",
                table: "Links",
                newName: "PersonId");

            migrationBuilder.AddColumn<int>(
                name: "InterestId",
                table: "Links",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonInterests",
                table: "PersonInterests",
                columns: new[] { "PersonId", "InterestId" });

            migrationBuilder.CreateIndex(
                name: "IX_Links_PersonId_InterestId",
                table: "Links",
                columns: new[] { "PersonId", "InterestId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Links_PersonInterests_PersonId_InterestId",
                table: "Links",
                columns: new[] { "PersonId", "InterestId" },
                principalTable: "PersonInterests",
                principalColumns: new[] { "PersonId", "InterestId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_PersonInterests_PersonId_InterestId",
                table: "Links");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonInterests",
                table: "PersonInterests");

            migrationBuilder.DropIndex(
                name: "IX_Links_PersonId_InterestId",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "InterestId",
                table: "Links");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Links",
                newName: "PersonInterestId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PersonInterests",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonInterests",
                table: "PersonInterests",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_PersonId",
                table: "PersonInterests",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_PersonInterestId",
                table: "Links",
                column: "PersonInterestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_PersonInterests_PersonInterestId",
                table: "Links",
                column: "PersonInterestId",
                principalTable: "PersonInterests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
