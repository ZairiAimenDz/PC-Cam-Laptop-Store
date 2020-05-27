using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PCCamdz.Data;

namespace PCCamdz.Droid.Data
{
    class Helper : IHelper
    {
        public string GetFilePath(string file)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, file);
        }
    }
}