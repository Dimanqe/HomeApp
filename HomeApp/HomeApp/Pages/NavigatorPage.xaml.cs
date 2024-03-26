﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigatorPage : ContentPage
    {
        public NavigatorPage()
        {
            InitializeComponent();
        }



        public async void GetDevice(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DevicesPage());
        }
        public async void GetClimate(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClimatePage());
        }
        public async void GetInfo(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }
        public async void GetGrid(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GridPage());
        }
        public async void GetMergedGrid(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MergeGridPage());
        }
        public async void GetPadding(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CsharpPaddingPage());
        }
    }
}