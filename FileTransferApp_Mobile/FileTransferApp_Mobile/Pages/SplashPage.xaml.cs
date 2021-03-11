﻿using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FileTransferApp_Mobile.Resources;
namespace FileTransferApp_Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPage : ContentPage
    {

        int SplashScreenDisplayTime = 2000; // in ms

        public SplashPage()
        {
            InitializeComponent();            
        }
        protected override void OnAppearing()
        {
           // Task.Run(() =>
            //{
                Main.StartServer();
                string deviceIP, deviceHostname;
                NetworkScanner.GetDeviceAddress(out deviceIP, out deviceHostname);
                if (!NetworkScanner.IsDevicePublished)
                    NetworkScanner.PublishDevice();
                NetworkScanner.ScanAvailableDevices();
                Parameters.Init();

            Thread.CurrentThread.CurrentUICulture = new CultureInfo("tr");

            AppResources.Culture = new CultureInfo("tr");
            // });
            base.OnAppearing();
        }
        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Thread.Sleep(SplashScreenDisplayTime); // Simulate a long loading process on app startup.
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Application.Current.MainPage = new NavigationPage(new ActionPage());
                });
            });
        }

    }
}