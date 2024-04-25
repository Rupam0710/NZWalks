using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("51120843-e0f2-4ea5-a073-0a40f2f376ee"), "Easy" },
                    { new Guid("5a8ca8af-58f6-47f4-b032-259b6f1fe1fb"), "Hard" },
                    { new Guid("8cb9e5b9-84f5-4974-81fd-e133a24bc87b"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("4303c959-2a22-4f8c-bb20-924990a73364"), "AKL", "Auckland", "https://images.ctfassets.net/bth3mlrehms2/3Iquh7an0sBOkJLzCDv5iX/03e5eda0131ce61bc6a1010caf5b25c4/Neuseeland__Christchurch.jpg?w=3504&h=1971&fl=progressive&q=50&fm=jpg" },
                    { new Guid("8bca55be-7e8e-42d9-bd9d-f1655b4b923b"), "WLG", "Wellington", "https://images.prismic.io/indiecampers-demo/627620cc-2a55-4f55-ab38-a7d3b4a623fb_christchurch_card-min.jpg?auto=compress,format&rect=0,0,4498,3000&w=1360&q=30" },
                    { new Guid("9afa9c73-3dbe-46e0-ba0a-dca4b5e29913"), "CHC", "ChristChurch", "https://i.natgeofe.com/n/2d8130f8-becb-4fef-8a78-eafad9bdf2c5/IGCC1_4x3.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("51120843-e0f2-4ea5-a073-0a40f2f376ee"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("5a8ca8af-58f6-47f4-b032-259b6f1fe1fb"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("8cb9e5b9-84f5-4974-81fd-e133a24bc87b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4303c959-2a22-4f8c-bb20-924990a73364"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8bca55be-7e8e-42d9-bd9d-f1655b4b923b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("9afa9c73-3dbe-46e0-ba0a-dca4b5e29913"));
        }
    }
}
