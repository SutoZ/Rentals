using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rentals.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarRental",
                columns: table => new
                {
                    CarRentalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRental", x => x.CarRentalId);
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.OwnerId);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Car_CarRental_RentalId",
                        column: x => x.RentalId,
                        principalTable: "CarRental",
                        principalColumn: "CarRentalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customer_CarRental_RentalId",
                        column: x => x.RentalId,
                        principalTable: "CarRental",
                        principalColumn: "CarRentalId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "CarRental",
                columns: new[] { "CarRentalId", "CarId", "CustomerId", "From", "Price", "To" },
                values: new object[] { new Guid("5fabf3ba-ae75-432f-9d3b-ffe00c2fa8df"), new Guid("5a15ec11-e67c-46a8-bcbe-f5e008d13fd0"), new Guid("b64608ea-f373-4103-9856-2b31169acf9a"), new DateTime(2024, 3, 1, 15, 31, 59, 316, DateTimeKind.Local).AddTicks(4759), 50000m, new DateTime(2024, 3, 5, 15, 31, 59, 316, DateTimeKind.Local).AddTicks(4836) });

            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "OwnerId", "Address", "Email", "FirstName", "IsActive", "LastName", "Phone", "Prefix", "Street", "ZipCode" },
                values: new object[] { new Guid("3e5a7e66-e306-487f-bc00-25955f9deb4c"), "Budapest", "johndoe@gmail.com", "John", true, "Doe", "+36304874563", "MR", "Kiss", "1452" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "CarId", "Details", "Name", "Price", "RentalId", "Status" },
                values: new object[] { new Guid("5a15ec11-e67c-46a8-bcbe-f5e008d13fd0"), "Test details", "Toyota Yaris", 3500000m, new Guid("5fabf3ba-ae75-432f-9d3b-ffe00c2fa8df"), "New" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Address", "DateOfBirth", "FirstName", "LastName", "Prefix", "RentalId", "Street", "ZipCode" },
                values: new object[] { new Guid("b64608ea-f373-4103-9856-2b31169acf9a"), "Budapest", new DateTime(1970, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Smith", "MR", new Guid("5fabf3ba-ae75-432f-9d3b-ffe00c2fa8df"), "Kiss", "1235" });

            migrationBuilder.CreateIndex(
                name: "IX_Car_RentalId",
                table: "Car",
                column: "RentalId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_RentalId",
                table: "Customer",
                column: "RentalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "CarRental");
        }
    }
}
