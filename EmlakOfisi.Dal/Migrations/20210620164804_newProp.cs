using Microsoft.EntityFrameworkCore.Migrations;

namespace EmlakOfisi.Dal.Migrations
{
    public partial class newProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StateAds_AspNetUsers_UserId",
                table: "StateAds");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "StateAds",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StateAds_AspNetUsers_UserId",
                table: "StateAds",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StateAds_AspNetUsers_UserId",
                table: "StateAds");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "StateAds",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_StateAds_AspNetUsers_UserId",
                table: "StateAds",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
