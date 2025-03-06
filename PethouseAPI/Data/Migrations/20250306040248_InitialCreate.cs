using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PethouseAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BreedSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricePeakSeason = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceLowSeason = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedSizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmergencyContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmergencyContactRelationship = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeakSeasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeakSeasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    isTOSAppointmentDocumentSigned = table.Column<bool>(type: "bit", nullable: false),
                    MedicalChecked = table.Column<bool>(type: "bit", nullable: false),
                    CarnetCheked = table.Column<bool>(type: "bit", nullable: false),
                    AppointmentTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_AppointmentType_AppointmentTypeId",
                        column: x => x.AppointmentTypeId,
                        principalTable: "AppointmentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    BreedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMedicated = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreedSizeId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_BreedSizes_BreedSizeId",
                        column: x => x.BreedSizeId,
                        principalTable: "BreedSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pets_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PetAppointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetId = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    Monday = table.Column<bool>(type: "bit", nullable: false),
                    Tuesday = table.Column<bool>(type: "bit", nullable: false),
                    Wednesday = table.Column<bool>(type: "bit", nullable: false),
                    Thursday = table.Column<bool>(type: "bit", nullable: false),
                    Friday = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetAppointments_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PetAppointments_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppointmentType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hospedaje" },
                    { 2, "Guarderia" }
                });

            migrationBuilder.InsertData(
                table: "BreedSizes",
                columns: new[] { "Id", "Label", "Name", "PriceLowSeason", "PricePeakSeason" },
                values: new object[,]
                {
                    { 1, "0-10kg", "Small", 120.00m, 100.00m },
                    { 2, "11-25kg", "Medium", 170.00m, 150.00m },
                    { 3, "26-40kg", "Large", 220.00m, 200.00m },
                    { 4, "41-60kg", "Extra Large", 270.00m, 250.00m }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Address", "Email", "EmergencyContactName", "EmergencyContactPhone", "EmergencyContactRelationship", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "calle falsa 123", "coco@gmail.com", "Dai", "9992923923", "Sister", "Juan Brito", "9992923563" },
                    { 2, "calle falsa 123", "dai@gmail.com", "coco", "111111111", "brother", "Dai", "99999999" }
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "BreedName", "BreedSizeId", "DateOfBirth", "IsMedicated", "Name", "Notes", "OwnerId" },
                values: new object[,]
                {
                    { 1, "Chihuahua", 1, new DateOnly(2022, 10, 10), false, "Pocha", "None", 1 },
                    { 2, "Border", 2, new DateOnly(2020, 10, 10), false, "Luna", "None", 1 },
                    { 3, "Labrador", 3, new DateOnly(2018, 10, 10), false, "Coco", "None", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentTypeId",
                table: "Appointments",
                column: "AppointmentTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PetAppointments_AppointmentId",
                table: "PetAppointments",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PetAppointments_PetId",
                table: "PetAppointments",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_BreedSizeId",
                table: "Pets",
                column: "BreedSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_OwnerId",
                table: "Pets",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeakSeasons");

            migrationBuilder.DropTable(
                name: "PetAppointments");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "AppointmentType");

            migrationBuilder.DropTable(
                name: "BreedSizes");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
