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
    public partial class Step3 : PopupPage  
    {
        public Step3(bool back=false)
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

            await PopupNavigation.Instance.PushAsync(new Step2(true));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}