using Microsoft.EntityFrameworkCore;

namespace KLOCAssessmentProject.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}