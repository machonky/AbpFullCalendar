using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbpFullCalendar.Migrations
{
    /// <inheritdoc />
    public partial class Remove_BusinessDay_SoftDeletes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppBusinessDays");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppBusinessDays");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppBusinessDays");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "AppBusinessDays");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "AppBusinessDays");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "AppBusinessDays",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AppBusinessDays",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppBusinessDays",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "AppBusinessDays",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "AppBusinessDays",
                type: "uuid",
                nullable: true);
        }
    }
}
