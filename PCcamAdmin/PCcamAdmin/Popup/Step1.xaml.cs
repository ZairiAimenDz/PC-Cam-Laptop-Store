using PCcamAdmin.Models;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCcamAdmin.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Step1 : PopupPage
    {
        private Laptop laptop;
        private readonly bool back;

        public Step1(Laptop lp=null,bool back = false)
        {
            InitializeComponent();
            if (back)
            {
                Animation = new Rg.Plugins.Popup.Animations.ScaleAnimation() {PositionIn=Rg.Plugins.Popup.Enums.MoveAnimationOptions.Left,
                    PositionOut=Rg.Plugins.Popup.Enums.MoveAnimationOptions.Right
                };
            }
            if (lp == null)
            {
                laptop = new Laptop();
            }
            else
            {
                laptop = lp;
                if (back)
                {
                    Brand.Text = laptop.Brand;
                    Name.Text = laptop.Name;
                    Price.Text = lp.price;
                }
            }

            this.back = back;
        }

        /*# When Lp Isn't Null Fill out the element
         */


        private async void NextButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Name.Text) || string.IsNullOrEmpty(Brand.Text))
            {
                if (string.IsNullOrEmpty(Brand.Text))
                {
                    Brand.BackgroundColor = Color.Red;
                }
                else
                {
                    Brand.BackgroundColor = Color.Default;
                }
                if (string.IsNullOrEmpty(Name.Text))
                {
                    Name.BackgroundColor = Color.Red;
                }
                else
                {
                    Name.BackgroundColor = Color.Default;
                }
            }
            else
            {
                laptop.Brand = Brand.Text;
                laptop.Name = Name.Text;
                laptop.price = Price.Text;
                await PopupNavigation.Instance.RemovePageAsync(this);
                await PopupNavigation.Instance.PushAsync(new Step2(laptop,back));
            }
        }

        private async void ExitButton_Clicked(object sender, EventArgs e)
        {
            Animation = new Rg.Plugins.Popup.Animations.ScaleAnimation()
            {
                PositionIn = Rg.Plugins.Popup.Enums.MoveAnimationOptions.Left,
                PositionOut = Rg.Plugins.Popup.Enums.MoveAnimationOptions.Right
            };
            await PopupNavigation.Instance.PopAsync();
        }
    }
}