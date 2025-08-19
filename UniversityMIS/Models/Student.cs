using UniversityMIS.Models.Common;

namespace UniversityMIS.Models
{
    public class Student : BaseEntityModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
    }
}
