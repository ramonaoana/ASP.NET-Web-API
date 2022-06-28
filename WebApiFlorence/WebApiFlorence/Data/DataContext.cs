using Microsoft.EntityFrameworkCore;
using WebApiFlorence.Classes;

namespace WebApiFlorence.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users{get;set;}
        public DbSet<Document> Documents{get;set;}
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<DrinksMenu> DrinksMenus { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<SpecialOffer> SpecialOffers { get; set; }
        public DbSet<MailRequest> MailRequest { get; set; }
        public DbSet<ReservationPackage> ReservationPackages { get; set; }
        public DbSet<WebApiFlorence.Classes.Review> Review { get; set; }
        public DbSet<DishProduct> DishProducts { get; set; }
        public DbSet<DrinksMenuProduct> DrinksMenuProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<FoodMenu> FoodMenus { get; set; }
        public DbSet<FoodMenuDish> FoodMenuDishes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // DOCUMENT 

            modelBuilder.Entity<Document>()
                .HasOne<Reservation>()
                .WithMany()
                .HasForeignKey(p => p.ReservationId)
                .OnDelete(DeleteBehavior.ClientNoAction)
                .HasConstraintName("FK_Document_Reservation");

            // MAIL 

            modelBuilder.Entity<MailRequest>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.ClientNoAction)
                .HasConstraintName("FK_MailRequest_User");

            //Reservation

            modelBuilder.Entity<Reservation>()
             .HasOne<User>()
             .WithMany()
             .HasForeignKey(p => p.UserId)
             .OnDelete(DeleteBehavior.ClientNoAction)
             .HasConstraintName("FK_Reservation_User");

            modelBuilder.Entity<Reservation>()
             .HasOne<Payment>()
             .WithMany()
             .HasForeignKey(p => p.PaymentId)
             .OnDelete(DeleteBehavior.ClientNoAction)
             .HasConstraintName("FK_Reservation_Payment");

            modelBuilder.Entity<Reservation>()
             .HasOne<Menu>()
             .WithMany()
             .HasForeignKey(p => p.MenuId)
             .OnDelete(DeleteBehavior.ClientNoAction)
             .HasConstraintName("FK_Reservation_Menu");


            modelBuilder.Entity<Reservation>()
             .HasOne<Discount>()
             .WithMany()
             .HasForeignKey(p => p.DiscountId)
             .OnDelete(DeleteBehavior.ClientNoAction)
             .HasConstraintName("FK_Reservation_Discount");

#pragma warning restore

            //REQUEST
            modelBuilder.Entity<Request>()
              .HasOne<User>()
              .WithMany()
              .HasForeignKey(p => p.UserId)
              .OnDelete(DeleteBehavior.ClientNoAction)
              .HasConstraintName("FK_Request_User");


            //REVIEW
            modelBuilder.Entity<Review>()
              .HasOne<User>()
              .WithMany()
              .HasForeignKey(p => p.UserId)
              .OnDelete(DeleteBehavior.ClientNoAction)
              .HasConstraintName("FK_Review_User");

            //SpecialOffer

            modelBuilder.Entity<SpecialOffer>()
              .HasOne<Menu>()
              .WithMany()
              .HasForeignKey(p => p.MenuId)
              .OnDelete(DeleteBehavior.ClientNoAction)
              .HasConstraintName("FK_SpecialOffer_Menu");


            //MENU
            modelBuilder.Entity<Menu>()
            .HasOne<FoodMenu>()
            .WithMany()
            .HasForeignKey(p => p.FoodMenuId)
            .OnDelete(DeleteBehavior.ClientNoAction)
            .HasConstraintName("FK_Menu_FoodMenu");

            modelBuilder.Entity<Menu>()
            .HasOne<DrinksMenu>()
            .WithMany()
            .HasForeignKey(p => p.DrinksMenuId)
            .OnDelete(DeleteBehavior.ClientNoAction)
            .HasConstraintName("FK_Menu_DrinksMenu");

            //FoodMenu Dish
            modelBuilder.Entity<FoodMenuDish>()
           .ToTable("FoodMenuDishes");
            modelBuilder.Entity<FoodMenuDish>()
              .HasKey(l => new { l.FoodMenuId, l.DishId });

            modelBuilder.Entity<FoodMenuDish>()
            .HasOne<FoodMenu>()
            .WithMany()
            .HasForeignKey(p => p.FoodMenuId)
            .OnDelete(DeleteBehavior.ClientNoAction)
            .HasConstraintName("FK_FoodMenuDish_FoodMenu");

            modelBuilder.Entity<FoodMenuDish>()
            .HasOne<Dish>()
            .WithMany()
            .HasForeignKey(p => p.DishId)
            .OnDelete(DeleteBehavior.ClientNoAction)
            .HasConstraintName("FK_FoodMenuDish_Dish");

          
            //Dish Product

            modelBuilder.Entity<DishProduct>()
                 .ToTable("DishProducts");
            modelBuilder.Entity<DishProduct>()
              .HasKey(l => new { l.ProductId, l.DishId });

            modelBuilder.Entity<DishProduct>()
              .HasOne<Dish>()
              .WithMany()
              .HasForeignKey(rd => rd.DishId)
              .OnDelete(DeleteBehavior.ClientNoAction)
              .HasConstraintName("FK_DishProduct_Dish");

            modelBuilder.Entity<DishProduct>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(rd => rd.ProductId)
                .OnDelete(DeleteBehavior.ClientNoAction)
                .HasConstraintName("FK_DishProduct_Products");

            //DrinksMenu Product

            modelBuilder.Entity<DrinksMenuProduct>()
                 .ToTable("DrinksMenuProducts");
            modelBuilder.Entity<DrinksMenuProduct>()
              .HasKey(l => new { l.DrinksMenuId, l.ProductId });

            modelBuilder.Entity<DrinksMenuProduct>()
                .HasOne<DrinksMenu>()
                .WithMany()
                .HasForeignKey(rd => rd.DrinksMenuId)
                .OnDelete(DeleteBehavior.ClientNoAction)
                .HasConstraintName("FK_DrinksMenuProduct_DrinksMenu");

            modelBuilder.Entity<DrinksMenuProduct>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(rd => rd.ProductId)
                .OnDelete(DeleteBehavior.ClientNoAction)
                .HasConstraintName("FK_DrinksMenuProduct_Products");


            //Reservation Package

            modelBuilder.Entity<ReservationPackage>()
                 .ToTable("ReservationPackages");
            modelBuilder.Entity<ReservationPackage>()
              .HasKey(l => new { l.ReservationId, l.PackageId });

            modelBuilder.Entity<ReservationPackage>()
                .HasOne<Reservation>()
                .WithMany()
                .HasForeignKey(rd => rd.ReservationId)
                .OnDelete(DeleteBehavior.ClientNoAction)
                .HasConstraintName("FK_ReservationPackage_Reservation");

            modelBuilder.Entity<ReservationPackage>()
                .HasOne<Package>()
                .WithMany()
                .HasForeignKey(rd => rd.PackageId)
                .OnDelete(DeleteBehavior.ClientNoAction)
                .HasConstraintName("FK_ReservationPackage_Package");


            modelBuilder.Entity<Photo>()
                .HasOne<Member>()
                .WithMany()
                .HasForeignKey(rd => rd.MemberId)
                .OnDelete(DeleteBehavior.ClientNoAction)
                .HasConstraintName("FK_Photo_Member");

        }
    }
}
