using Microsoft.EntityFrameworkCore.Migrations;

namespace ParksApi.Migrations
{
    public partial class SeedJoinEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LocalWildlife",
                columns: new[] { "LocalWildlifeId", "AnimalId", "ParkId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 3, 3 },
                    { 6, 4, 3 },
                    { 7, 3, 2 },
                    { 8, 6, 2 }
                });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "Description", "Designation", "Name", "OperatingHours", "ParkUrl" },
                values: new object[] { 4, "One of the top 10 most-visited parks in the United States, it has the highest rocky headlands along the Atlantic coast", "National Park", "Acadia National Park", "24-hrs All Days", "https://www.nps.gov/acad/index.htm" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "Line1", "Line2", "Line3", "ParkId", "State", "Type", "Zipcode" },
                values: new object[] { 6, "Bar Harbor", "Hulls Cove Visitor Center", "Route 3", "Bar Harbor, ME 04609", 4, "ME", "Physical Address", "04609" });

            migrationBuilder.InsertData(
                table: "Fees",
                columns: new[] { "FeeId", "Cost", "Description", "Name", "ParkId" },
                values: new object[,]
                {
                    { 9, 30.0, "Good for entry of private vehicle and all occupants to Yellowstone for 7 days from date of purchase", "Acadia Private Vehicle, 7-day", 4 },
                    { 10, 15.0, "Admits a single individual with no car; includes bicyclists, hikers and pedestrians", "Acadia Per Person, 7-day", 4 },
                    { 11, 55.0, "Admits a private vehicle and all passengers entry to Acadia. Valid for 12 months from purchase date", "Acadia Annual Pass", 4 }
                });

            migrationBuilder.InsertData(
                table: "LocalWildlife",
                columns: new[] { "LocalWildlifeId", "AnimalId", "ParkId" },
                values: new object[,]
                {
                    { 9, 5, 4 },
                    { 10, 3, 4 },
                    { 11, 4, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "FeeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "FeeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "FeeId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "LocalWildlife",
                keyColumn: "LocalWildlifeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LocalWildlife",
                keyColumn: "LocalWildlifeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LocalWildlife",
                keyColumn: "LocalWildlifeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LocalWildlife",
                keyColumn: "LocalWildlifeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LocalWildlife",
                keyColumn: "LocalWildlifeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "LocalWildlife",
                keyColumn: "LocalWildlifeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "LocalWildlife",
                keyColumn: "LocalWildlifeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "LocalWildlife",
                keyColumn: "LocalWildlifeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "LocalWildlife",
                keyColumn: "LocalWildlifeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "LocalWildlife",
                keyColumn: "LocalWildlifeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "LocalWildlife",
                keyColumn: "LocalWildlifeId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 4);
        }
    }
}
