﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSSNews.Views;
using Xamarin.Forms;

namespace RSSNews
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new MainView();
            //MainPage = new ContentPage
            //{
            //    Content = new StackLayout
            //    {
            //        VerticalOptions = LayoutOptions.Center,
            //        Children = {
            //            new Label {
            //                XAlign = TextAlignment.Center,
            //                Text = "Welcome to Xamarin Forms!"
            //            },
            //            new Label {
            //                XAlign = TextAlignment.Start,
            //                Text = "Test2"
            //            }

            //        }
            //    }
            //};
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
