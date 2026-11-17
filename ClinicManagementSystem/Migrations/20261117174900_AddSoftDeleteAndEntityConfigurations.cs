using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManagementSystem.Migrations;

/// <inheritdoc />
public partial class _20261117174900_AddSoftDeleteAndEntityConfigurations : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Doctors_Specialties_SpecialtyId",
            table: "Doctors");

        migrationBuilder.AddColumn<bool>(
            name: "IsDeleted",
            table: "Doctors",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddForeignKey(
            name: "FK_Doctors_Specialties_SpecialtyId",
            table: "Doctors",
            column: "SpecialtyId",
            principalTable: "Specialties",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Doctors_Specialties_SpecialtyId",
            table: "Doctors");

        migrationBuilder.DropColumn(
            name: "IsDeleted",
            table: "Doctors");

        migrationBuilder.AddForeignKey(
            name: "FK_Doctors_Specialties_SpecialtyId",
            table: "Doctors",
            column: "SpecialtyId",
            principalTable: "Specialties",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}
