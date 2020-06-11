using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tut12.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Confectionery",
                columns: new[] { "IdConfectionery", "Name", "PricePerItem", "Type" },
                values: new object[,]
                {
                    { 1, "Macaron", 5f, "type1" },
                    { 2, "Cake", 7.5f, "type2" },
                    { 3, "Cookies", 3.5f, "type3" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "IdClient", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "Aysenur", "Ozgur" },
                    { 2, "Merve", "Unal" },
                    { 3, "Busra", "Yilmaz" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "IdEmployee", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "Reyhan", "Ozgur" },
                    { 2, "Simal", "Can" },
                    { 3, "Ali", "Yilmaz" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "IdOrder", "DateAccepted", "DateFinished", "IdClient", "IdEmployee", "Notes" },
                values: new object[] { 1, new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "note1" });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "IdOrder", "DateAccepted", "DateFinished", "IdClient", "IdEmployee", "Notes" },
                values: new object[] { 2, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "note2" });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "IdOrder", "DateAccepted", "DateFinished", "IdClient", "IdEmployee", "Notes" },
                values: new object[] { 3, new DateTime(2020, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, "note3" });

            migrationBuilder.InsertData(
                table: "Confectionery_Order",
                columns: new[] { "IdConfectionery", "IdOrder", "Notes", "Quantity" },
                values: new object[] { 1, 1, "note1", 25 });

            migrationBuilder.InsertData(
                table: "Confectionery_Order",
                columns: new[] { "IdConfectionery", "IdOrder", "Notes", "Quantity" },
                values: new object[] { 2, 2, "note2", 30 });

            migrationBuilder.InsertData(
                table: "Confectionery_Order",
                columns: new[] { "IdConfectionery", "IdOrder", "Notes", "Quantity" },
                values: new object[] { 3, 3, "note3", 20 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Confectionery_Order",
                keyColumns: new[] { "IdConfectionery", "IdOrder" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Confectionery_Order",
                keyColumns: new[] { "IdConfectionery", "IdOrder" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Confectionery_Order",
                keyColumns: new[] { "IdConfectionery", "IdOrder" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Confectionery",
                keyColumn: "IdConfectionery",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Confectionery",
                keyColumn: "IdConfectionery",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Confectionery",
                keyColumn: "IdConfectionery",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "IdOrder",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "IdOrder",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "IdOrder",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "IdClient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "IdClient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "IdClient",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "IdEmployee",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "IdEmployee",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "IdEmployee",
                keyValue: 3);
        }
    }
}
