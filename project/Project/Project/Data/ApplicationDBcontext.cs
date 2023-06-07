using Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Project.Data


{
    public class ApplicationDBcontext : DbContext

    {
        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet <Order_Item> Items { get; set; }
        public DbSet <Reservation> Reservations { get; set; }
        public DbSet<Cart> CartItems { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<user> users { get; set; }
        public DbSet<ContactUs> Inqiries { get; set; }
        public DbSet <Survey> Surveys { get; set;}
    }
}
