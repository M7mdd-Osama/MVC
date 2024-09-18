using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Contexts
{
	public class MvcAppDbContext : DbContext
	{
        public MvcAppDbContext(DbContextOptions<MvcAppDbContext> options) : base(options)
        {
            
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //	=> optionsBuilder.UseSqlServer("server = .; database = MvcAppDb ; Trusted_Connection = true;");

        public DbSet<Department> Departments { get; set; }
    }
}
