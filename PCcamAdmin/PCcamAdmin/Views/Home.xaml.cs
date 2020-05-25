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
            var search = new ItemSearch() { 
                Placeholder="Search For Laptop ... ",
                ItemTemplate= new DataTemplate(() =>
                {
                    StackLayout stack = new StackLayout() {Padding=new Thickness(10),Orientation=StackOrientation.Horizontal,Margin=new Thickness(2)};
                    var image = new Image() { HeightRequest = 64, WidthRequest = 64 };
                    image.SetBinding(Image.SourceProperty, "mainimg");
                    stack.Children.Add(image);
                    var stack1 = new StackLayout();
                    var lb = new Label()
                    {FontSize=14 , FontAttributes=FontAttributes.Bold,TextColor=Color.Black};
                    lb.SetBinding(Label.TextProperty, "Brand");
                    stack1.Children.Add(lb);
                    var lb2 = new Label()
                    {
                        FontSize = 18,
                        TextColor = Color.Black
                    };
                    lb2.SetBinding(Label.TextProperty, "Name");
                    stack1.Children.Add(lb2);
                    stack.Children.Add(stack1);
                    return stack;
                })
                };
            Shell.SetSearchHandler(this, search);
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

        private void LaptopsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Laptop;
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