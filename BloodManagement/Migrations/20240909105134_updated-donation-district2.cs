using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodManagement.Migrations
{
    /// <inheritdoc />
    public partial class updateddonationdistrict2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donors_BloodGroups_BloodGroupId",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Donors");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "DistrictId",
                table: "Donors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DonationId",
                table: "Donors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DonationId",
                table: "BloodGroups",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    districtId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    districtName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.districtId);
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    DonationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DonorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodGroupId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DonationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.DonationId);
                    table.ForeignKey(
                        name: "FK_Donations_BloodGroups_BloodGroupId",
                        column: x => x.BloodGroupId,
                        principalTable: "BloodGroups",
                        principalColumn: "BloodGroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Donations_Donors_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Donors",
                        principalColumn: "DonorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donors_DistrictId",
                table: "Donors",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Donors_DonationId",
                table: "Donors",
                column: "DonationId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodGroups_DonationId",
                table: "BloodGroups",
                column: "DonationId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_BloodGroupId",
                table: "Donations",
                column: "BloodGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_DonorId",
                table: "Donations",
                column: "DonorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodGroups_Donations_DonationId",
                table: "BloodGroups",
                column: "DonationId",
                principalTable: "Donations",
                principalColumn: "DonationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_BloodGroups_BloodGroupId",
                table: "Donors",
                column: "BloodGroupId",
                principalTable: "BloodGroups",
                principalColumn: "BloodGroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_Districts_DistrictId",
                table: "Donors",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "districtId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_Donations_DonationId",
                table: "Donors",
                column: "DonationId",
                principalTable: "Donations",
                principalColumn: "DonationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodGroups_Donations_DonationId",
                table: "BloodGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Donors_BloodGroups_BloodGroupId",
                table: "Donors");

            migrationBuilder.DropForeignKey(
                name: "FK_Donors_Districts_DistrictId",
                table: "Donors");

            migrationBuilder.DropForeignKey(
                name: "FK_Donors_Donations_DonationId",
                table: "Donors");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropIndex(
                name: "IX_Donors_DistrictId",
                table: "Donors");

            migrationBuilder.DropIndex(
                name: "IX_Donors_DonationId",
                table: "Donors");

            migrationBuilder.DropIndex(
                name: "IX_BloodGroups_DonationId",
                table: "BloodGroups");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "DonationId",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "DonationId",
                table: "BloodGroups");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_BloodGroups_BloodGroupId",
                table: "Donors",
                column: "BloodGroupId",
                principalTable: "BloodGroups",
                principalColumn: "BloodGroupId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
