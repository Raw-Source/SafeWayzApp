using SafeWayzApp.Helper;
using SafeWayzApp.Views;
using SafeWayzLibrary.Models;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SafeWayzApp.ViewModels
{
    public class PostingViewModel : BaseViewModel
    {
        public ApiServices _apiServices;
        public IncidentReportModel incident;
        public Command PostCommand { get; private set; }
        public string IncidentColor { get; set; }
        public string GPS { get; set; }
        // public TypeOfIncident List { get; set; }
        public PostingViewModel()
        {
           
            PostCommand = new Command(() => ExecutePostCommand());
        }

        async void ExecutePostCommand()
        {
            bool terms = await Application.Current.MainPage.DisplayAlert($"Acknowlegment", "Please make sure all information is correct", "Yes", "No");
            if(terms == true)
            {
                if ((incident.IncidentType != null) && (incident.IncidentDescription != null) && (incident.Location != null))
                {
                    await _apiServices.PostReport(incident);
                    await Shell.Current.GoToAsync("//community");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert($"Invalid", "Please fill in all fields", "Ok");
                }

            }
            else
            {
                return; 
            }

        }
    }
}
