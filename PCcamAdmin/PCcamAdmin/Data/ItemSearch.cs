﻿using Firebase.Database;
using Firebase.Database.Query;
using PCcamAdmin.Models;
using PCcamAdmin.Popup;
using PCcamAdmin.Views;
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
            try { 
            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                FirebaseHelper firebaseHelper = new FirebaseHelper();
                ItemsSource = (await firebaseHelper.Get_Items())
                    .Where(l =>
                    {
                        return string.Concat(l.Name, " ", l.Brand , " ",l.proc.name," ",l.graphics).ToLower().Split().Intersect(newValue.ToLower().Split()).Count() == newValue.ToLower().Split().Count();
                    })
                    .ToList();
                }
            }
            catch
            {
                ItemsSource = null;
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
            await PopupNavigation.Instance.PushAsync(new Step1Details(item as Laptop));
        }
    }
}
