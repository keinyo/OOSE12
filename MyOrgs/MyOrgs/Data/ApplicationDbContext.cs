using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyOrgs.Models;
//Sources: https://docs.microsoft.com/en-us/ef/core/modeling/keys?tabs=data-annotations
namespace MyOrgs.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Announcement> Announcement { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<OrgMembership> OrgMembership { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            modelbuilder.Entity<OrgMembership>()
                .HasKey(o => new { o.Org, o.User });

        }

        public DbSet<MyOrgs.Models.TaskList> TaskList { get; set; }

    }
}
