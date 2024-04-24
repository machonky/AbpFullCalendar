using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbpFullCalendar.Migrations
{
    /// <inheritdoc />
    public partial class BusinessDay_UniqueIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_AppBusinessDays_BusinessDayId_TenantId",
                table: "AppBusinessDays");

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                table: "AppBusinessDays",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessDayId",
                table: "AppBusinessDays",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_AppBusinessDays_BusinessDayId_TenantId",
                table: "AppBusinessDays",
                columns: new[] { "BusinessDayId", "TenantId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppBusinessDays_BusinessDayId_TenantId",
                table: "AppBusinessDays");

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                table: "AppBusinessDays",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessDayId",
                table: "AppBusinessDays",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AppBusinessDays_BusinessDayId_TenantId",
                table: "AppBusinessDays",
                columns: new[] { "BusinessDayId", "TenantId" });
        }
    }
}
