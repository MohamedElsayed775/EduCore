using System.ComponentModel.DataAnnotations.Schema;

namespace EduCore.Models.ViewModel
{
    public class InstructorWithListOfCoursesAndDepartmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        
        public List<Course> Courses { get; set; }
        public List<Department> Departments { get; set; }
        public int CourseId { get; set; }
        
        public int DepartmentId { get; set; }
    }
}
