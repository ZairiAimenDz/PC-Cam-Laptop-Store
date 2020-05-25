using PCcamAdmin.Models;
using PCcamAdmin.Views;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCcamAdmin.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Step5 : PopupPage  
    {
        private readonly Laptop lp;

        public Step5(Laptop lp)
        {
            InitializeComponent();
            this.lp = lp;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAllAsync();
        }
    }
}