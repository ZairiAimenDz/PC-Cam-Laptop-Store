using Firebase.Database;
using Firebase.Database.Query;
using PCcamAdmin.Models;
using PCcamAdmin.Popup;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace PCcamAdmin.Data
{
    class ItemSearch : SearchHandler
    {
        protected override async void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                FirebaseHelper firebaseHelper = new FirebaseHelper();
                ItemsSource = (await firebaseHelper.Get_Items())
                    .Where(l => l.Name.ToLower().Contains(newValue.ToLower()) || l.Brand.ToLower().Contains(newValue.ToLower()))
                    .ToList();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
            await PopupNavigation.Instance.PushAsync(new Step1(item as Laptop,true));
        }
    }
}
