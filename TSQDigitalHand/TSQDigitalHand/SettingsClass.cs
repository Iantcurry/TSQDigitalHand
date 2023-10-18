using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TSQDigitalHand
{
    public class SettingsClass : BindableObject
    {

        public double _fontsize = 50.0;
        public string _imagefolderpath = "";

        public double FontSize
        {
            get { return _fontsize; }
            set { _fontsize = value; OnPropertyChanged("FontSize"); }

        }

        public string ImageFolderPath
        {
            get { return _imagefolderpath; }
            set { _imagefolderpath = value; OnPropertyChanged("ImageFolderPath"); }
        }
    }
}
