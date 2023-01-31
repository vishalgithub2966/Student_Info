using Microsoft.EntityFrameworkCore;
using Student_Info.Models;

namespace Student_Info.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Student>? Students { get; set; }
    }
}
