using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManagementSystem.Migrations;

/// <inheritdoc />
public partial class _20261116174215_InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Patients",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                FName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                LName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                Age = table.Column<int>(type: "int", nullable: false),
                Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                NationalId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Patients", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Specialties",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                CheckupPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                IsActive = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Specialties", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                IsActive = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Doctors",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                WorkingHours = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                UserId = table.Column<int>(type: "int", nullable: false),
                SpecialtyId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Doctors", x => x.Id);
                table.ForeignKey(
                    name: "FK_Doctors_Specialties_SpecialtyId",
                    column: x => x.SpecialtyId,
                    principalTable: "Specialties",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Doctors_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Appointments",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                AppointmentStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                IsPaid = table.Column<bool>(type: "bit", nullable: false),
                PatientId = table.Column<int>(type: "int", nullable: false),
                DoctorId = table.Column<int>(type: "int", nullable: false),
                CreatedByUserId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Appointments", x => x.Id);
                table.ForeignKey(
                    name: "FK_Appointments_Doctors_DoctorId",
                    column: x => x.DoctorId,
                    principalTable: "Doctors",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Appointments_Patients_PatientId",
                    column: x => x.PatientId,
                    principalTable: "Patients",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Appointments_Users_CreatedByUserId",
                    column: x => x.CreatedByUserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "MedicalRecords",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Symptoms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Prescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                DoctorNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                AppointmentId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MedicalRecords", x => x.Id);
                table.ForeignKey(
                    name: "FK_MedicalRecords_Appointments_AppointmentId",
                    column: x => x.AppointmentId,
                    principalTable: "Appointments",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Appointments_CreatedByUserId",
            table: "Appointments",
            column: "CreatedByUserId");

        migrationBuilder.CreateIndex(
            name: "IX_Appointments_DoctorId",
            table: "Appointments",
            column: "DoctorId");

        migrationBuilder.CreateIndex(
            name: "IX_Appointments_PatientId",
            table: "Appointments",
            column: "PatientId");

        migrationBuilder.CreateIndex(
            name: "IX_Doctors_SpecialtyId",
            table: "Doctors",
            column: "SpecialtyId");

        migrationBuilder.CreateIndex(
            name: "IX_Doctors_UserId",
            table: "Doctors",
            column: "UserId",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_MedicalRecords_AppointmentId",
            table: "MedicalRecords",
            column: "AppointmentId",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Patients_NationalId",
            table: "Patients",
            column: "NationalId",
            unique: true,
            filter: "[NationalId] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_Users_Email",
            table: "Users",
            column: "Email",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "MedicalRecords");

        migrationBuilder.DropTable(
            name: "Appointments");

        migrationBuilder.DropTable(
            name: "Doctors");

        migrationBuilder.DropTable(
            name: "Patients");

        migrationBuilder.DropTable(
            name: "Specialties");

        migrationBuilder.DropTable(
            name: "Users");
    }
}
