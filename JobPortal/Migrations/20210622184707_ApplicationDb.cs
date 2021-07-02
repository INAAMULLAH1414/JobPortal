using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortal.Migrations
{
    public partial class ApplicationDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisabilityCertificate",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "GovtCertificate",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "HafizeQuranCerticate",
                table: "Applications");

            migrationBuilder.AlterColumn<string>(
                name: "HafizeQuran",
                table: "Applications",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "GovtService",
                table: "Applications",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Disability",
                table: "Applications",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "HafizeQuran",
                table: "Applications",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<bool>(
                name: "GovtService",
                table: "Applications",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<bool>(
                name: "Disability",
                table: "Applications",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "DisabilityCertificate",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GovtCertificate",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HafizeQuranCerticate",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
