using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SafeWayzApp.ViewModels
{
    public class Onboarding3ViewModel :BaseViewModel
    {
        
        public Command GetStartedCommand { get; private set; }
        public Onboarding3ViewModel()
        {
            Title = "Onboarding3";
            GetStartedCommand = new Command(() => ExecuteGetStartedCommand());
          
        }


        async void ExecuteGetStartedCommand()
        {
            await Shell.Current.GoToAsync("//login");
        }
    }
    
}