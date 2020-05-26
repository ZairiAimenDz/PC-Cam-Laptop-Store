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

namespace PCcamAdmin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Step1Details : PopupPage
    {
        public Step1Details(Laptop lp)
        {
            InitializeComponent();
            BindingContext = lp;
            Photos.ItemsSource = lp.imgs;
        }
        protected override bool OnBackButtonPressed()
        {
            return false;
        }
    }
}