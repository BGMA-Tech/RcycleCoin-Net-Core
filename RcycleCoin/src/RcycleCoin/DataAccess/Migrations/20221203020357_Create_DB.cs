using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Create_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecycleType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecycleTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecycleType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecycleProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecycleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RecyclePoint = table.Column<int>(type: "int", nullable: false),
                    RecycleTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecycleProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecycleProduct_RecycleType_RecycleTypeId",
                        column: x => x.RecycleTypeId,
                        principalTable: "RecycleType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRecycleProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RecycleProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRecycleProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRecycleProduct_RecycleProduct_RecycleProductId",
                        column: x => x.RecycleProductId,
                        principalTable: "RecycleProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecycleProduct_RecycleTypeId",
                table: "RecycleProduct",
                column: "RecycleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRecycleProduct_RecycleProductId",
                table: "UserRecycleProduct",
                column: "RecycleProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRecycleProduct");

            migrationBuilder.DropTable(
                name: "RecycleProduct");

            migrationBuilder.DropTable(
                name: "RecycleType");
        }
    }
}
