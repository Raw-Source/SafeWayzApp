using SafeWayzApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SafeWayzApp.Controls
{
    public class AuthenticationTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Login { get; set; }
        public DataTemplate Registration { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((Authentication)item).Name.Equals("Login") ? Login : Registration;
        }
    }
}
