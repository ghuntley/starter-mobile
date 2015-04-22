using System;
using Conditions;

namespace StarterMobile.Core
{
    /// <summary>
    /// This class contains the used keys for Akavache
    /// </summary>
    public static class AppCacheKeys
    {
        /// <summary>
        /// This is the key for the changelog that is shown after the application is updated.
        /// </summary>
        public const string Changelog = "changelog";

        /// <summary>
        /// Contract for Splat to locate the session cache.
        /// </summary>
        public const string SessionCacheContract = "sessionCache";
        
        public const string FoobarPrefix = "foobar";

 
        public static string GetKeyForFoobar(string query)
        {
            Condition.Requires(query).IsNotNullOrWhiteSpace();

            return FoobarPrefix + query.ToLowerInvariant();
        }

    }
}