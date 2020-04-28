using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SafeWayzApp.ViewModels
{
    public class MapsViewModel : ContentPage
    {
        public Command CommunityFeedCommand { get; private set; }
        public MapsViewModel()
        {
            CommunityFeedCommand = new Command(() => ExecuteCommunityFeedCommand());

           
        }

        async void ExecuteCommunityFeedCommand() => await Shell.Current.GoToAsync("//community");
    }
}