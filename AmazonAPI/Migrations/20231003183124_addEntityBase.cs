using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmazonAPI.Migrations
{
    public partial class addEntityBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WishListItems",
                table: "WishListItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "WishListItems",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishListItems",
                table: "WishListItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_WishListItems_CustomerId",
                table: "WishListItems",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CustomerId",
                table: "CartItems",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WishListItems",
                table: "WishListItems");

            migrationBuilder.DropIndex(
                name: "IX_WishListItems_CustomerId",
                table: "WishListItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_CustomerId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "WishListItems");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CartItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishListItems",
                table: "WishListItems",
                columns: new[] { "CustomerId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems",
                columns: new[] { "CustomerId", "ProductId" });
        }
    }
}
