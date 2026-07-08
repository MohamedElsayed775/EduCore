using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Xml;

namespace EduCore.Models
{
    public class CrsResult
    {
        public int Id { get; set; }
        public int Degree { get; set; }


        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course? Course { get; set; }

        [ForeignKey("Trainee")]
        public int TraineeId { get; set; }
        public virtual Trainee? Trainee { get; set; }
    }
}
