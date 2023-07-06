using Microsoft.EntityFrameworkCore;

namespace api.model
{
    public class employeecontext :DbContext
    {
        public employeecontext(DbContextOptions<employeecontext> options) : base(options)
        {


        }



        public DbSet<employee> Employees { get; set; }
    }
}
