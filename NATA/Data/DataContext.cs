using Microsoft.EntityFrameworkCore;
using NATA.Entities;

namespace NATA.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
         public DbSet<AppUser> Users {get;set;}
    }
}