﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiFlorence.Data;

#nullable disable

namespace WebApiFlorence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220601122654_FirstCreate")]
    partial class FirstCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("WebApiFlorence.Classes.DrinksMenu", b =>
                {
                    b.Property<int>("DrinksMenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DrinksMenuId"), 1L, 1);

                    b.Property<string>("DrinksMenuDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("WebApiFlorence.Classes.FirstDish", b =>
                {
                    b.Property<int>("FirstDishId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FirstDishId"), 1L, 1);

                    b.Property<string>("FirstDishDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstDishName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("FirstDishPictureData")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("FirstDishId");

                    b.ToTable("FirstDish");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.FoodMenu", b =>
                {
                    b.Property<int>("FoodMenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodMenuId"), 1L, 1);

                    b.Property<int>("FirstDishId")
                        .HasColumnType("int");

                    b.Property<string>("FoodMenuDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodMenuName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FoodMenuPrice")
                        .HasColumnType("float");

                    b.Property<int>("FoodMenuTypeEvent")
                        .HasColumnType("int");

                    b.Property<int>("FourthDishId")
                        .HasColumnType("int");

                    b.Property<int>("SecondDishId")
                        .HasColumnType("int");

                    b.Property<int>("ThirdDishId")
                        .HasColumnType("int");

                    b.HasKey("FoodMenuId");

                    b.HasIndex("FirstDishId");

                    b.HasIndex("FourthDishId");

                    b.HasIndex("SecondDishId");

                    b.HasIndex("ThirdDishId");

                    b.ToTable("FoodMenus");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.FourthDish", b =>
                {
                    b.Property<int>("FourthDishId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FourthDishId"), 1L, 1);

                    b.Property<string>("FourthDishDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FourthDishName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("FourthDishPictureData")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("FourthDishId");

                    b.ToTable("FourthDish");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.MailRequest", b =>
                {
                    b.Property<int>("MailRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MailRequestId"), 1L, 1);

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

            modelBuilder.Entity("WebApiFlorence.Classes.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"), 1L, 1);

                    b.Property<double>("AmountPayment")
                        .HasColumnType("float");

                    b.Property<string>("CVC2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PaymentId");

                    b.HasIndex("UserId");

                    b.ToTable("Payments");
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

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.HasIndex("UserId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.SecondDish", b =>
                {
                    b.Property<int>("SecondDishId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SecondDishId"), 1L, 1);

                    b.Property<string>("SecondDishDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondDishName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("SecondDishPictureData")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("SecondDishId");

                    b.ToTable("SecondDish");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.SpecialOffer", b =>
                {
                    b.Property<int>("SpecialOfferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpecialOfferId"), 1L, 1);

                    b.Property<string>("DescriptionOffer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DrinksMenuId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDateOffer")
                        .HasColumnType("datetime2");

                    b.Property<int>("FoodMenuId")
                        .HasColumnType("int");

                    b.Property<double>("PriceOffer")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartDateOffer")
                        .HasColumnType("datetime2");

                    b.HasKey("SpecialOfferId");

                    b.HasIndex("DrinksMenuId");

                    b.HasIndex("FoodMenuId");

                    b.ToTable("SpecialOffers");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.ThirdDish", b =>
                {
                    b.Property<int>("ThirdDishId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThirdDishId"), 1L, 1);

                    b.Property<string>("ThirdDishDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdDishName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ThirdDishPictureData")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ThirdDishId");

                    b.ToTable("ThirdDish");
                });

            modelBuilder.Entity("WebApiFlorence.Document", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentId"), 1L, 1);

                    b.Property<byte[]>("ContentDocument")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SigningDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DocumentId");

                    b.HasIndex("ReservationId");

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

                    b.Property<int?>("DrinksMenuId")
                        .HasColumnType("int");

                    b.Property<int?>("FoodMenuId")
                        .HasColumnType("int");

                    b.Property<string>("NotesDrinksMenu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotesFoodMenu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("NrPeople")
                        .HasColumnType("float");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int");

                    b.Property<int>("StatusReservation")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("DiscountId");

                    b.HasIndex("DrinksMenuId");

                    b.HasIndex("FoodMenuId");

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

            modelBuilder.Entity("WebApiFlorence.Classes.FoodMenu", b =>
                {
                    b.HasOne("WebApiFlorence.Classes.FirstDish", null)
                        .WithMany()
                        .HasForeignKey("FirstDishId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired()
                        .HasConstraintName("FK_FoodMenu_FirstDish");

                    b.HasOne("WebApiFlorence.Classes.FourthDish", null)
                        .WithMany()
                        .HasForeignKey("FourthDishId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired()
                        .HasConstraintName("FK_FoodMenu_FourthDish");

                    b.HasOne("WebApiFlorence.Classes.SecondDish", null)
                        .WithMany()
                        .HasForeignKey("SecondDishId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired()
                        .HasConstraintName("FK_FoodMenu_SecondDish");

                    b.HasOne("WebApiFlorence.Classes.ThirdDish", null)
                        .WithMany()
                        .HasForeignKey("ThirdDishId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired()
                        .HasConstraintName("FK_FoodMenu_ThirdDish");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.Payment", b =>
                {
                    b.HasOne("WebApiFlorence.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Payment_User");
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

            modelBuilder.Entity("WebApiFlorence.Classes.SpecialOffer", b =>
                {
                    b.HasOne("WebApiFlorence.Classes.DrinksMenu", null)
                        .WithMany()
                        .HasForeignKey("DrinksMenuId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired()
                        .HasConstraintName("FK_SpecialOffer_DrinksMenu");

                    b.HasOne("WebApiFlorence.Classes.FoodMenu", null)
                        .WithMany()
                        .HasForeignKey("FoodMenuId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired()
                        .HasConstraintName("FK_SpecialOffer_FoodMenu");
                });

            modelBuilder.Entity("WebApiFlorence.Document", b =>
                {
                    b.HasOne("WebApiFlorence.Reservation", null)
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Document_Reservation");
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

                    b.HasOne("WebApiFlorence.Classes.DrinksMenu", null)
                        .WithMany()
                        .HasForeignKey("DrinksMenuId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .HasConstraintName("FK_Reservation_DrinksMenu");

                    b.HasOne("WebApiFlorence.Classes.FoodMenu", null)
                        .WithMany()
                        .HasForeignKey("FoodMenuId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .HasConstraintName("FK_Reservation_FoodMenu");

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
