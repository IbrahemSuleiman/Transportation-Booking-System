using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel;
using System;

namespace adminlte.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        [DisplayName("Registration date")]
        public string UserRole { get; set; }
        [DisplayName("Registration date")]
        public DateTime RegistrationDate { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
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

        public System.Data.Entity.DbSet<adminlte.Models.Client> Clients { get; set; }

        public System.Data.Entity.DbSet<adminlte.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<adminlte.Models.Bus> Buses { get; set; }

        public System.Data.Entity.DbSet<adminlte.Models.Vehicle> Vehicles { get; set; }

        public System.Data.Entity.DbSet<adminlte.Models.PublicDriver> PublicDrivers { get; set; }

        public System.Data.Entity.DbSet<adminlte.Models.Travel> Travels { get; set; }

        public System.Data.Entity.DbSet<adminlte.Models.PrivateDriver> PrivateDrivers { get; set; }

        public System.Data.Entity.DbSet<adminlte.Models.Passenger> Passengers { get; set; }

        public System.Data.Entity.DbSet<adminlte.Models.MailBox> MailBoxes { get; set; }

        public System.Data.Entity.DbSet<adminlte.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<adminlte.Models.Ticket> Tickets { get; set; }
    }
}