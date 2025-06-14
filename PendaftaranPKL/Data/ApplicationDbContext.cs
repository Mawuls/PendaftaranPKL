using Microsoft.EntityFrameworkCore;
using PendaftaranPKL.Models;

namespace PendaftaranPKL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
