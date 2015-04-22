using System;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.XamForms;
using Toasts.Forms.Plugin.Abstractions;

using Splat;


using Xamarin.Forms;
using Akavache;
using Akavache.Sqlite3;
using System.IO;
using Xamarin;

namespace StarterMobile.Core
{
    public class AppBootstrapper : ReactiveObject, IScreen, IEnableLogger
    {
        public AppBootstrapper()
        {
            Router = new RoutingState();
            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));

            RegisterAkavache();
            RegisterServices();
            RegisterViewModels();

            UserError.RegisterHandler(ue =>
            {
                var notificator = DependencyService.Get<IToastNotificator>();
                notificator.Notify(
                    ToastNotificationType.Error, 
                    ue.ErrorMessage, 
                    ue.InnerException.ToString(), 
                    TimeSpan.FromSeconds(20));

                this.Log().ErrorException(ue.ErrorMessage, ue.InnerException);

                return Observable.Return(RecoveryOptionResult.CancelOperation);
            });

//            Router.Navigate.Execute(new HomeViewModel());
        }

        private void OnUnhandledException()
        {
//            if (Debugger.IsAttached)
//                return;
//
//            this.Log().FatalException("An unhandled exception occurred, opening the crash report", e.Exception);
            
        }

        private static void RegisterViewModels()
        {
            using (var handle = Insights.TrackTime(AppMetrics.AppBootstrapRegistrationTime("viewmodels")))
            {
                this.Log().Info("Registering ViewModels...");

                //            Locator.CurrentMutable.Register(() => new HomePage(), typeof(IViewFor<HomeViewModel>));

                this.Log().Info("ViewModels have been registered.");
            }
        }

        private static void RegisterServices()
        {
            using (var handle = Insights.TrackTime(AppMetrics.AppBootstrapRegistrationTime("services")))
            {
                this.Log().Info("Registering Services...");

                // Locator.CurrentMutable.RegisterLazySingleton(() =>);
            
                this.Log().Info("Services have been registered.");
            }
        }

        private static void RegisterAkavache()
        {
            using (var handle = Insights.TrackTime(AppMetrics.AppBootstrapRegistrationTime("akavache")))
            {
                this.Log().Info("Registering Akavache cache storages...");

                BlobCache.ApplicationName = AppInfo.ApplicationName;
                BlobCache.LocalMachine = new SQLitePersistentBlobCache(Path.Combine(AppInfo.BlobCachePath.Path, "application.db"));
                BlobCache.Secure = new SQLiteEncryptedBlobCache(Path.Combine(AppInfo.BlobCachePath.Path, "secrets.db"));
                BlobCache.InMemory = new InMemoryBlobCache();
            
                Locator.CurrentMutable.RegisterLazySingleton(() => new SQLitePersistentBlobCache(Path.Combine(AppInfo.BlobCachePath.Path, "session.db")),
                    typeof(IBlobCache), AppCacheKeys.SessionCacheContract);
            
                this.Log().Info("Akavache cache storages have been registered.");
            }
        }

        public RoutingState Router
        {
            get;
            protected set;
        }

        public Page CreateMainPage()
        {
            // NB: This returns the opening page that the platform-specific
            // boilerplate code will look for. It will know to find us because
            // we've registered our AppBootstrapper as an IScreen.
            return new RoutedViewHost();
        }
    }
}