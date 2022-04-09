using Microsoft.EntityFrameworkCore;
using WebApiFlorence.Classes;

namespace WebApiFlorence.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users{get;set;}
        public DbSet<Document> Documents{get;set;}
        public DbSet<Template> Templates { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<FoodMenu> FoodMenus { get; set; }
        public DbSet<DrinksMenu> DrinksMenus { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<SpecialOffer> SpecialOffers { get; set; }







    }
}
