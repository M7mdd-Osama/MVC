using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace Demo.PL.Controllers
{
	public class DepartmentController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public DepartmentController( IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			var departments = _unitOfWork.DepartmentRepository.GetAll();
			return View(departments);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Department department)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.DepartmentRepository.Add(department);
				var Result = _unitOfWork.Complete();
				if (Result > 0)
				{
					TempData["Message"] = "Department Is Created";
				}
				return RedirectToAction(nameof(Index));
			}
			return View(department);
		}
		public IActionResult Details(int? id, string ViewName = "Details")
		{
			if (id is null)
				return BadRequest();
			var department = _unitOfWork.DepartmentRepository.GetById(id.Value);
			if (department is null)
				return NotFound();
			return View(ViewName, department);
		}

		[HttpGet]
		public IActionResult Edit(int? id)
		{
			//if (id is null)
			//	return BadRequest();
			//var department = _unitOfWork.DepartmentRepository.GetById(id.Value);
			//if (department is null)
			//	return NotFound();
			//return View(department);
			return Details(id, "Edit");
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Department department, [FromRoute] int id)
		{
			if (id != department.Id)
				return BadRequest();
			if (ModelState.IsValid)
			{
				try
				{
					_unitOfWork.DepartmentRepository.Update(department);
					return RedirectToAction(nameof(Index));
				}
				catch (System.Exception ex)
				{
					ModelState.AddModelError(string.Empty, ex.Message);
				}
			}
			return View(department);
		}
		public IActionResult Delete(int? id)
		{
			return Details(id, "Delete");
		}
		[HttpPost]
		public IActionResult Delete(Department department, [FromRoute] int id)
		{
			if (id != department.Id)
				return BadRequest();
			try
			{
				_unitOfWork.DepartmentRepository.Delete(department);
				return RedirectToAction(nameof(Index));
			}
			catch (System.Exception ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);
				return View(department);
			}
		}
		
	}
}
