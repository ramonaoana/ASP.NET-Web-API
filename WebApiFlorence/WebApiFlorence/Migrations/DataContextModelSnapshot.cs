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
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApiFlorence.Classes.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("DiscountStatus")
                        .HasColumnType("bit");

                    b.Property<double>("DiscountValue")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.DrinksMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DrinksMenuDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrinksMenuName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrinksMenuPrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DrinksMenus");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.FoodMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FoodMenuDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodMenuName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodMenuPrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FoodMenus");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("AmountPayment")
                        .HasColumnType("float");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.SpecialOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DescriptionOffer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DrinksMenuId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDateOffer")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FoodMenuId")
                        .HasColumnType("int");

                    b.Property<double>("PriceOffer")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartDateOffer")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DrinksMenuId");

                    b.HasIndex("FoodMenuId");

                    b.ToTable("SpecialOffers");
                });

            modelBuilder.Entity("WebApiFlorence.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ContentDocument")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SigningDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TemplateId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId");

                    b.HasIndex("UserId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("WebApiFlorence.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamePackage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PricePackage")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("WebApiFlorence.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("WebApiFlorence.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateEvent")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DiscountId")
                        .HasColumnType("int");

                    b.Property<int?>("DrinksMenuId")
                        .HasColumnType("int");

                    b.Property<int?>("FoodMenuId")
                        .HasColumnType("int");

                    b.Property<string>("NotesDrinksMenu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotesFoodMenu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("NrPeople")
                        .HasColumnType("float");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int");

                    b.Property<int>("StatusReservation")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiscountId");

                    b.HasIndex("DrinksMenuId");

                    b.HasIndex("FoodMenuId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("WebApiFlorence.Template", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ContentTemplate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("WebApiFlorence.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("CNP")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

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

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<byte[]>("PictureData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("Rights")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.Payment", b =>
                {
                    b.HasOne("WebApiFlorence.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApiFlorence.Classes.SpecialOffer", b =>
                {
                    b.HasOne("WebApiFlorence.Classes.DrinksMenu", "DrinksMenu")
                        .WithMany()
                        .HasForeignKey("DrinksMenuId");

                    b.HasOne("WebApiFlorence.Classes.FoodMenu", "FoodMenu")
                        .WithMany()
                        .HasForeignKey("FoodMenuId");

                    b.Navigation("DrinksMenu");

                    b.Navigation("FoodMenu");
                });

            modelBuilder.Entity("WebApiFlorence.Document", b =>
                {
                    b.HasOne("WebApiFlorence.Template", "Template")
                        .WithMany()
                        .HasForeignKey("TemplateId");

                    b.HasOne("WebApiFlorence.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Template");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApiFlorence.Request", b =>
                {
                    b.HasOne("WebApiFlorence.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApiFlorence.Reservation", b =>
                {
                    b.HasOne("WebApiFlorence.Classes.Discount", "Discount")
                        .WithMany()
                        .HasForeignKey("DiscountId");

                    b.HasOne("WebApiFlorence.Classes.DrinksMenu", "DrinksMenu")
                        .WithMany()
                        .HasForeignKey("DrinksMenuId");

                    b.HasOne("WebApiFlorence.Classes.FoodMenu", "FoodMenu")
                        .WithMany()
                        .HasForeignKey("FoodMenuId");

                    b.HasOne("WebApiFlorence.Classes.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId");

                    b.HasOne("WebApiFlorence.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Discount");

                    b.Navigation("DrinksMenu");

                    b.Navigation("FoodMenu");

                    b.Navigation("Payment");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
