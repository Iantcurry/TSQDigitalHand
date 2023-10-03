using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TSQDigitalHand
{
    public class SettingsClass : BindableObject
    {

        public double _fontsize = 50.0;

        public double FontSize
        {
            get { return _fontsize; }
            set { _fontsize = value; OnPropertyChanged("FontSize"); }

        }
    }
}
