using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MontclairModels;
using MontclairStore.Models;

namespace MontclairStore.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public string Full_Name { get; set; }
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        //Stock
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ItemEntity> Items { get; set; }
        //Temporal Shopping
        public DbSet<CartEntity> Carts { get; set; }
        public DbSet<CartItemEntity> Cart_Items { get; set; }
        //Shopping
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderItemEntity> Order_Items { get; set; }
        public DbSet<OrderAddressEntity> Order_Addresses { get; set; }
        public DbSet<OrderTrackingEntity> Order_Trackings { get; set; }
        //
        public DbSet<PaymentEntity> Payments { get; set; }
        //
        public DbSet<CustomerEntity> Customers { get; set; }

      
        public System.Data.Entity.DbSet<MontclairStore.Logic.Courier> Couriers { get; set; }

     
    }
}