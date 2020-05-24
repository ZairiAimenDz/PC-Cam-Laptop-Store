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
    public partial class Step2 : PopupPage  
    {
        private readonly Laptop lp;
        private readonly bool back;

        public Step2(Laptop lp,bool back = false)
        {
            InitializeComponent();

            this.lp = lp;
            this.back = back;
            if (back)
            {
                Animation = new Rg.Plugins.Popup.Animations.ScaleAnimation()
                {
                    PositionIn = Rg.Plugins.Popup.Enums.MoveAnimationOptions.Left,
                    PositionOut = Rg.Plugins.Popup.Enums.MoveAnimationOptions.Right
                };
                ProcessorName.Text = lp.proc.name;
                Cores.Value = lp.proc.cores;
                Threads.Value = lp.proc.threads;
                ClockSpeed.Value = lp.proc.clockspeed;
                Cache.Text = lp.proc.cache;
            }
            else
            {
                lp.proc = new Processor();
            }

        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            Animation = new Rg.Plugins.Popup.Animations.ScaleAnimation()
            {
                PositionIn = Rg.Plugins.Popup.Enums.MoveAnimationOptions.Left,
                PositionOut = Rg.Plugins.Popup.Enums.MoveAnimationOptions.Right
            };

            lp.proc.name = ProcessorName.Text;
            lp.proc.cores = (int)Cores.Value;
            lp.proc.threads = (int)Threads.Value;
            lp.proc.clockspeed = ClockSpeed.Value;
            lp.proc.cache = Cache.Text;

            await PopupNavigation.Instance.RemovePageAsync(this);
            await PopupNavigation.Instance.PushAsync(new Step1(lp,true));
        }

        private async void NextButton_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(ProcessorName.Text) || Cores.Value == 0 || Threads.Value == 0)
            {
                if (string.IsNullOrEmpty(ProcessorName.Text))
                {
                    ProcessorName.BackgroundColor = Color.Red;
                }
                else
                {
                    ProcessorName.BackgroundColor = Color.Default;
                }
            }
            else {
                lp.proc.name = ProcessorName.Text;
                lp.proc.cores = (int)Cores.Value;
                lp.proc.threads = (int)Threads.Value;
                lp.proc.clockspeed = ClockSpeed.Value;
                lp.proc.cache = Cache.Text;
                await PopupNavigation.Instance.RemovePageAsync(this);
                await PopupNavigation.Instance.PushAsync(new Step3(lp,back));
            }
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            try { 
            if (double.Parse(e.NewTextValue) == 0)
            {
                ((Entry)sender).BackgroundColor = Color.Red;
            }
            else
            {
                ((Entry)sender).BackgroundColor = Color.Default;
            }
            }
            catch
            {
                ((Entry)sender).BackgroundColor = Color.Red;
            }
        }
    }
}