using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
	public class DepartmentController : Controller
	{
		private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
			_departmentRepository = departmentRepository;
		}
        public IActionResult Index()
		{
			var departments = _departmentRepository.GetAll();
			return View(departments);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Department department)
		{
			if (ModelState.IsValid) //Server Side Validation
			{
				_departmentRepository.Add(department);
				return RedirectToAction(nameof(Index));
			}
			return View(department);
		}
		public IActionResult Details(int? id)
		{
			if (id is null)
				return BadRequest();
			var department = _departmentRepository.GetById(id.Value);
			if(department is null)
				return NotFound();
			return View(department);
		}
	}
}
