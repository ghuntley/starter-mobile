using System;
using System.Reflection;
using PCLStorage;
using System.IO;

namespace StarterMobile.Core
{
    public static class AppInfo
    {
        public const string ApplicationName = "StarterMobile";
        public static readonly IFolder ApplicationRootPath;
        public static readonly IFolder BlobCachePath;
        //        public static readonly string LogFilePath;
        public const string XamarinInsightsApiKey = "be9792668dec2b6c361d688fa2a44da86f98ced7";

        static AppInfo()
        {
            ApplicationRootPath = FileSystem.Current.LocalStorage;
            BlobCachePath = ApplicationRootPath.CreateFolderAsync("BlobCache", CreationCollisionOption.OpenIfExists).Result;
            
//            LogFilePath = Path.Combine(ApplicationRootPath, "Log.txt");
        }
    }
}
