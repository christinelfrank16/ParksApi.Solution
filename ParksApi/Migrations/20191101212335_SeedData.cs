using Microsoft.EntityFrameworkCore.Migrations;

namespace ParksApi.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "Parks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Diet",
                table: "Animals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Animals",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "CommonName", "Description", "Diet", "ScientificName", "Type" },
                values: new object[,]
                {
                    { 1, "American Bison", "Often mistaken for buffaloes, these animals are the heaviest land animals in North America", "Herbivore", "Bison bison", "Mammal" },
                    { 2, "Red Fox", "Legendary for intelligence and cunning, red foxes are known for their red body and white underside and tipped tail; they live in many diverse habitats", "Omnivore", "Vulpes vulpes", "Mammal" },
                    { 3, "American Crow", "A common bird found across much of North America, it is all black with iridescent feathers", "Omnivore", "Corvus brachyrhynchos", "Bird" },
                    { 4, "Mallard", "Males (drakes) have a glossy green head and are grey on their wings and belly, while the females (hens or ducks) have mainly brown-speckled plumage", "Omnivore", "Anas platyrhynchos", "Bird" },
                    { 5, "Spotted Salamander", "Common in the eastern United States, it is stout in body and mostly black with two uneven rows of yellowish spots", "Carnivore", "Ambystoma maculatum", "Amphibian" },
                    { 6, "Texas Horned Lizard", "Similar to other lizards in its species, it is patterned and brown-toned with a spikey body, however it stands out as the largest bodied of its kind", "Carnivore", "Phrynosoma cornutum", "Amphibian" }
                });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "Description", "Designation", "Name", "OperatingHours", "ParkUrl" },
                values: new object[,]
                {
                    { 1, "A large seasonal park with fountains, breath-taking views and open spaces to explore!", "National Park", "Yellowstone", "24-hrs All Days", "https://www.nps.gov/yell/index.htm" },
                    { 2, "Known for its massive sandstone cliffs of cream, pink and red contrasting agains a bright blue sky, it is an area full of history about native people and pioneers", "National Park", "Zion National Park", "24-hrs All Days", "https://www.nps.gov/zion/index.htm" },
                    { 3, "A well wooded park with many trails used for horse-back riding, hiking, running and walking", "State Park", "Tryon Creek State National Area", "7am-5pm, changes seasonally", "https://oregonstateparks.org/index.cfm?do=parkPage.dsp_parkPage&parkId=103" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "Line1", "Line2", "Line3", "ParkId", "State", "Type", "Zipcode" },
                values: new object[,]
                {
                    { 1, "Yellowstone National Park", "Grand Loop Road", "Yellowstone National Park, WY 82190", "", 1, "WY", "Physical Address", "82190" },
                    { 2, "West Yellowstone", "Chamber of Commerce of West Yellowstone", "30 Yellowstone Avenue", "West Yellowstone, MT 59758", 1, "MT", "Physical Address", "59758" },
                    { 3, "Yellowstone National Park", "PO Box 168", "Yellowstone National Park, WY 82190", "", 1, "WY", "Mailing Address", "82190" },
                    { 4, "Springdale", "1 Zion Park Blvd", "State Route 9", "Springdale, UT 84767", 2, "UT", "Physical Address", "84767" },
                    { 5, "Portland", "11321 SW Terwilliger Blvd", "Portland, OR 97219", "", 3, "OR", "Physical Address", "97219" }
                });

            migrationBuilder.InsertData(
                table: "Fees",
                columns: new[] { "FeeId", "Cost", "Description", "Name", "ParkId" },
                values: new object[,]
                {
                    { 1, 35.0, "Good for entry of private vehicle and all occupants to Yellowstone for 7 days from date of purchase", "Yellowstone Private Vehicle, 7-day", 1 },
                    { 6, 20.0, "Good for single individual entry to Yellowstone for 7 days from date of purchase", "Yellowstone Per Person", 1 },
                    { 7, 70.0, "Admits entrance to Yellowstone for one year. When travelling by snowcoach or shuttle, it admits the holder and up to 3 additional individuals", "Yellowstone Annual Pass", 1 },
                    { 8, 70.0, "Admits entrance to Yellowstone for one year. When travelling by snowcoach or shuttle, it admits the holder and up to 3 additional individuals", "Yellowstone Annual Pass", 1 },
                    { 2, 35.0, "Admits private, non-commercial vehicles and all occupants", "Zion Private Vehicle, 7-day", 2 },
                    { 3, 20.0, "Admits a single individual with no car; includes bicyclists, hikers and pedestrians", "Zion Per Person, 7-day", 2 },
                    { 4, 20.0, "Admits one senior to all federal fee areas for one year from date of purchase", "Zion Senior Annual Pass", 2 },
                    { 5, 50.0, "Admits a single individual for one year from date of purchase", "Zion Annual Pass", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "FeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "FeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "FeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "FeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "FeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "FeeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "FeeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "FeeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "Parks");

            migrationBuilder.DropColumn(
                name: "Diet",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Animals");
        }
    }
}
