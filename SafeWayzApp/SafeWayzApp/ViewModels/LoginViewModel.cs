using Newtonsoft.Json;
using SafeWayzApp.Models;
using SafeWayzLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SafeWayzApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        readonly IList<Authentication> source;

        public bool LoggedIn { get; set; }

        public UserDetails detail;


        public Command SignupCommand { get; private set; }
        public Command UriCommand { get; private set; }
        public Command LoginCommand { get; private set; }
        public ObservableCollection<Authentication> AuthenticationType { get; private set; }
        public LoginViewModel()
        {
            SignupCommand = new Command(() => ExecuteSignupCommand());
            LoginCommand = new Command(() => ExecuteLoginCommand());
            source = new List<Authentication>();
            CreateAuthenticationCollection();
            UriCommand = new Command(() => ExecuteUriCommand());
            detail = new UserDetails();
        }


        async void ExecuteSignupCommand()
        {
            if((detail.UserName != null) && (detail.Password != null) && (detail.Email != null))
            {
                await Post();
                await Shell.Current.GoToAsync("//login");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Invalid", "Enter correct details", "Ok");
                return;
            }
        }

        async void ExecuteLoginCommand()
        {
            if ((detail.UserName != null) && (detail.Password != null))
            {
                await Login(detail.UserName, detail.Password);

                if (LoggedIn == true)
                {
                    await Shell.Current.GoToAsync("//map");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Invalid", "Enter correct details", "Ok");
                    return;
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Invalid", "Enter correct details", "Ok");
                return;
            }
        }

        void CreateAuthenticationCollection()
        {
            source.Add(new Authentication { Name = "Login", Email = "example@gmail.com", Passsword = "Password", Username = "User Name"  });
            source.Add(new Authentication { Name = "Register", Email = "example@gmail.com", Passsword = "Password", Username = "User Name" });
            AuthenticationType = new ObservableCollection<Authentication>(source);
        }

        #region Authentication
        public async Task Post()
        {
            bool terms = await Application.Current.MainPage.DisplayAlert("T&C's", "By creating and account you accept the T&C's", "Ok", "Cancel");
            if(terms == true)
            {

                var client = new HttpClient();
                var url = "https://10.0.2.2:5000/api/UserDetails";
                try
                {

                    var json = JsonConvert.SerializeObject(detail);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, content);

                }
                catch (Exception)
                {
                    await Application.Current.MainPage.DisplayAlert("Incorrect Sign Up", "InValid Credentials", "Ok");
                }
            }
            else
            {
                return;
            }

        }

        public async Task<bool> Login(string username, string password)
        {
            // await _database.GetPeopleByUserName(username, password);
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://10.0.2.2:5000/api/UserDetails/{username}/{password}");

            try
            {
                var response = await client.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject(content);
                var login = json.ToString();
                if(login.Contains(username) && login.Contains(password))
                {
                    LoggedIn = true;
                }
                return true;
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Invalid", "Please fill in correct details", "Ok");
            }

            return false;
        }
        #endregion


        
        void ExecuteUriCommand()
        {
            Browser.OpenAsync(new Uri("https://xamarin.com"));
        }
    }
}