using SafeWayzApp.Models;
using SafeWayzApp.Services;
using SafeWayzApp.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SafeWayzApp.ViewModels
{
    public class MapsViewModel : ContentPage
    {
        private IMapping _mappingService;

        readonly ObservableCollection<Location> _locations;

        public IEnumerable Locations => _locations;
        public Command CommunityFeedCommand { get; private set; }
        public Command AddLocationCommand { get; private set; }
        public IMapping mapping { get; private set; }

        public MapsViewModel()
        {
            _locations = new ObservableCollection<Location>()
                {
                new Location("UWC", "Future Innovation Lab", new Position(-33.9333296, 18.6333308)),
                new Location("Microsoft", "Office", new Position(-33.971200, 18.464900)),
                new Location("Nandos", "Cause why not?", new Position(-33.933533,  18.407378))
                };
            AddLocationCommand = new Command(() => ExecuteAddLocationCommand());
            CommunityFeedCommand = new Command(() => ExecuteCommunityFeedCommand());

            _mappingService = mapping;
        }

        async void ExecuteCommunityFeedCommand() => await Shell.Current.GoToAsync("//community");
        private void  ExecuteAddLocationCommand() => _locations.Add(_mappingService.GetNewLocation());
    }
}