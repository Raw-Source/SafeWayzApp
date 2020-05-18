using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeWayzApp.Models;
using SafeWayzLibrary.Models;

namespace IncidentReportsSafewayzApi.Data
{
    public class IncidentContext : DbContext
    {
        public IncidentContext(DbContextOptions<IncidentContext> options)
            : base(options)
        {
        }

        public DbSet<IncidentReportModel> IncidentReports { get; set; }
    }
}