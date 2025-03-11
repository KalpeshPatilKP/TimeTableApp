using TimeTableApplication.Model;
using TimeTableApplication.Service.Interface;

namespace TimeTableApplication.Service
{
    public class TimetableGeneratorService : ITimetableGeneratorService
    {
        public List<List<string>> GenerateTimeTable(Dictionary<string, int> subjectHours, int noOfWorkingDays, int noOfSubjectsPerDay)
        {
            int totalSlots = noOfWorkingDays * noOfSubjectsPerDay;
            List<string> subjectsPool = new List<string>();

            // Populate the subjects based on allocated hours
            foreach (var subject in subjectHours)
            {
                subjectsPool.AddRange(Enumerable.Repeat(subject.Key, subject.Value));
            }

            // Shuffle to randomize distribution
            Random random = new Random();
            subjectsPool = subjectsPool.OrderBy(x => random.Next()).ToList();

            // Initialize timetable grid (column-wise structure)
            List<List<string>> timetable = new List<List<string>>();

            // Fill the timetable column by column
            for (int day = 0; day < noOfWorkingDays; day++)
            {
                List<string> column = new List<string>();
                for (int period = 0; period < noOfSubjectsPerDay; period++)
                {
                    column.Add(subjectsPool[day * noOfSubjectsPerDay + period]);
                }
                timetable.Add(column);
            }

            return timetable; 
        }
    }
}
