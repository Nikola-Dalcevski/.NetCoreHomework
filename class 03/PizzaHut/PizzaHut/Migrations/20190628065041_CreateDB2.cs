using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaHut.Migrations
{
    public partial class CreateDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_UserID",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DeleteData(
                table: "PizzaTypes",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PizzaTypes",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PizzaTypes",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "ID");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Address", "City", "Email", "Name", "Phone" },
                values: new object[] { 1, "main street", "Skopje", "nikola@gmail", "Nikola", "2222" });

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_UserID",
                table: "Order",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_UserID",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "ID");

            migrationBuilder.InsertData(
                table: "PizzaTypes",
                columns: new[] { "ID", "Description", "Name", "Photo" },
                values: new object[] { 1, "dough, ham, mashrums", "Capri", null });

            migrationBuilder.InsertData(
                table: "PizzaTypes",
                columns: new[] { "ID", "Description", "Name", "Photo" },
                values: new object[] { 2, "dough, chees, mashrums", "Quatro", null });

            migrationBuilder.InsertData(
                table: "PizzaTypes",
                columns: new[] { "ID", "Description", "Name", "Photo" },
                values: new object[] { 3, "dough, vegetables, mashrums", "Vege", null });

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_UserID",
                table: "Order",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
