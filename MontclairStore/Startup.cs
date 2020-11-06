using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using MontclairStore.Models;
using Owin;
using System.Configuration;

[assembly: OwinStartupAttribute(typeof(MontclairStore.Startup))]
namespace MontclairStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateUserAndRoles();
        }
        public void CreateUserAndRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            try
            {
                // In Startup iam creating first Admin Role and creating a default Admin User     
                if (!roleManager.RoleExists("SuperAdmin"))
                {

                    // first we create Admin rool    

                    var role = new IdentityRole();
                    role.Name = "SuperAdmin";
                    roleManager.Create(role);

                    //Here we create a Admin super user who will maintain the website                   

                    var user = new ApplicationUser();
                    user.UserName = ConfigurationManager.AppSettings["UserName"].ToString();
                    user.Email = ConfigurationManager.AppSettings["Email"].ToString();
                    user.EmailConfirmed = true;
                    user.PhoneNumberConfirmed = true;
                    user.Full_Name = ConfigurationManager.AppSettings["AdName"].ToString() + " " + ConfigurationManager.AppSettings["AdLName"].ToString();
                    user.PhoneNumber = ConfigurationManager.AppSettings["AdPhone"].ToString();
                    string userPWD = ConfigurationManager.AppSettings["Password"].ToString();

                    var newUser = UserManager.Create(user, userPWD);

                    //Add default User to Role Admin    
                    if (newUser.Succeeded)
                    {
                        var result1 = UserManager.AddToRole(user.Id, "SuperAdmin");

                    }
                }
            }
            catch (System.Exception)
            {


            }
        }
    }
}
