using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduCore.Models
{
    public class Course
    {
        public int Id { get; set; }

        [MaxLength(15, ErrorMessage = "Name Over Long")]
        public string Name { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }
        public int Hours { get; set; }


        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }

        public ICollection<Instructor>? Instructors { get; set; }
        public ICollection<CrsResult>? CrsResults { get; set; }

    }
}
