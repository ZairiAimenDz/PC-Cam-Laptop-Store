using Firebase.Database;
using Firebase.Database.Query;
using PCcamAdmin.Data;
using PCcamAdmin.Models;
using PCcamAdmin.Popup;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCcamAdmin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        FirebaseHelper Helper = new FirebaseHelper();
        public Home()
        {
            InitializeComponent();
            LaptopsList_Refreshing(null, null);
        }

        

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new Step1());
        }

        private async void LaptopsList_Refreshing(object sender, EventArgs e)
        {
            try
            {
                var all = await Helper.Get_Items();
                LaptopsList.ItemsSource =new ObservableCollection<Laptop>(all);
            }
            catch
            {
                await DisplayAlert("Error", "Check Your Internet Connection", "ok");
            }
            LaptopsList.IsRefreshing = false;
        }
    }


    public class NegateBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !System.Convert.ToBoolean(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !System.Convert.ToBoolean(value);
        }
    }
}