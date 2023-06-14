using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model.Identity;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Context
{
    public class ApplicationDbcontext:IdentityDbContext<ApplicationUser,ApplicationRole,int>
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {

        }

        DbSet<Employee> employees { get; set; }
        DbSet<Leave> leaves {get; set; } 


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            int Role_Id = 1;
            int User_Id = 1;
            builder.Entity<ApplicationRole>().HasData(new ApplicationRole() { Id = Role_Id, Name = "Admin", NormalizedName = "Admin" });

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = User_Id,
                UserName = "HR",
                NormalizedUserName = "HR",
                Email = "hr@gmail.com",
                NormalizedEmail = "hr@gmail.com",
                PhoneNumber = "1234567890",
                PasswordHash = hasher.HashPassword(null, "hr@123"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = Role_Id,
                UserId = User_Id
            });
        }
    }
}
