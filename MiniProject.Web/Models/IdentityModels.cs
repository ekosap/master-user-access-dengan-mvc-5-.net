using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MiniProject.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<int, CustomerUserLogin, CustomerUserRole, CustomerUserClaim>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public class CustomerUserRole : IdentityUserRole<int> { }
    public class CustomerUserClaim : IdentityUserClaim<int> { }
    public class CustomerUserLogin : IdentityUserLogin<int> { }

    public class CustomRole : IdentityRole<int, CustomerUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }
    public class CustomUserStore : UserStore<ApplicationUser, CustomRole, int, CustomerUserLogin, CustomerUserRole, CustomerUserClaim>
    {
        public CustomUserStore(ApplicationDbContext context) : base(context) { }
    }

    public class CustomRoleStore : RoleStore<CustomRole, int, CustomerUserRole>
    {
        public CustomRoleStore(ApplicationDbContext context): base(context) { }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole, int, CustomerUserLogin, CustomerUserRole, CustomerUserClaim>
    {
        public ApplicationDbContext()
            : base("AppEntity")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}