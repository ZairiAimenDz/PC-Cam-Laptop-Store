using PCCamdz.Data;
using PCCamdz.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCCamdz.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllLaptops : ContentPage
    {
        private FirebaseHelper Helper = new FirebaseHelper();
        public AllLaptops()
        {
            InitializeComponent();
            LaptopsList_Refreshing(null, null);
            var search = new ItemSearch()
            {
                Placeholder = "Search For Laptop ... ",
                ItemTemplate = new DataTemplate(() =>
                {
                    StackLayout stack = new StackLayout() { Padding = new Thickness(10), Orientation = StackOrientation.Horizontal, Margin = new Thickness(2) };
                    var image = new Image() { HeightRequest = 64, WidthRequest = 64 };
                    image.SetBinding(Image.SourceProperty, "mainimg");
                    stack.Children.Add(image);
                    var stack1 = new StackLayout();
                    var lb = new Label()
                    { FontSize = 14, FontAttributes = FontAttributes.Bold, TextColor = Color.Black };
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

        private async void LaptopsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var laptop = e.Item as Laptop;
            await Shell.Current.Navigation.PushAsync(new DetailsPage(laptop));
        }

        private async void LaptopsList_Refreshing(object sender, EventArgs e)
        {
            LaptopsList.IsRefreshing = true;
            try
            {
                var all = await Helper.Get_Items();
                all.Reverse();
                LaptopsList.ItemsSource = new ObservableCollection<Laptop>(all);
            }
            catch
            {
                await DisplayAlert("Error", "Check Your Internet Connection", "ok");
            }
            LaptopsList.IsRefreshing = false;
        }
    }
}