using System.ComponentModel.DataAnnotations.Schema;
using UniversityMIS.Models.Common;

namespace UniversityMIS.Models
{
    public class Subject : BaseEntityModel
    {
        public string SubjectName { get; set; }
        public int SemesterId { get; set; }
        [ForeignKey(nameof(SemesterId))]
        public Semester? Semester { get; set; }
    }
}
