using SafeWayzApp.Enums;
using SafeWayzApp.Models;
using SafeWayzApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SafeWayzApp.ViewModels
{
    public class PostingViewModel : ContentPage
    {

        public List<TypeOfIncident> IncidentList { get; set; }
       // public TypeOfIncident List { get; set; }
        public PostingViewModel()
        {
            IncidentList = GetIncidentTypes().OrderBy(t => t.IncidentName).ToList();
        }

        public List<TypeOfIncident> GetIncidentTypes()
        {
            var type = new List<TypeOfIncident>()
            {
                new TypeOfIncident(){IncidentName = "Accident",IncidentColor = "#370359", IncidentServerity = IncidentServerityEnum.best},
                new TypeOfIncident(){IncidentName = "Robbery",IncidentColor = "#1bd3e0", IncidentServerity = IncidentServerityEnum.okay},
                new TypeOfIncident(){IncidentName = "Assault",IncidentColor = "#919491", IncidentServerity = IncidentServerityEnum.nuetral},
                new TypeOfIncident(){IncidentName = "Shooting",IncidentColor = "#00b806", IncidentServerity = IncidentServerityEnum.bad},
                new TypeOfIncident(){IncidentName = "Murder",IncidentColor = "#b80000", IncidentServerity = IncidentServerityEnum.worst}
            };
            return type;
        }
    }
}
