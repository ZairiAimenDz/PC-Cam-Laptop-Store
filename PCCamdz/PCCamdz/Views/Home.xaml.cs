using PCCamdz.Data;
using PCCamdz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCCamdz.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {

        private FirebaseHelper helper = new FirebaseHelper();
        private Elements element = new Elements();

        public Home()
        {
            InitializeComponent();
            RefreshView_Refreshing(null, null);
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

        private async void RefreshView_Refreshing(object sender, EventArgs e)
        {
            var laps= await helper.Get_Items();
            laps.Reverse();
            element.LastOne = laps.First();
            element.Under6 = laps.Where(l =>
            {
                return double.Parse(l.price) < 60000;
            }).FirstOrDefault();
            element.WithI7 = laps.Where(l =>
            {
                return l.proc.name.ToLower().Contains("i7");
            }).FirstOrDefault();
            Create_Element(LastOne,element.LastOne);
            Create_Element(Under6, element.Under6);
            Create_Element(Withi7, element.WithI7);
            if (sender != null)
            {
                ((RefreshView)sender).IsRefreshing = false;
            }
        }

        private void Create_Element(Frame frame,Laptop lp)
        {
            if (lp == null) return;
            var btn = new Button()
            {
                Text="See More",
                CornerRadius = 15,
            };
            
            frame.Content = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                HeightRequest = 120,
                Children ={
                    new Image {Source = lp.mainimg},
                    new StackLayout()
                    {
                        HorizontalOptions = LayoutOptions.StartAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        Children =
                        {
                            new Label(){Text = lp.Brand,FontAttributes=FontAttributes.Bold,FontSize=14},
                            new Label(){Text = lp.Name, FontSize=18,TextColor = Color.Black},
                            btn
                        }
                    }
                }
            };
            btn.Clicked += async (sender, args) =>
            {
                await Shell.Current.Navigation.PushAsync(new DetailsPage(lp));
            };
        }

       
    }
    public class Elements
    {
        public Laptop LastOne { get; set; }
        public Laptop Under6 { get; set; }
        public Laptop WithI7 { get; set; }
    }
}