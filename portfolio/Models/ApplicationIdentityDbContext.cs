using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using portfolio.Models.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace portfolio.Models
{
    public class ApplicationIdentityDbContext:IdentityDbContext<User,IdentityRole,string>
    {
        public ApplicationIdentityDbContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().Property(u => u.AccountCreationDate)
                .HasDefaultValueSql("getdate()");
            base.OnModelCreating(builder);
        }
    }
}
