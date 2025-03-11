using TimeTableApplication.Model;

namespace TimeTableApplication.Service.Interface
{
    public interface ITimetableGeneratorService
    {
        List<List<string>> GenerateTimeTable(Dictionary<string, int> subjectHours, int noOfWorkingDays, int noOfSubjectsPerDay);
    }
}
