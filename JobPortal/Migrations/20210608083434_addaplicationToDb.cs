using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortal.Migrations
{
    public partial class addaplicationToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Profile = table.Column<string>(nullable: true),
                    PlacePosting = table.Column<string>(nullable: true),
                    PostAppliedFor = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    FatherName = table.Column<string>(nullable: true),
                    DateofBirth = table.Column<DateTime>(nullable: false),
                    Age = table.Column<DateTime>(nullable: false),
                    CNIC = table.Column<string>(nullable: true),
                    Domicile = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    Contact1 = table.Column<string>(nullable: true),
                    PostalAddress = table.Column<string>(nullable: true),
                    PermanentAddress = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    GovtService = table.Column<bool>(nullable: false),
                    GovtCertificate = table.Column<string>(nullable: true),
                    DisabilityCertificate = table.Column<string>(nullable: true),
                    Disability = table.Column<bool>(nullable: false),
                    HafizeQuranCerticate = table.Column<string>(nullable: true),
                    HafizeQuran = table.Column<bool>(nullable: false),
                    Religion = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    MartialStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");
        }
    }
}
