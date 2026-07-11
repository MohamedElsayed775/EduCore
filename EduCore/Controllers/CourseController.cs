using EduCore.Models;
using EduCore.Models.Data;
using EduCore.Models.ViewModel;
using EduCore.Repository;
using EduCore.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Controllers
{
    public class CourseController : Controller
    {
        ICourseRepository courseRepository;
        ITraineeRepository traineeRepo;
        ICrsResultRepository crsResultRepo;
        public CourseController(ICourseRepository _courseRepo, ITraineeRepository _traineeRepo, ICrsResultRepository _crsResultRepo)
        {
            courseRepository = _courseRepo;
            traineeRepo = _traineeRepo;
            crsResultRepo = _crsResultRepo;
        }
        public IActionResult ShowAll()
        {
            List<Course> courses = courseRepository.ShowAll();
            return View("ShowAll", courses);
        }
        public IActionResult GetById(int id)
        {
            Course course = courseRepository.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View("Details", course);
        }
        public IActionResult New()
        {
            return View("New");
        }
        [HttpPost]
        public IActionResult SaveNew(Course CourseUi)
        {
            if (ModelState.IsValid == true)
            {
                courseRepository.Add(CourseUi);
                courseRepository.SaveChanges();
                return RedirectToAction("ShowAll");
            }
            else
            {
                return View("New", CourseUi);
            }
        }
        public IActionResult Edit(int id)
        {
            Course course = courseRepository.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View("Edit", course);
        }

        [HttpPost]
        public IActionResult SaveEdit(Course courseUi)
        {
            if (ModelState.IsValid)
            {
                courseRepository.Update(courseUi);
                courseRepository.SaveChanges();
                return RedirectToAction("ShowAll");
            }
            return View("Edit", courseUi);
        }

        public IActionResult Delete(int id)
        {
            Course course = courseRepository.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View("Delete", course);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            courseRepository.Delete(id);
            courseRepository.SaveChanges();
            return RedirectToAction("ShowAll");
        }


        public IActionResult AddOrRemoveTrainee(int id)
        {
            List<Trainee> trainees = traineeRepo.ShowAll();
            ViewBag.CourseId = id;
            return View("Add&RemoveTrainee", trainees);
        }

        public IActionResult AddTrainee(int courseId, int traineeId)
        {
            AddTraineeViewModel addTraineeViewModel = new AddTraineeViewModel
            {
                CourseId = courseId ,
                TraineeId = traineeId
            };
            return View("AddTrainee", addTraineeViewModel);
        }
        [HttpPost]
        public IActionResult AddTraineeConfirmed(AddTraineeViewModel addTraineeViewModel)
        {
            if (ModelState.IsValid)
            {
                CrsResult crsResult = new CrsResult
                {
                    CourseId = addTraineeViewModel.CourseId,
                    TraineeId = addTraineeViewModel.TraineeId
                };
                crsResultRepo.Add(crsResult);
                crsResultRepo.SaveChanges();
                return RedirectToAction("ShowAll");
            }
            else
            {
                return View("AddTrainee", addTraineeViewModel);
            }
        }
        public IActionResult RemoveTrainee(int crsResultId)
        {
            CrsResult crsResult = crsResultRepo.GetById(crsResultId);
            return View("RemoveTrainee",crsResult);
        }
        [HttpPost]
        public IActionResult RemoveTraineeConfirmed(int Id)
        {
            crsResultRepo.Delete(Id);
            crsResultRepo.SaveChanges();
            return RedirectToAction("ShowAll");
        }
        public IActionResult EditDegree(int crsResultId)
        {
            CrsResult crsResult = crsResultRepo.GetById(crsResultId);
            return View("EditDegree", crsResult);
        }
        public IActionResult SaveDegree(TraineeDegreeViewModel traineeDegreeViewModel)
        {
            if (ModelState.IsValid)
            {
                CrsResult crsResult = crsResultRepo.GetById(traineeDegreeViewModel.Id);
                crsResult.Degree = traineeDegreeViewModel.Degree;
                crsResultRepo.Update(crsResult);
                crsResultRepo.SaveChanges();
                return RedirectToAction("ShowAll");
            }
            else
            {
                return View("EditDegree", traineeDegreeViewModel);
            }
        }
    }
}
