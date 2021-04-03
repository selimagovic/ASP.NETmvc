using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class deleteRemoveFKDeviceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceTypes_Devices_ParentId",
                table: "DeviceTypes");

            migrationBuilder.DropIndex(
                name: "IX_DeviceTypes_ParentId",
                table: "DeviceTypes");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "DeviceTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "DeviceTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceTypes_ParentId",
                table: "DeviceTypes",
                column: "ParentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceTypes_Devices_ParentId",
                table: "DeviceTypes",
                column: "ParentId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
