﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCCamdz.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class About : ContentPage
    {
        public About()
        {
            InitializeComponent();
        }

        [Obsolete]
        private void Button_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://maps.app.goo.gl/oBCb73xAhYa5VWeQ8"));
        }
    }
}