using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Update_Recycle_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecycleProduct_RecycleProductImage_RecycleProductImageId",
                table: "RecycleProduct");

            migrationBuilder.DropIndex(
                name: "IX_RecycleProduct_RecycleProductImageId",
                table: "RecycleProduct");

            migrationBuilder.DropColumn(
                name: "RecycleProductImageId",
                table: "RecycleProduct");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecycleProductImageId",
                table: "RecycleProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RecycleProduct_RecycleProductImageId",
                table: "RecycleProduct",
                column: "RecycleProductImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecycleProduct_RecycleProductImage_RecycleProductImageId",
                table: "RecycleProduct",
                column: "RecycleProductImageId",
                principalTable: "RecycleProductImage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
