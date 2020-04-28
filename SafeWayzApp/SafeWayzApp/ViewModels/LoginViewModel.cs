using SafeWayzApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SafeWayzApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        readonly IList<Authentication> source;

        public Command LoginCommand { get; private set; }
        public ObservableCollection<Authentication> AuthenticationType { get; private set; }
        public LoginViewModel()
        {   
              LoginCommand = new Command(() => ExecuteLoginCommand());
            source = new List<Authentication>();
            CreateAuthenticationCollection();
          
        }

        async void ExecuteLoginCommand() => await Shell.Current.GoToAsync("//map");

        void CreateAuthenticationCollection()
        {
            source.Add(new Authentication { Name = "Login", Email = "example@gmail.com", Passsword = "Password", Username = "User Name"  });
            source.Add(new Authentication { Name = "Register", Email = "example@gmail.com", Passsword = "Password", Username = "User Name" });
            AuthenticationType = new ObservableCollection<Authentication>(source);
        }
    }
}