using Microsoft.EntityFrameworkCore;
using BookRecordApp.Models;

namespace BookRecordApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<BookRecord> BookRecords { get; set; }
    }
}
