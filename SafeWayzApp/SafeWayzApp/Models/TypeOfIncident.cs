using SafeWayzApp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeWayzApp.Models
{
    public class TypeOfIncident
    {
        public string IncidentName { get; set; }
        public string IncidentColor { get; set; }
        public IncidentServerityEnum IncidentServerity { get; set; }
    }
}
