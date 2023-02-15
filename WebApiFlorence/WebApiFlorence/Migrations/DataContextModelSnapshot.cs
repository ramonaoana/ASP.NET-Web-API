﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiFlorence.Data;

#nullable disable

namespace WebApiFlorence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApiFlorence.Classes.Discount", b =>
                {
                    b.Property<int>("DiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiscountId"), 1L, 1);

                    b.Property<bool>("DiscountStatus")
                        .HasColumnType("bit");

                    b.Property<double>("DiscountValue")
                        .HasColumnType("float");

                    b.HasKey("DiscountId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.Dish", b =>
                {
                    b.Property<int>("DishId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DishId"), 1L, 1);

                    b.Property<string>("DishName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("DishPictureData")
                        .HasColumnType("varbinary(max)");

                    b.Property<double>("DishPrice")
                        .HasColumnType("float");

                    b.HasKey("DishId");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.DishProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "DishId");

                    b.HasIndex("DishId");

                    b.ToTable("DishProducts", (string)null);
                });

            modelBuilder.Entity("WebApiFlorence.Classes.DrinksMenu", b =>
                {
                    b.Property<int>("DrinksMenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DrinksMenuId"), 1L, 1);

                    b.Property<string>("DrinksMenuName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("DrinksMenuPictureData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<double>("DrinksMenuPrice")
                        .HasColumnType("float");

                    b.HasKey("DrinksMenuId");

                    b.ToTable("DrinksMenus");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.DrinksMenuProduct", b =>
                {
                    b.Property<int>("DrinksMenuId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("DrinksMenuId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("DrinksMenuProducts", (string)null);
                });

            modelBuilder.Entity("WebApiFlorence.Classes.FoodMenu", b =>
                {
                    b.Property<int>("FoodMenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodMenuId"), 1L, 1);

                    b.Property<string>("FoodMenuDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodMenuName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FoodMenuPrice")
                        .HasColumnType("float");

                    b.HasKey("FoodMenuId");

                    b.ToTable("FoodMenus");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.FoodMenuDish", b =>
                {
                    b.Property<int>("FoodMenuId")
                        .HasColumnType("int");

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.HasKey("FoodMenuId", "DishId");

                    b.HasIndex("DishId");

                    b.ToTable("FoodMenuDishes", (string)null);
                });

            modelBuilder.Entity("WebApiFlorence.Classes.MailRequest", b =>
                {
                    b.Property<int>("MailRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MailRequestId"), 1L, 1);

                    b.Property<byte[]>("Attachment")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("AttachmentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MailRequestId");

                    b.ToTable("MailRequest");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuId"), 1L, 1);

                    b.Property<int>("DrinksMenuId")
                        .HasColumnType("int");

                    b.Property<int>("FoodMenuId")
                        .HasColumnType("int");

                    b.Property<string>("MenuDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MenuPrice")
                        .HasColumnType("float");

                    b.Property<int>("MenuTypeEvent")
                        .HasColumnType("int");

                    b.HasKey("MenuId");

                    b.HasIndex("DrinksMenuId");

                    b.HasIndex("FoodMenuId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"), 1L, 1);

                    b.Property<double>("AmountPayment")
                        .HasColumnType("float");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpirationDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PaymentId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.Photo", b =>
                {
                    b.Property<int>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhotoId"), 1L, 1);

                    b.Property<byte[]>("PhotoPictureData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("PhotoId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<double>("ProductCategory")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ProductPrice")
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.ReservationPackage", b =>
                {
                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId", "PackageId");

                    b.HasIndex("PackageId");

                    b.ToTable("ReservationPackages", (string)null);
                });

            modelBuilder.Entity("WebApiFlorence.Classes.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestaurantId"), 1L, 1);

                    b.Property<string>("Addresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Facebook")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instagram")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestaurantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestaurantONRCCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RestaurantPictureData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RestaurantType")
                        .HasColumnType("int");

                    b.Property<string>("RestaurantUniqueCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RestaurantId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"), 1L, 1);

                    b.Property<string>("Feedback")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Note")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.HasIndex("UserId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("WebApiFlorence.Document", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentId"), 1L, 1);

                    b.Property<byte[]>("ContentDocument")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("SigningDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DocumentId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("WebApiFlorence.Package", b =>
                {
                    b.Property<int>("PackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PackageId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamePackage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PackagePictureData")
                        .HasColumnType("varbinary(max)");

                    b.Property<double>("PricePackage")
                        .HasColumnType("float");

                    b.HasKey("PackageId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("WebApiFlorence.Request", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestId"), 1L, 1);

                    b.Property<DateTime>("DateRequest")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("StatusRequest")
                        .HasColumnType("bit");

                    b.Property<string>("TypeRequest")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RequestId");

                    b.HasIndex("UserId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("WebApiFlorence.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"), 1L, 1);

                    b.Property<DateTime?>("DateEvent")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DiscountId")
                        .HasColumnType("int");

                    b.Property<int?>("DocumentId")
                        .HasColumnType("int");

                    b.Property<int?>("MenuId")
                        .HasColumnType("int");

                    b.Property<double?>("NrPeople")
                        .HasColumnType("float");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int");

                    b.Property<double?>("ReservationAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReservationTypeEvent")
                        .HasColumnType("int");

                    b.Property<int>("StatusReservation")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<bool?>("hasInvitation")
                        .HasColumnType("bit");

                    b.HasKey("ReservationId");

                    b.HasIndex("DiscountId");

                    b.HasIndex("DocumentId");

                    b.HasIndex("MenuId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("WebApiFlorence.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("CNP")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSubscribed")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("Rights")
                        .HasColumnType("bit");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.DishProduct", b =>
                {
                    b.HasOne("WebApiFlorence.Classes.Dish", null)
                        .WithMany()
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired()
                        .HasConstraintName("FK_DishProduct_Dish");

                    b.HasOne("WebApiFlorence.Classes.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired()
                        .HasConstraintName("FK_DishProduct_Products");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.DrinksMenuProduct", b =>
                {
                    b.HasOne("WebApiFlorence.Classes.DrinksMenu", null)
                        .WithMany()
                        .HasForeignKey("DrinksMenuId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired()
                        .HasConstraintName("FK_DrinksMenuProduct_DrinksMenu");

                    b.HasOne("WebApiFlorence.Classes.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired()
                        .HasConstraintName("FK_DrinksMenuProduct_Products");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.FoodMenuDish", b =>
                {
                    b.HasOne("WebApiFlorence.Classes.Dish", null)
                        .WithMany()
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired()
                        .HasConstraintName("FK_FoodMenuDish_Dish");

                    b.HasOne("WebApiFlorence.Classes.FoodMenu", null)
                        .WithMany()
                        .HasForeignKey("FoodMenuId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired()
                        .HasConstraintName("FK_FoodMenuDish_FoodMenu");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.Menu", b =>
                {
                    b.HasOne("WebApiFlorence.Classes.DrinksMenu", null)
                        .WithMany()
                        .HasForeignKey("DrinksMenuId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Menu_DrinksMenu");

                    b.HasOne("WebApiFlorence.Classes.FoodMenu", null)
                        .WithMany()
                        .HasForeignKey("FoodMenuId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Menu_FoodMenu");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.Photo", b =>
                {
                    b.HasOne("WebApiFlorence.Classes.Restaurant", null)
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Photo_Restaurant");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.ReservationPackage", b =>
                {
                    b.HasOne("WebApiFlorence.Package", null)
                        .WithMany()
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired()
                        .HasConstraintName("FK_ReservationPackage_Package");

                    b.HasOne("WebApiFlorence.Reservation", null)
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired()
                        .HasConstraintName("FK_ReservationPackage_Reservation");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.Review", b =>
                {
                    b.HasOne("WebApiFlorence.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Review_User");
                });

            modelBuilder.Entity("WebApiFlorence.Request", b =>
                {
                    b.HasOne("WebApiFlorence.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Request_User");
                });

            modelBuilder.Entity("WebApiFlorence.Reservation", b =>
                {
                    b.HasOne("WebApiFlorence.Classes.Discount", null)
                        .WithMany()
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .HasConstraintName("FK_Reservation_Discount");

                    b.HasOne("WebApiFlorence.Document", null)
                        .WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .HasConstraintName("FK_Reservation_Document");

                    b.HasOne("WebApiFlorence.Classes.Menu", null)
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .HasConstraintName("FK_Reservation_Menu");

                    b.HasOne("WebApiFlorence.Classes.Payment", null)
                        .WithMany()
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .HasConstraintName("FK_Reservation_Payment");

                    b.HasOne("WebApiFlorence.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Reservation_User");
                });
#pragma warning restore 612, 618
        }
    }
}