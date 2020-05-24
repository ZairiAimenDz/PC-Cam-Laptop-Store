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
        public Step1(bool back = false)
        {
            InitializeComponent();
            if (back)
            {
                Animation = new Rg.Plugins.Popup.Animations.ScaleAnimation() {PositionIn=Rg.Plugins.Popup.Enums.MoveAnimationOptions.Left,
                    PositionOut=Rg.Plugins.Popup.Enums.MoveAnimationOptions.Right
                };
            }
            laptop = new Laptop();
        }

        private async void NextButton_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.RemovePageAsync(this);
            await PopupNavigation.Instance.PushAsync(new Step2());
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