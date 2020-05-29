using SafeWayzApp.ViewModels;
using SafeWayzLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Xaml;

namespace SafeWayzApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommunityFeedPage : ContentPage
    {
   
        public CommunityFeedPage()
        {
            InitializeComponent();
            BindingContext = new CommunityFeedViewModel();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var details = e.Item as TimelineModel;
            await Navigation.PushModalAsync(new PostDetails(details.IncidentDescription, details.IncidentType, details.Location, details.Area));

        }

        private void MySearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = BindingContext as CommunityFeedViewModel;
            ReportListView.BeginRefresh();

            if(string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                ReportListView.ItemsSource = keyword.Incidents;
                ReportListView.EndRefresh();
            }
            else
            {
                ReportListView.ItemsSource = keyword.Incidents.Where(i => i.IncidentType.ToLower().Contains(e.NewTextValue.ToLower())) ;

                ReportListView.EndRefresh();
            }
        
        }

    }
}

