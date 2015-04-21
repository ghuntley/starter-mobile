using System;

using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using Toasts.Forms.Plugin.Droid;

using ReactiveUI;

using StarterMobile.Core;

namespace StarterMobile.Droid
{
    [Activity(Label = "StarterMobile.Droid", Icon = "@drawable/icon_white", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        public MainActivity()
        {
            Console.WriteLine("Start");
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Forms.Init(this, bundle);
            ToastNotificatorImplementation.Init(); 


            var mainPage = RxApp.SuspensionHost.GetAppState<AppBootstrapper>().CreateMainPage();
            this.SetPage(mainPage);
        }
    }
}