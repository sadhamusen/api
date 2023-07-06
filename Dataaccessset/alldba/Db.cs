using api.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccessset.alldba
{
    public class Db:DbContext
    {
       public Db(DbContextOptions<Db> options):base(options) { }



        public DbSet<employee> Employees { get; set; }
    }
}
