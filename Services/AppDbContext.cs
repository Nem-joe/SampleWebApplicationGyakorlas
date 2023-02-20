using Microsoft.EntityFrameworkCore;
using SampleWebApplication1.Models;

namespace SampleWebApplication1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Address> Address { get; set; } 

        public DbSet<NoticeViewModel> notices { get; set; }
        public DbSet<NoticeViewModel> Practice { get; set; }
        public DbSet<SampleWebApplication1.Models.Practice> Practice_1 { get; set; }
    }
}
