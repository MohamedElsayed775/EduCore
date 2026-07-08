using EduCore.Models;
using EduCore.Models.Data;
using EduCore.Models.ViewModel;
using EduCore.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EduCore.Controllers
{
    public class TraineeController : Controller
    {
        private readonly ITraineeRepository traineeRepo;
        private readonly ICrsResultRepository crsResultRepo;

        public TraineeController(ITraineeRepository _traineeRepo , ICrsResultRepository _crsResultRepo)
        {
            traineeRepo = _traineeRepo;
            crsResultRepo = _crsResultRepo;
        }
        public IActionResult ShowAll()
        {
            List<Trainee> trainees = traineeRepo.ShowAll();
            return View("ShowAll", trainees);
        }
        public IActionResult GetById(int id)
        {
            Trainee trainee = traineeRepo.GetById(id);
            return View("Details", trainee);
        }
        public IActionResult create()
        {
            return View("create");
        }
        [HttpPost]
        public IActionResult SaveNew(Trainee traineeUi)
        {
            if (ModelState.IsValid)
            {
                traineeRepo.Add(traineeUi);
                traineeRepo.SaveChanges();
                return RedirectToAction("ShowAll");
            }
            else
            {
                return View("create", traineeUi);
            }
        }
        public IActionResult Edit(int id)
        {
            Trainee trainee = traineeRepo.GetById(id);
            return View("Edit", trainee);
        }
        [HttpPost]
        public IActionResult SaveEdit(int id ,Trainee traineeUi)
        {
            if (ModelState.IsValid)
            {
                Trainee oldTrainee = traineeRepo.GetById(id);
                oldTrainee.Name = traineeUi.Name;
                oldTrainee.Image = traineeUi.Image;
                oldTrainee.Address = traineeUi.Address;
                oldTrainee.Grade = traineeUi.Grade;
                oldTrainee.DepartmentId = traineeUi.DepartmentId;
                traineeRepo.Update(oldTrainee);
                traineeRepo.SaveChanges();
                return RedirectToAction("ShowAll");
            }
            else
            {
                return View("Edit", traineeUi);
            }
        }
        public IActionResult Delete(int id)
        {
            Trainee trainee = traineeRepo.GetById(id);
            return View("Delete", trainee);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            traineeRepo.Delete(id);
            traineeRepo.SaveChanges();
            return RedirectToAction("ShowAll");
        }

        public IActionResult Results(int id)
        {
            List<ResultsViewModel> results = traineeRepo.GetResults(id);
            return View("Results", results);
        }

    }
}