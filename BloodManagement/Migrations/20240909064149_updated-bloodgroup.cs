using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodManagement.Migrations
{
    /// <inheritdoc />
    public partial class updatedbloodgroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DonornName",
                table: "Donors",
                newName: "PoliceStation");

            migrationBuilder.RenameColumn(
                name: "BloodGroup",
                table: "Donors",
                newName: "DonorName");

            migrationBuilder.AddColumn<string>(
                name: "BloodGroupId",
                table: "Donors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BloodGroups",
                columns: table => new
                {
                    BloodGroupId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodGroups", x => x.BloodGroupId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donors_BloodGroupId",
                table: "Donors",
                column: "BloodGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_BloodGroups_BloodGroupId",
                table: "Donors",
                column: "BloodGroupId",
                principalTable: "BloodGroups",
                principalColumn: "BloodGroupId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donors_BloodGroups_BloodGroupId",
                table: "Donors");

            migrationBuilder.DropTable(
                name: "BloodGroups");

            migrationBuilder.DropIndex(
                name: "IX_Donors_BloodGroupId",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "BloodGroupId",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Donors");

            migrationBuilder.RenameColumn(
                name: "PoliceStation",
                table: "Donors",
                newName: "DonornName");

            migrationBuilder.RenameColumn(
                name: "DonorName",
                table: "Donors",
                newName: "BloodGroup");
        }
    }
}
