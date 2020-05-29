using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace SafeWayzApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectLocationPage : ContentPage
    {
        public SelectLocationPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await GetActualLocation();
        }

        async Task GetActualLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.High);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    myMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                        new Position(location.Latitude, location.Longitude), Distance.FromKilometers(0.3)));

                }

            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Unable to get actual location", "Ok");
            }
        }

        private async void myMap_MapClicked(object sender, MapClickedEventArgs e)
        {
            Geocoder geoCoder = new Geocoder();
            Position posi = e.Position;
            IEnumerable<string> possibleAddresses = await geoCoder.GetAddressesForPositionAsync(posi);
            string address = possibleAddresses.FirstOrDefault();

            Pin pin = new Pin
            {
                Label = "Location",
                Address = address,
                Type = PinType.Place,
                Position = new Position(posi.Latitude, posi.Longitude)
            };
            myMap.Pins.Clear();
            myMap.Pins.Add(pin);


            var response = await DisplayAlert("Location", address, "OK", "CANCEL");

            if (response == true)
            {
                await Navigation.PushAsync(new PostingIncidentPage(address));
                myMap.Pins.Clear();
            }
            else
            {
                myMap.Pins.Clear();
            }
        }
    }
}