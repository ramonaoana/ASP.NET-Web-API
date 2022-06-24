using Microsoft.EntityFrameworkCore;
using WebApiFlorence.Classes;

namespace WebApiFlorence.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users{get;set;}
        public DbSet<Document> Documents{get;set;}
        public DbSet<Request> Requests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<FoodMenu> FoodMenus { get; set; }
        public DbSet<DrinksMenu> DrinksMenus { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<SpecialOffer> SpecialOffers { get; set; }
        public DbSet<MailRequest> MailRequest { get; set; }
        public DbSet<WebApiFlorence.Classes.Review> Review { get; set; }
        public DbSet<WebApiFlorence.Classes.FirstDish> FirstDish { get; set; }
        public DbSet<WebApiFlorence.Classes.SecondDish> SecondDish { get; set; }
        public DbSet<WebApiFlorence.Classes.ThirdDish> ThirdDish { get; set; }
        public DbSet<WebApiFlorence.Classes.FourthDish> FourthDish { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User -> Payment

            modelBuilder.Entity<Payment>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.ClientNoAction)
                .HasConstraintName("FK_Payment_User");

            // DOCUMENT 

            modelBuilder.Entity<Document>()
                .HasOne<Reservation>()
                .WithMany()
                .HasForeignKey(p => p.ReservationId)
                .OnDelete(DeleteBehavior.ClientNoAction)
                .HasConstraintName("FK_Document_Reservation");


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
             .HasOne<FoodMenu>()
             .WithMany()
             .HasForeignKey(p => p.FoodMenuId)
             .OnDelete(DeleteBehavior.ClientNoAction)
             .HasConstraintName("FK_Reservation_FoodMenu");

            modelBuilder.Entity<Reservation>()
             .HasOne<DrinksMenu>()
             .WithMany()
             .HasForeignKey(p => p.DrinksMenuId)
             .OnDelete(DeleteBehavior.ClientNoAction)
             .HasConstraintName("FK_Reservation_DrinksMenu");

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
              .HasOne<FoodMenu>()
              .WithMany()
              .HasForeignKey(p => p.FoodMenuId)
              .OnDelete(DeleteBehavior.ClientNoAction)
              .HasConstraintName("FK_SpecialOffer_FoodMenu");

            modelBuilder.Entity<SpecialOffer>()
              .HasOne<DrinksMenu>()
              .WithMany()
              .HasForeignKey(p => p.DrinksMenuId)
              .OnDelete(DeleteBehavior.ClientNoAction)
              .HasConstraintName("FK_SpecialOffer_DrinksMenu");

             // FOOD MENU

            modelBuilder.Entity<FoodMenu>()
           .HasOne<FirstDish>()
           .WithMany()
           .HasForeignKey(p => p.FirstDishId)
           .OnDelete(DeleteBehavior.ClientNoAction)
           .HasConstraintName("FK_FoodMenu_FirstDish");

            modelBuilder.Entity<FoodMenu>()
          .HasOne<SecondDish>()
          .WithMany()
          .HasForeignKey(p => p.SecondDishId)
          .OnDelete(DeleteBehavior.ClientNoAction)
          .HasConstraintName("FK_FoodMenu_SecondDish");


            modelBuilder.Entity<FoodMenu>()
          .HasOne<ThirdDish>()
          .WithMany()
          .HasForeignKey(p => p.ThirdDishId)
          .OnDelete(DeleteBehavior.ClientNoAction)
          .HasConstraintName("FK_FoodMenu_ThirdDish");


            modelBuilder.Entity<FoodMenu>()
          .HasOne<FourthDish>()
          .WithMany()
          .HasForeignKey(p => p.FourthDishId)
          .OnDelete(DeleteBehavior.ClientNoAction)
          .HasConstraintName("FK_FoodMenu_FourthDish");









        }


    }
}
