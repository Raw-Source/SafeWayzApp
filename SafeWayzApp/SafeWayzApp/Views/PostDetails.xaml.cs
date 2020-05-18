using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SafeWayzApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetails : ContentPage
    {
        public PostDetails(string incidentDescription, string incidentType, string location, string area)
        {
            InitializeComponent();

            MyIncidentType.Text = incidentType;
            MyIncidentDescription.Text = incidentDescription;
            MyArea.Text = area;
            MyLocation.Source = location;
        }
    }
}