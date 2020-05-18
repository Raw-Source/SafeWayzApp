using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SafeWayzLibrary.Models
{
    public class IncidentReportModel
    {
    
        public int Id { get; set; }

        //Based on user input
        public string Area { get; set; }

        //User Input current or automatic point
        public string Location { get; set; }
        public string IncidentType { get; set; } 
        public string IncidentDescription { get; set; }
    }
}
