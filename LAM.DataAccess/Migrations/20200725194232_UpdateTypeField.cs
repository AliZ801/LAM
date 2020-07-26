using Microsoft.EntityFrameworkCore.Migrations;

namespace LAM.DataAccess.Migrations
{
    public partial class UpdateTypeField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LType",
                table: "Leave");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Leave",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Leave_TypeId",
                table: "Leave",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leave_LType_TypeId",
                table: "Leave",
                column: "TypeId",
                principalTable: "LType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leave_LType_TypeId",
                table: "Leave");

            migrationBuilder.DropIndex(
                name: "IX_Leave_TypeId",
                table: "Leave");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Leave");

            migrationBuilder.AddColumn<string>(
                name: "LType",
                table: "Leave",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
