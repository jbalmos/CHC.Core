using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CHC.Common.Migrations
{
    public partial class chc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblContactRequest",
                columns: table => new
                {
                    ContactRequestID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerID = table.Column<int>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    RequestDtm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblContactRequest", x => x.ContactRequestID);
                });

            migrationBuilder.CreateTable(
                name: "tblFillPipeLocation",
                columns: table => new
                {
                    FillPipeLocationID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFillPipeLocation", x => x.FillPipeLocationID);
                });

            migrationBuilder.CreateTable(
                name: "tblOilDeliveryPricingTier",
                columns: table => new
                {
                    OilDeliveryPricingTierID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    CreditCardSurcharge = table.Column<decimal>(nullable: false),
                    BurnerPrimingFee = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOilDeliveryPricingTier", x => x.OilDeliveryPricingTierID);
                });

            migrationBuilder.CreateTable(
                name: "tblServiceAreaTown",
                columns: table => new
                {
                    Zip = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblServiceAreaTown", x => x.Zip);
                });

            migrationBuilder.CreateTable(
                name: "tblOilDeliveryPriceLevel",
                columns: table => new
                {
                    OilDeliveryPriceLevelID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OilDeliveryPricingTierID = table.Column<int>(nullable: false),
                    GallonRangeStart = table.Column<int>(nullable: false),
                    GallonRangeEnd = table.Column<int>(nullable: false),
                    PricePerGallon = table.Column<decimal>(nullable: false),
                    PricingTierID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOilDeliveryPriceLevel", x => x.OilDeliveryPriceLevelID);
                    table.ForeignKey(
                        name: "FK_tblOilDeliveryPriceLevel_tblOilDeliveryPricingTier_OilDelive~",
                        column: x => x.OilDeliveryPricingTierID,
                        principalTable: "tblOilDeliveryPricingTier",
                        principalColumn: "OilDeliveryPricingTierID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblOilDeliveryPriceLevel_tblOilDeliveryPricingTier_PricingTi~",
                        column: x => x.PricingTierID1,
                        principalTable: "tblOilDeliveryPricingTier",
                        principalColumn: "OilDeliveryPricingTierID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblOilDeliveryServiceArea",
                columns: table => new
                {
                    OilDeliveryPricingTierID = table.Column<int>(nullable: false),
                    Zip = table.Column<string>(nullable: false),
                    PricingTierID = table.Column<int>(nullable: true),
                    ServiceAreaTownZip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOilDeliveryServiceArea", x => new { x.OilDeliveryPricingTierID, x.Zip });
                    table.ForeignKey(
                        name: "FK_tblOilDeliveryServiceArea_tblOilDeliveryPricingTier_PricingT~",
                        column: x => x.PricingTierID,
                        principalTable: "tblOilDeliveryPricingTier",
                        principalColumn: "OilDeliveryPricingTierID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblOilDeliveryServiceArea_tblServiceAreaTown_ServiceAreaTown~",
                        column: x => x.ServiceAreaTownZip,
                        principalTable: "tblServiceAreaTown",
                        principalColumn: "Zip",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblOilDeliveryServiceArea_tblServiceAreaTown_Zip",
                        column: x => x.Zip,
                        principalTable: "tblServiceAreaTown",
                        principalColumn: "Zip",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblOilDeliveryPriceLevelFee",
                columns: table => new
                {
                    OilDeliveryPriceLevelFeeID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OilDeliveryPriceLevelID = table.Column<int>(nullable: false),
                    Fee = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PriceLevelID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOilDeliveryPriceLevelFee", x => x.OilDeliveryPriceLevelFeeID);
                    table.ForeignKey(
                        name: "FK_tblOilDeliveryPriceLevelFee_tblOilDeliveryPriceLevel_OilDeli~",
                        column: x => x.OilDeliveryPriceLevelID,
                        principalTable: "tblOilDeliveryPriceLevel",
                        principalColumn: "OilDeliveryPriceLevelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblOilDeliveryPriceLevelFee_tblOilDeliveryPriceLevel_PriceLe~",
                        column: x => x.PriceLevelID1,
                        principalTable: "tblOilDeliveryPriceLevel",
                        principalColumn: "OilDeliveryPriceLevelID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblCustomer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    IsUSMilitaryCustomer = table.Column<bool>(nullable: false),
                    IsSeniorCitizen = table.Column<bool>(nullable: false),
                    IsFuelAssistanceCustomer = table.Column<bool>(nullable: false),
                    IsEmergencyPersonnel = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomer", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "tblAccount",
                columns: table => new
                {
                    AccountID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    CreatedDtm = table.Column<DateTime>(nullable: false),
                    LastLoginDtm = table.Column<DateTime>(nullable: true),
                    LastIPAddress = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    CustomerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAccount", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_tblAccount_tblCustomer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "tblCustomer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblCustomerAddress",
                columns: table => new
                {
                    CustomerAddressID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerID = table.Column<int>(nullable: false),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomerAddress", x => x.CustomerAddressID);
                    table.ForeignKey(
                        name: "FK_tblCustomerAddress_tblCustomer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "tblCustomer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCustomerOilTank",
                columns: table => new
                {
                    CustomerOilTankID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerAddressID = table.Column<int>(nullable: false),
                    FillPipeLocation = table.Column<string>(nullable: true),
                    IsIndoor = table.Column<bool>(nullable: false),
                    Size = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomerOilTank", x => x.CustomerOilTankID);
                    table.ForeignKey(
                        name: "FK_tblCustomerOilTank_tblCustomerAddress_CustomerAddressID",
                        column: x => x.CustomerAddressID,
                        principalTable: "tblCustomerAddress",
                        principalColumn: "CustomerAddressID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblOilDeliveryRequest",
                columns: table => new
                {
                    OilDeliveryRequestID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerAddressID = table.Column<int>(nullable: false),
                    RequiresBurnerPriming = table.Column<bool>(nullable: false),
                    PricePerGallon = table.Column<decimal>(nullable: false),
                    EstimatedGallons = table.Column<int>(nullable: false),
                    DateRequested = table.Column<DateTime>(nullable: false),
                    isFillUp = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOilDeliveryRequest", x => x.OilDeliveryRequestID);
                    table.ForeignKey(
                        name: "FK_tblOilDeliveryRequest_tblCustomerAddress_CustomerAddressID",
                        column: x => x.CustomerAddressID,
                        principalTable: "tblCustomerAddress",
                        principalColumn: "CustomerAddressID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblOilDeliveryRequestFee",
                columns: table => new
                {
                    OilDeliveryRequestFeeID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OilDeliveryRequestID = table.Column<int>(nullable: false),
                    Fee = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DeliveryRequestID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOilDeliveryRequestFee", x => x.OilDeliveryRequestFeeID);
                    table.ForeignKey(
                        name: "FK_tblOilDeliveryRequestFee_tblOilDeliveryRequest_OilDeliveryRe~",
                        column: x => x.OilDeliveryRequestID,
                        principalTable: "tblOilDeliveryRequest",
                        principalColumn: "OilDeliveryRequestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblOilDeliveryRequestFee_tblOilDeliveryRequest_DeliveryReque~",
                        column: x => x.DeliveryRequestID1,
                        principalTable: "tblOilDeliveryRequest",
                        principalColumn: "OilDeliveryRequestID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAccount_CustomerID",
                table: "tblAccount",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerAddress_CustomerID",
                table: "tblCustomerAddress",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerOilTank_CustomerAddressID",
                table: "tblCustomerOilTank",
                column: "CustomerAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_tblOilDeliveryPriceLevel_OilDeliveryPricingTierID",
                table: "tblOilDeliveryPriceLevel",
                column: "OilDeliveryPricingTierID");

            migrationBuilder.CreateIndex(
                name: "IX_tblOilDeliveryPriceLevel_PricingTierID1",
                table: "tblOilDeliveryPriceLevel",
                column: "PricingTierID1");

            migrationBuilder.CreateIndex(
                name: "IX_tblOilDeliveryPriceLevelFee_OilDeliveryPriceLevelID",
                table: "tblOilDeliveryPriceLevelFee",
                column: "OilDeliveryPriceLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_tblOilDeliveryPriceLevelFee_PriceLevelID1",
                table: "tblOilDeliveryPriceLevelFee",
                column: "PriceLevelID1");

            migrationBuilder.CreateIndex(
                name: "IX_tblOilDeliveryRequest_CustomerAddressID",
                table: "tblOilDeliveryRequest",
                column: "CustomerAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_tblOilDeliveryRequestFee_OilDeliveryRequestID",
                table: "tblOilDeliveryRequestFee",
                column: "OilDeliveryRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_tblOilDeliveryRequestFee_DeliveryRequestID1",
                table: "tblOilDeliveryRequestFee",
                column: "DeliveryRequestID1");

            migrationBuilder.CreateIndex(
                name: "IX_tblOilDeliveryServiceArea_PricingTierID",
                table: "tblOilDeliveryServiceArea",
                column: "PricingTierID");

            migrationBuilder.CreateIndex(
                name: "IX_tblOilDeliveryServiceArea_ServiceAreaTownZip",
                table: "tblOilDeliveryServiceArea",
                column: "ServiceAreaTownZip");

            migrationBuilder.CreateIndex(
                name: "IX_tblOilDeliveryServiceArea_Zip",
                table: "tblOilDeliveryServiceArea",
                column: "Zip");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCustomer_tblAccount_CustomerID",
                table: "tblCustomer",
                column: "CustomerID",
                principalTable: "tblAccount",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblAccount_tblCustomer_CustomerID",
                table: "tblAccount");

            migrationBuilder.DropTable(
                name: "tblContactRequest");

            migrationBuilder.DropTable(
                name: "tblCustomerOilTank");

            migrationBuilder.DropTable(
                name: "tblFillPipeLocation");

            migrationBuilder.DropTable(
                name: "tblOilDeliveryPriceLevelFee");

            migrationBuilder.DropTable(
                name: "tblOilDeliveryRequestFee");

            migrationBuilder.DropTable(
                name: "tblOilDeliveryServiceArea");

            migrationBuilder.DropTable(
                name: "tblOilDeliveryPriceLevel");

            migrationBuilder.DropTable(
                name: "tblOilDeliveryRequest");

            migrationBuilder.DropTable(
                name: "tblServiceAreaTown");

            migrationBuilder.DropTable(
                name: "tblOilDeliveryPricingTier");

            migrationBuilder.DropTable(
                name: "tblCustomerAddress");

            migrationBuilder.DropTable(
                name: "tblCustomer");

            migrationBuilder.DropTable(
                name: "tblAccount");
        }
    }
}
