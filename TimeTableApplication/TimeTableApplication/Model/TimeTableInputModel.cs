using System.ComponentModel.DataAnnotations;

namespace TimeTableApplication.Model
{
    public class TimeTableInputModel
    {
        [Required]
        [Range(1, 7, ErrorMessage = "Working days must be between 1 and 7.")]
        public int NoOfWorkingDays { get; set; }

        [Required]
        [Range(1, 8, ErrorMessage = "Subjects per day must be between 1 and 8.")]
        public int NoOfSubjectsPerDay { get; set; }

        [Required]
        public required Dictionary<string, int> SubjectHours { get; set; }
    }
}
