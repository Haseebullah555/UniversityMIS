using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniversityMIS.ViewModel
{
    public class TranscriptViewModel
    {
        // For selecting filters
        public int StudentId { get; set; }
        public List<int> SemesterIds { get; set; } = new List<int>();  // <-- multiple semesters

        // For dropdowns
        public List<SelectListItem>? Students { get; set; }
        public List<SelectListItem>? Semesters { get; set; }

        // For displaying transcript results
        public string? StudentName { get; set; }
        public List<SemesterTranscriptDto>? SemesterTranscripts { get; set; } // one per semester
    }

    public class SemesterTranscriptDto
    {
        public string SemesterName { get; set; }
        public List<SubjectMarkDto> Subjects { get; set; } = new();
    }

    public class SubjectMarkDto
    {
        public string SubjectName { get; set; }
        public double Mark { get; set; }
    }

}
