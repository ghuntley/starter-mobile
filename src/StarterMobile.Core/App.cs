using System;

using ReactiveUI;

using Xamarin.Forms;
using Akavache;
using Splat;

namespace StarterMobile.Core
{
    public class App : Application, IEnableLogger
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
            this.Log().Info("StarterMobile has resumed from a sleeping state.");
            base.OnResume();
        }

        /// <summary>
        /// Override this method to perform actions when the application enters the sleeping state.
        /// </summary>
        protected override void OnSleep()
        {
            this.Log().Info("StarterMobile has entered into a sleeping state.");
            base.OnSleep();
        }

        /// <summary>
        /// Override this method to perform actions when the application starts.
        /// </summary>
        protected override void OnStart()
        {
            this.Log().Info("StarterMobile is starting...");
            this.Log().Info("******************************");
            this.Log().Info("**                          **");
            this.Log().Info("**       StarterMobile      **");
            this.Log().Info("**                          **");
            this.Log().Info("******************************");
            this.Log().Info("Application version: " + AppInfo.Version);
//            this.Log().Info("OS Version: " + Environment.OSVersion.VersionString);
//            this.Log().Info("Current culture: " + CultureInfo.InstalledUICulture.Name);
            
            base.OnStart();
        }
    }
}