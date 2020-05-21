using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncidentReportsSafewayzApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeWayzLibrary.Models;

namespace IncidentReportsSafewayzApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentReportController : ControllerBase
    {
        private readonly IncidentContext _context;

        public IncidentReportController(IncidentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<IncidentReportModel>> GetAll() =>
            _context.IncidentReports.ToList();

        [HttpGet("{id}")]
        public async Task<ActionResult<IncidentReportModel>> GetById(int id)
        {
            var report = await _context.IncidentReports.FindAsync(id);

            if (report == null)
            {
                return NotFound();
            }

            return report;
        }

        [HttpPost]
        public async Task<ActionResult<IncidentReportModel>> Create(IncidentReportModel incidentReport)
        {
            _context.IncidentReports.Add(incidentReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = incidentReport.Id }, incidentReport);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, IncidentReportModel incidentReport)
        {
            if (id != incidentReport.Id)
            {
                return BadRequest();
            }

            _context.Entry(incidentReport).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var report = await _context.IncidentReports.FindAsync(id);

            if (report == null)
            {
                return NotFound();
            }

            _context.IncidentReports.Remove(report);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
