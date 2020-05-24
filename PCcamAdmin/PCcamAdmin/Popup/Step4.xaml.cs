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
    public partial class Step4 : PopupPage  
    {
        private readonly Laptop lp;
        private readonly bool back;

        public Step4(Laptop lp,bool back = false)
        {
            InitializeComponent();
            this.lp = lp;
            this.back = back;
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            Animation = new Rg.Plugins.Popup.Animations.ScaleAnimation()
            {
                PositionIn = Rg.Plugins.Popup.Enums.MoveAnimationOptions.Left,
                PositionOut = Rg.Plugins.Popup.Enums.MoveAnimationOptions.Right
            };
            await PopupNavigation.Instance.RemovePageAsync(this);

            await PopupNavigation.Instance.PushAsync(new Step3(lp,true));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //# Working With Firebase
        }
    }
}