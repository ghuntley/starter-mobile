﻿using System;

using ReactiveUI;

using Xamarin.Forms;

namespace StarterMobile.Core
{
    public class App : Application
    {
        public App()
        {
            var bootstrapper = RxApp.SuspensionHost.GetAppState<AppBootstrapper>();

            MainPage = bootstrapper.CreateMainPage();
        }

        /// <summary>
        /// Override this method to perform actions when the application resumes from a sleeping state.*/
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();
        }

        /// <summary>
        /// Override this method to perform actions when the application enters the sleeping state.
        /// </summary>
        protected override void OnSleep()
        {
            base.OnSleep();
        }

        /// <summary>
        /// Override this method to perform actions when the application starts.
        /// </summary>
        protected override void OnStart()
        {
            base.OnStart();
        }
    }
}