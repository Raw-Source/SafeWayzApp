using SafeWayzApp.ViewModels;
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
    public partial class LoginPage : ContentPage
    {
        public LoginViewModel VM { get; set; }
        public LoginPage()

        {   
            InitializeComponent();

            VM = new LoginViewModel();
            BindingContext = VM;
        }
    }

}