using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace App.DataAccess
{
    public class AppDbContext : IdentityDbContext<Identity.AspNetUsers , Identity.AspNetRoles , Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<App.DataAccess.Identity.AspNetUsers>(b =>
            {
                b.HasKey(u => u.Id);

            });

            ////public virtual DbSet<UserIdentity> UserIdentity { get; set; }
        }
        ////public virtual DbSet<UserIdentity> UserIdentity { get; set; }
    }
}
