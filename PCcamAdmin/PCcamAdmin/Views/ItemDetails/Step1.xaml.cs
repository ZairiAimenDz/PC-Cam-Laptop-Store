using PCcamAdmin.Models;
using PCcamAdmin.Popup;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCcamAdmin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Step1Details : PopupPage
    {
        private readonly Laptop lp;

        public Step1Details(Laptop lp)
        {
            InitializeComponent();
            BindingContext = lp;
            Photos.ItemsSource = lp.imgs;
            this.lp = lp;
        }

        private async void Quit()
        {
            await PopupNavigation.Instance.PopAsync();
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAllAsync();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new ChangeState(lp));
        }
    }
}