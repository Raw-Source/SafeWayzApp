using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SafeWayzApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetails : ContentPage
    {
        public bool IsVote { get; set; }
        public PostDetails(string incidentDescription, string incidentType, string location, string area)
        {
            InitializeComponent();
         
            MyIncidentType.Text = incidentType;
            MyIncidentDescription.Text = incidentDescription;
            MyArea.Text = area;
            MyLocation.Source = location;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
               var comment = ChatEntry.Text;
               MyLabel.Text = comment;
            if(MyLabel.Text != null)
            {
                MyName.Text = "Anonymous:";
            }
            else if(ChatEntry == null)
            {
               MyName.Text = "You will be displayed as Anonymous";
            }
        }

        private void Vote_Clicked(object sender, EventArgs e)
        {
            IsVote = true;
            if(IsVote == true)
            {
                MyVote.Text = "1";
            }
            else
            {
                IsVote = false;
                if(IsVote == false)
                {
                    MyVote.Text = "0";
                }
            }
        }
    }
}