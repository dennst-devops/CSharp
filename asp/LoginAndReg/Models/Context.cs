using Microsoft.EntityFrameworkCore;
//add all of this:
namespace LoginAndReg.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<Thing> Things {get;set;}
    }
}