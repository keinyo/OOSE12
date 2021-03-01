//Resources used: https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app
//Name should be changed to be less specific, as this is the database everything but user accounts use
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
