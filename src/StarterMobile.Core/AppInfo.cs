using System;
using System.Reflection;
using PCLStorage;
using System.IO;

namespace StarterMobile.Core
{
    public static class AppInfo
    {
        public static readonly IFolder ApplicationRootPath;
        public static readonly IFolder BlobCachePath;
        //        public static readonly string LogFilePath;
        public static readonly Version Version;

        static AppInfo()
        {
            ApplicationRootPath = FileSystem.Current.LocalStorage;
            BlobCachePath = ApplicationRootPath.CreateFolderAsync("BlobCache", CreationCollisionOption.OpenIfExists).Result;
            
//            LogFilePath = Path.Combine(ApplicationRootPath, "Log.txt");
            Version = Assembly.Load().GetName().Version;
        }
    }
}

