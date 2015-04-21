﻿using System;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.XamForms;
using Toasts.Forms.Plugin.Abstractions;

using Splat;


using Xamarin.Forms;

namespace StarterMobile.Core
{
    public class AppBootstrapper : ReactiveObject, IScreen, IEnableLogger
    {
        public AppBootstrapper()
        {
            Router = new RoutingState();
            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));

            Locator.CurrentMutable.Register(() => new HomePage(), typeof(IViewFor<HomeViewModel>));

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

            Router.Navigate.Execute(new HomeViewModel());
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