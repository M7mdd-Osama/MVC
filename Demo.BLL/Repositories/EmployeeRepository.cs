using Demo.BLL.Interfaces;
using Demo.DAL.Contexts;
using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
	public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
	{
		private readonly MvcAppDbContext _dbContext;

		public EmployeeRepository(MvcAppDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
		public IQueryable<Employee> GetEmployeesByAddress(string address)
			=> _dbContext.Employees.Where(E => E.Address == address);
	}
}
