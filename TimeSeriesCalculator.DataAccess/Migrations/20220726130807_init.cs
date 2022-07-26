using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeSeriesCalculator.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeSeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    P1 = table.Column<double>(type: "float", nullable: false),
                    P3 = table.Column<double>(type: "float", nullable: false),
                    P5 = table.Column<double>(type: "float", nullable: false),
                    P10 = table.Column<double>(type: "float", nullable: false),
                    P15 = table.Column<double>(type: "float", nullable: false),
                    P25 = table.Column<double>(type: "float", nullable: false),
                    P50 = table.Column<double>(type: "float", nullable: false),
                    P75 = table.Column<double>(type: "float", nullable: false),
                    P85 = table.Column<double>(type: "float", nullable: false),
                    P90 = table.Column<double>(type: "float", nullable: false),
                    P95 = table.Column<double>(type: "float", nullable: false),
                    P97 = table.Column<double>(type: "float", nullable: false),
                    P99 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSeries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZTimeSeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    SD3neg = table.Column<double>(type: "float", nullable: false),
                    SD2neg = table.Column<double>(type: "float", nullable: false),
                    SD1neg = table.Column<double>(type: "float", nullable: false),
                    SD0 = table.Column<double>(type: "float", nullable: false),
                    SD1 = table.Column<double>(type: "float", nullable: false),
                    SD2 = table.Column<double>(type: "float", nullable: false),
                    SD3 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZTimeSeries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientChildren",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientChildren", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientChildren_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSeriesHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TryingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    PatientChildId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSeriesHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSeriesHistories_PatientChildren_PatientChildId",
                        column: x => x.PatientChildId,
                        principalTable: "PatientChildren",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientChildren_PatientId",
                table: "PatientChildren",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSeriesHistories_PatientChildId",
                table: "TimeSeriesHistories",
                column: "PatientChildId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeSeries");

            migrationBuilder.DropTable(
                name: "TimeSeriesHistories");

            migrationBuilder.DropTable(
                name: "ZTimeSeries");

            migrationBuilder.DropTable(
                name: "PatientChildren");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
