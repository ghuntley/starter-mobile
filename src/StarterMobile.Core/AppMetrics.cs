using System;

namespace StarterMobile.Core
{
    /// <summary>
    /// All metrics are prefixed with a namespace which is used to denote which
    /// platform the application the application is running on:
    ///
    /// <platform>.<applicationname>
    /// 
    /// Nouns are used to define the target and past tense verbs to define the action
    /// which is a very useful convention when you need to nest metrics:
    ///
    /// <namespace>.<instrumented section>.<target (noun)>.<action (past tense verb)>
    /// 
    /// (time)        akavache.query_time
    /// (counter)     akavache.query.<appCacheKey>
    /// (time)        bootstrapper.akavache.registration_time
    /// (time)        bootstrapper.services.registration_time
    /// (time)        bootstrapper.viewmodel.registration_time
    /// (counter)     viewmodel.<viewmodelname>.[navigated|activated]
    /// 
    /// (counter)     fetchavatar.gravatar.attempted
    /// (counter)     fetchavatar.gravatar.succeeded
    /// (counter)     fetchavatar.gravatar.query.<emailaddress>
    /// (timer)       fetchavatar.gravatar.query_time
    /// (counter)     fetchavatar.gravatar.failure.account_not_found
    /// (counter)     fetchavatar.gravatar.failure.authentication_failed
    /// (counter)     fetchavatar.gravatar.failure.query_failed
    
    /// </summary>
    public static class AppMetrics
    {
        private static string StandardPrefix()
        {
            return String.Format("{0}.", AppInfo.ApplicationName).ToLowerInvariant();
        }

        public static string AppBootstrapRegistrationTime(string service)
        {
            return StandardPrefix() + service.ToLowerInvariant() + ".registration_time";
        }
    }
}

