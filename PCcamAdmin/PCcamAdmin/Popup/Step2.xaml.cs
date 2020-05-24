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
    public partial class Step2 : PopupPage  
    {
        public Step2(bool back = false)
        {
            InitializeComponent();
            if (back)
            {
                Animation = new Rg.Plugins.Popup.Animations.ScaleAnimation()
                {
                    PositionIn = Rg.Plugins.Popup.Enums.MoveAnimationOptions.Left,
                    PositionOut = Rg.Plugins.Popup.Enums.MoveAnimationOptions.Right
                };
            }
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            Animation = new Rg.Plugins.Popup.Animations.ScaleAnimation()
            {
                PositionIn = Rg.Plugins.Popup.Enums.MoveAnimationOptions.Left,
                PositionOut = Rg.Plugins.Popup.Enums.MoveAnimationOptions.Right
            };
            await PopupNavigation.Instance.RemovePageAsync(this);

            await PopupNavigation.Instance.PushAsync(new Step1(true));
        }

        private async void NextButton_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.RemovePageAsync(this);
            await PopupNavigation.Instance.PushAsync(new Step3());
        }
    }
}