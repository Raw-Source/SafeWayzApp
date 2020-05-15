using SafeWayzApp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeWayzApp.Models
{
    public class TypeOfIncident
    {
        //Name of incident in database
        public string IncidentName { get; set; }

        //Color referring to which incident
        public string IncidentColor { get; set; }

        //How bad in the incident
        public IncidentServerityEnum IncidentServerity { get; set; }
    }
}
