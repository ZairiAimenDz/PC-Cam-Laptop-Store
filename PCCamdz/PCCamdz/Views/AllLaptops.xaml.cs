using PCCamdz.Data;
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
    public partial class AllLaptops : ContentPage
    {
        public AllLaptops()
        {
            InitializeComponent();
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
    }
}