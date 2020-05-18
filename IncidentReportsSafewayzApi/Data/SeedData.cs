using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeWayzLibrary.Models;

namespace IncidentReportsSafewayzApi.Data
{
    public class SeedData
    {
        public static void Initialize(IncidentContext context)
        {
            if (!context.IncidentReports.Any())
            {
                context.IncidentReports.AddRange(
                    new IncidentReportModel
                    {
                      
                    }
                );

                context.SaveChanges();
            }
        }
    }
}