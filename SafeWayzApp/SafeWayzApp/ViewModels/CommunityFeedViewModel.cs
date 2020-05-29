using SafeWayzLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SafeWayzApp.ViewModels
{
    public class CommunityFeedViewModel : BaseViewModel
    {
        public ObservableCollection<TimelineModel> Incidents { get; set; }
        public Command FilterCommand { get; private set; }
        public CommunityFeedViewModel()
        {
            Incidents = new ObservableCollection<TimelineModel>
            {
                new TimelineModel { IncidentType = "Accident", Area = "Grassy Park", IncidentDescription = "Car hit a robot in the heap of traffic because of a taxi that lost a wheel in the middle of the road."},
                new TimelineModel { IncidentType = "Shooting", Area = "Plumstead", IncidentDescription = "Shoot out by a local shop"},
                new TimelineModel { IncidentType = "Murder", Area = "Mananberg", IncidentDescription = "Man was shot and killed"},
                new TimelineModel { IncidentType = "Robbery", Area = "Wynberg", IncidentDescription = "local shop looted"},
                new TimelineModel { IncidentType = "Assault", Area = "Kenilworth", IncidentDescription = "Assault by a local shop" }
                
            };

            FilterCommand = new Command(() => ExecuteFilterCommand());
        }

        async void ExecuteFilterCommand()
        {
            await Shell.Current.GoToAsync("//filter");
        }


    }
}
