
using TSQDigitalHand.Droid;
using Xamarin.Forms;
using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Environment = Android.OS.Environment;

[assembly: Dependency(typeof(GetImagePath))]

namespace TSQDigitalHand.Droid
{

        public class GetImagePath : MainPage.IGetImagePath
        {

        public static string path;

        public string Start()
        {
            path = Environment.GetExternalStoragePublicDirectory(Environment.DirectoryDocuments).ToString();
            //path = "/storage/emulated/0/Documents";
            path += "/TQDH/Images/";

            return path;
        }
    }
}