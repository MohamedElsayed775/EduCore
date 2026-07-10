using EduCore.Models;
using EduCore.Models.Data;
using EduCore.Models.ViewModel;
using EduCore.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Controllers
{
    public class InstructorController : Controller
    {
        IInstructorRepository InsRepo;
        ICourseRepository CourseRepo;
        IDepartmentRepository DeptRepo;
        public InstructorController(IInstructorRepository _InsRepo , ICourseRepository _CourseRepo , IDepartmentRepository _DeptRepo)
        {
            InsRepo = _InsRepo;
            CourseRepo = _CourseRepo;
            DeptRepo = _DeptRepo;
        }
        public IActionResult GetAll()
        {
            List<Instructor> instructors = InsRepo.ShowAll();
            return View("ShowAll", instructors);
        }
        public IActionResult GetById(int id)
        {
            Instructor instructors = InsRepo.GetById(id);
            return View("Details", instructors);
        }
        #region Create
        public IActionResult New()
        {
            InstructorWithListOfCoursesAndDepartmentViewModel InsVm = new();
            InsVm.Departments = DeptRepo.ShowAll();
            InsVm.Courses = CourseRepo.ShowAll ();

            return View("New", InsVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(InstructorWithListOfCoursesAndDepartmentViewModel NewInstructorVm)
        {
            Instructor NewInstructor = new Instructor
            {
                Id = NewInstructorVm.Id,
                Name = NewInstructorVm.Name,
                Image = NewInstructorVm.Image,
                Salary = NewInstructorVm.Salary,
                Address = NewInstructorVm.Address,
                DepartmentId = NewInstructorVm.DepartmentId,
                CourseId = NewInstructorVm.CourseId,
            };

            if (NewInstructor.Name != null)
            {
                InsRepo.Add(NewInstructor);
                InsRepo.SaveChanges();
                return RedirectToAction("GetAll");
            }
            return View("New", NewInstructor);
        }
        #endregion
        #region Edit
        public IActionResult Edit(int id)
        {
            Instructor instructors = InsRepo.GetById(id);
            InstructorWithListOfCoursesAndDepartmentViewModel instructorsVm = new InstructorWithListOfCoursesAndDepartmentViewModel
            {
                Id = instructors.Id,
                Name = instructors.Name,
                Image = instructors.Image,
                Salary = instructors.Salary,
                Address = instructors.Address,
                DepartmentId = instructors.DepartmentId,
                CourseId = instructors.CourseId
            };
            instructorsVm.Courses = CourseRepo.ShowAll ();
            instructorsVm.Departments = DeptRepo.ShowAll();
            return View("Edit", instructorsVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEdit(Instructor EditInstructor)
        {
            if (EditInstructor.Name != null)
            {
                Instructor OldInstructor = InsRepo.GetById(EditInstructor.Id);
                OldInstructor.Name = EditInstructor.Name;
                OldInstructor.Salary = EditInstructor.Salary;
                OldInstructor.Address = EditInstructor.Address;
                OldInstructor.Image = EditInstructor.Image;
                OldInstructor.CourseId = EditInstructor.CourseId;
                OldInstructor.DepartmentId = EditInstructor.DepartmentId;
                InsRepo.SaveChanges();
                return RedirectToAction("GetAll");
            }
            return View("Edit", EditInstructor);
        }
        #endregion
        public IActionResult Delete(int id)
        {      
            Instructor instructor = InsRepo.GetById(id);
            return View("Delete", instructor);
        }
        public IActionResult DeleteConfirm(int id)
        {
            InsRepo.Delete(id);
            InsRepo.SaveChanges();
            return RedirectToAction("GetAll");
        }        
    }
}
