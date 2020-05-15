using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SafeWayzApp.Models
{
    public class IncidentReport
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        public string Area { get; set; }
        public string Location { get; set; }
        public ObservableCollection<TypeOfIncident> IncidentType {get; set;}
        public string IncidentDescription { get; set; }
    }
}
