using EduCore.Models;
using EduCore.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EduCore.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentRepository departmentIRepository;
        public DepartmentController(IDepartmentRepository _departmentRepo)
        {
            departmentIRepository = _departmentRepo;
        }
        public IActionResult ShowAll()
        {
            List<Department> departments = departmentIRepository.ShowAll();
            return View("ShowAll", departments);
        }
        public IActionResult GetById(int id)
        {
            Department department = departmentIRepository.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            return View("Details", department);
        }
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            departmentIRepository.Add(department);
            departmentIRepository.SaveChanges();
            return RedirectToAction("ShowAll");
        }
        public IActionResult Edit(int id)
        {
            Department department = departmentIRepository.GetById(id);
            return View("Edit", department);
        }
        [HttpPost]
        public IActionResult Edit(Department departmentUi)
        {
            Department oldDepartment = departmentIRepository.GetById(departmentUi.Id);
            oldDepartment.Name = departmentUi.Name;
            oldDepartment.Manger = departmentUi.Manger;
            departmentIRepository.Update(oldDepartment);
            departmentIRepository.SaveChanges();
            return RedirectToAction("ShowAll");
        }
        public IActionResult Delete(int id)
        {
            Department department = departmentIRepository.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            return View("Delete", department);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            departmentIRepository.Delete(id);
            departmentIRepository.SaveChanges();
            return RedirectToAction("ShowAll");

        }
    }
}
