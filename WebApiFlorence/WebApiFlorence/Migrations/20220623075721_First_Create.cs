using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiFlorence.Migrations
{
    public partial class First_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountValue = table.Column<double>(type: "float", nullable: false),
                    DiscountStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.DiscountId);
                });

            migrationBuilder.CreateTable(
                name: "DrinksMenus",
                columns: table => new
                {
                    DrinksMenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrinksMenuName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrinksMenuPrice = table.Column<double>(type: "float", nullable: false),
                    DrinksMenuDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrinksMenuPictureData = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinksMenus", x => x.DrinksMenuId);
                });

            migrationBuilder.CreateTable(
                name: "FirstDish",
                columns: table => new
                {
                    FirstDishId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstDishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstDishDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstDishPictureData = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstDish", x => x.FirstDishId);
                });

            migrationBuilder.CreateTable(
                name: "FourthDish",
                columns: table => new
                {
                    FourthDishId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FourthDishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FourthDishDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FourthDishPictureData = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FourthDish", x => x.FourthDishId);
                });

            migrationBuilder.CreateTable(
                name: "MailRequest",
                columns: table => new
                {
                    MailRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailRequest", x => x.MailRequestId);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    PackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePackage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePackage = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.PackageId);
                });

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    PartnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartnerPhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PartnerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartnerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartnerAddresse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.PartnerId);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    PhotoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoPictureData = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PhotoId);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantOwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantNumberPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantAddresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantTown = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantCounty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantInstagram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantFacebook = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.RestaurantId);
                });

            migrationBuilder.CreateTable(
                name: "SecondDish",
                columns: table => new
                {
                    SecondDishId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecondDishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondDishDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondDishPictureData = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondDish", x => x.SecondDishId);
                });

            migrationBuilder.CreateTable(
                name: "ThirdDish",
                columns: table => new
                {
                    ThirdDishId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThirdDishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThirdDishDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThirdDishPictureData = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThirdDish", x => x.ThirdDishId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    County = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Town = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CNP = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IsSubscribed = table.Column<bool>(type: "bit", nullable: false),
                    Rights = table.Column<bool>(type: "bit", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "FoodMenus",
                columns: table => new
                {
                    FoodMenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodMenuTypeEvent = table.Column<int>(type: "int", nullable: false),
                    FoodMenuName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodMenuPrice = table.Column<double>(type: "float", nullable: false),
                    FoodMenuDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstDishId = table.Column<int>(type: "int", nullable: false),
                    SecondDishId = table.Column<int>(type: "int", nullable: false),
                    ThirdDishId = table.Column<int>(type: "int", nullable: false),
                    FourthDishId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodMenus", x => x.FoodMenuId);
                    table.ForeignKey(
                        name: "FK_FoodMenu_FirstDish",
                        column: x => x.FirstDishId,
                        principalTable: "FirstDish",
                        principalColumn: "FirstDishId");
                    table.ForeignKey(
                        name: "FK_FoodMenu_FourthDish",
                        column: x => x.FourthDishId,
                        principalTable: "FourthDish",
                        principalColumn: "FourthDishId");
                    table.ForeignKey(
                        name: "FK_FoodMenu_SecondDish",
                        column: x => x.SecondDishId,
                        principalTable: "SecondDish",
                        principalColumn: "SecondDishId");
                    table.ForeignKey(
                        name: "FK_FoodMenu_ThirdDish",
                        column: x => x.ThirdDishId,
                        principalTable: "ThirdDish",
                        principalColumn: "ThirdDishId");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountPayment = table.Column<double>(type: "float", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVC2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payment_User",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeRequest = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StatusRequest = table.Column<bool>(type: "bit", nullable: false),
                    DateRequest = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_Request_User",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<int>(type: "int", nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Review_User",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "SpecialOffers",
                columns: table => new
                {
                    SpecialOfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialOfferTypeEvent = table.Column<int>(type: "int", nullable: false),
                    PriceOffer = table.Column<double>(type: "float", nullable: false),
                    DescriptionOffer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDateOffer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateOffer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FoodMenuId = table.Column<int>(type: "int", nullable: false),
                    DrinksMenuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialOffers", x => x.SpecialOfferId);
                    table.ForeignKey(
                        name: "FK_SpecialOffer_DrinksMenu",
                        column: x => x.DrinksMenuId,
                        principalTable: "DrinksMenus",
                        principalColumn: "DrinksMenuId");
                    table.ForeignKey(
                        name: "FK_SpecialOffer_FoodMenu",
                        column: x => x.FoodMenuId,
                        principalTable: "FoodMenus",
                        principalColumn: "FoodMenuId");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NrPeople = table.Column<double>(type: "float", nullable: true),
                    DateEvent = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusReservation = table.Column<int>(type: "int", nullable: false),
                    NotesFoodMenu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotesDrinksMenu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hasInvitation = table.Column<bool>(type: "bit", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: true),
                    FoodMenuId = table.Column<int>(type: "int", nullable: true),
                    DrinksMenuId = table.Column<int>(type: "int", nullable: true),
                    DiscountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservation_Discount",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "DiscountId");
                    table.ForeignKey(
                        name: "FK_Reservation_DrinksMenu",
                        column: x => x.DrinksMenuId,
                        principalTable: "DrinksMenus",
                        principalColumn: "DrinksMenuId");
                    table.ForeignKey(
                        name: "FK_Reservation_FoodMenu",
                        column: x => x.FoodMenuId,
                        principalTable: "FoodMenus",
                        principalColumn: "FoodMenuId");
                    table.ForeignKey(
                        name: "FK_Reservation_Payment",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId");
                    table.ForeignKey(
                        name: "FK_Reservation_User",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SigningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContentDocument = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_Document_Reservation",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "ReservationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ReservationId",
                table: "Documents",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodMenus_FirstDishId",
                table: "FoodMenus",
                column: "FirstDishId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodMenus_FourthDishId",
                table: "FoodMenus",
                column: "FourthDishId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodMenus_SecondDishId",
                table: "FoodMenus",
                column: "SecondDishId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodMenus_ThirdDishId",
                table: "FoodMenus",
                column: "ThirdDishId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UserId",
                table: "Requests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_DiscountId",
                table: "Reservations",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_DrinksMenuId",
                table: "Reservations",
                column: "DrinksMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_FoodMenuId",
                table: "Reservations",
                column: "FoodMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PaymentId",
                table: "Reservations",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId",
                table: "Review",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialOffers_DrinksMenuId",
                table: "SpecialOffers",
                column: "DrinksMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialOffers_FoodMenuId",
                table: "SpecialOffers",
                column: "FoodMenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "MailRequest");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "SpecialOffers");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "DrinksMenus");

            migrationBuilder.DropTable(
                name: "FoodMenus");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "FirstDish");

            migrationBuilder.DropTable(
                name: "FourthDish");

            migrationBuilder.DropTable(
                name: "SecondDish");

            migrationBuilder.DropTable(
                name: "ThirdDish");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
