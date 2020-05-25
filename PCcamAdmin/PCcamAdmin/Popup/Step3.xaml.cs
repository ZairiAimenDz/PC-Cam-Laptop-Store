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
    public partial class Step3 : PopupPage  
    {
        private readonly Laptop lp;
        private readonly bool back;

        public Step3(Laptop lp,bool back=false)
        {
            InitializeComponent();
            this.lp = lp;
            if (back)
            {
                Animation = new Rg.Plugins.Popup.Animations.ScaleAnimation()
                {
                    PositionIn = Rg.Plugins.Popup.Enums.MoveAnimationOptions.Left,
                    PositionOut = Rg.Plugins.Popup.Enums.MoveAnimationOptions.Right
                };
                Graphics.Text = lp.graphics;
                OS.SelectedItem = lp.Os;
                RAM.Value = lp.RAM;
                Storage.Text = lp.storage;
                Screen.Text = lp.screen;
            }
            this.back = back;

        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            Animation = new Rg.Plugins.Popup.Animations.ScaleAnimation()
            {
                PositionIn = Rg.Plugins.Popup.Enums.MoveAnimationOptions.Left,
                PositionOut = Rg.Plugins.Popup.Enums.MoveAnimationOptions.Right
            };
            lp.graphics = Graphics.Text;
            if (OS.SelectedIndex != -1)
            {
                lp.Os = OS.SelectedItem.ToString();
            }
            lp.RAM = (int)RAM.Value;
            lp.storage = Storage.Text;
            lp.screen = Screen.Text;
            await PopupNavigation.Instance.RemovePageAsync(this);
            await PopupNavigation.Instance.PushAsync(new Step2(lp,true));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Graphics.Text) || RAM.Value <= 0 || string.IsNullOrEmpty(Storage.Text) || OS.SelectedIndex == -1){
                if (string.IsNullOrEmpty(Graphics.Text)) {Graphics.BackgroundColor = Color.Red;}
                else { Graphics.BackgroundColor = Color.Red; }
             
                if (RAM.Value < 1) { RAM.BackgroundColor = Color.Red; }
                else { RAM.BackgroundColor = Color.Red; }

                if (string.IsNullOrEmpty(Storage.Text)) { Storage.BackgroundColor = Color.Red; }
                else { Storage.BackgroundColor = Color.Red; }

                if (OS.SelectedIndex == -1) { OS.BackgroundColor = Color.Red; }
                else { OS.BackgroundColor = Color.Red; }

                if (string.IsNullOrEmpty(Screen.Text)) { Screen.BackgroundColor = Color.Red; }
                else { Screen.BackgroundColor = Color.Red; }

            }
            else { 
                lp.graphics = Graphics.Text;
                lp.Os = OS.SelectedItem.ToString();
                lp.RAM = (int)RAM.Value;
                lp.storage = Storage.Text;
                lp.screen = Screen.Text;
                await PopupNavigation.Instance.RemovePageAsync(this);
                await PopupNavigation.Instance.PushAsync(new Step4(lp,back));
            }
        }
    }
}