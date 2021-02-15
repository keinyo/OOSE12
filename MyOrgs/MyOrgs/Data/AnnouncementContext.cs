//Resources used: https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app
using Microsoft.EntityFrameworkCore;
using MyOrgs.Models;

namespace MyOrgs.Data
{
    public class AnnouncementContext : DbContext
    {
        public AnnouncementContext (DbContextOptions<AnnouncementContext> options) : base(options)
        {

        }

        public DbSet<Announcement> Announcement { get; set; }
    }
}
