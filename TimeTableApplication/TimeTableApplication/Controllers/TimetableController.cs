using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTableApplication.Model;
using TimeTableApplication.Service.Interface;

namespace TimeTableApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimetableController : ControllerBase
    {
        private readonly ITimetableGeneratorService _timetableGeneratorService; // Use the interface

        public TimetableController(ITimetableGeneratorService timetableGeneratorService) // Inject the interface
        {
            _timetableGeneratorService = timetableGeneratorService;
        }

        [HttpPost("generate")]
        public IActionResult GenerateTimeTable([FromBody] TimeTableInputModel input)
        {
            int totalHoursForWeek = input.NoOfWorkingDays * input.NoOfSubjectsPerDay;
            int allocatedHours = input.SubjectHours.Values.Sum();

            if (allocatedHours != totalHoursForWeek)
                return BadRequest($"Total subject hours ({allocatedHours}) must match total slots available ({totalHoursForWeek}).");

            var timeTable = _timetableGeneratorService.GenerateTimeTable(input.SubjectHours, input.NoOfWorkingDays, input.NoOfSubjectsPerDay);
            return Ok(timeTable);
        }
    }
}
