using System.ComponentModel.DataAnnotations.Schema;
using UniversityMIS.Models.Common;

namespace UniversityMIS.Models
{
    public class Marks : BaseEntityModel
    {
        public int StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public Student? Student { get; set; }
        public int SemesterId { get; set; }
        [ForeignKey(nameof(SemesterId))]
        public Semester? Semester { get; set; }
        public int SubjectId { get; set; }
        [ForeignKey(nameof(SubjectId))]
        public Subject? Subject { get; set; }
        public double Mark { get; set; }
    }
}
