using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab10.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "doctor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "medicament",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicament", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "prescription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPatient = table.Column<int>(type: "int", nullable: false),
                    IdDoctor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_prescription_doctor_IdDoctor",
                        column: x => x.IdDoctor,
                        principalTable: "doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prescription_patient_IdPatient",
                        column: x => x.IdPatient,
                        principalTable: "patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prescription_medicament",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(type: "int", nullable: false),
                    IdPrescription = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescription_medicament", x => new { x.IdMedicament, x.IdPrescription });
                    table.ForeignKey(
                        name: "FK_prescription_medicament_medicament_IdMedicament",
                        column: x => x.IdMedicament,
                        principalTable: "medicament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prescription_medicament_prescription_IdPrescription",
                        column: x => x.IdPrescription,
                        principalTable: "prescription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "doctor",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[] { 1, "antonbaton@gmail.com", "Anton", "Baton" });

            migrationBuilder.InsertData(
                table: "medicament",
                columns: new[] { "Id", "Description", "Name", "Type" },
                values: new object[] { 1, "Ibuprofen is a drug that is used to relieve pain, fever, and inflammation", "Ibuprofen", "anti-inflammatory" });

            migrationBuilder.InsertData(
                table: "patient",
                columns: new[] { "Id", "Birthdate", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(2003, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vladyslav", "Miekh" });

            migrationBuilder.InsertData(
                table: "prescription",
                columns: new[] { "Id", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 1, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "prescription_medicament",
                columns: new[] { "IdMedicament", "IdPrescription", "Details" },
                values: new object[] { 1, 1, "Get better mate" });

            migrationBuilder.CreateIndex(
                name: "IX_prescription_IdDoctor",
                table: "prescription",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_prescription_IdPatient",
                table: "prescription",
                column: "IdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_prescription_medicament_IdPrescription",
                table: "prescription_medicament",
                column: "IdPrescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "prescription_medicament");

            migrationBuilder.DropTable(
                name: "medicament");

            migrationBuilder.DropTable(
                name: "prescription");

            migrationBuilder.DropTable(
                name: "doctor");

            migrationBuilder.DropTable(
                name: "patient");
        }
    }
}
