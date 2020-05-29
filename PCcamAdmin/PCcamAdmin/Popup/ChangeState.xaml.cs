using PCcamAdmin.Data;
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
    public partial class ChangeState : PopupPage
    {
        private readonly Laptop lp;
        private FirebaseHelper Helper = new FirebaseHelper();
        public ChangeState(Laptop lp)
        {
            InitializeComponent();
            this.lp = lp;
            BindingContext = lp;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            await Helper.UpdateState(lp.date,Price.Text,issold.IsChecked);
            await DisplayAlert("Item Updated","The Item Update Process Was A Success","ok");
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var del = await DisplayAlert("Deletion is Permanent", "Are You Sure You Want To Delete This Item", "Yes","No");
            try { 
            if (del) { 
                    await Helper.DeleteLaptop(lp.date);
                    await DisplayAlert("Sucess", "Item Deleted Successfully", "ok");
                }
            }
            catch
            {
                await DisplayAlert("Error", "There Has Been An Error Check Your Internet Connection Again", "ok");
            }
        }
    }
}