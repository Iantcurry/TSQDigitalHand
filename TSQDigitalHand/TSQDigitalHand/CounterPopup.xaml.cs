using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TSQDigitalHand
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CounterPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public SettingsClass settings { get; set; }
        public double _textsize;
        public double TextSize
        {
            get { return _textsize; }
            set { _textsize = value; OnPropertyChanged(); }
        }
        public int result;
        public int _number;
        public int Number
        {
            get { return _number; }
            set { _number = value; OnPropertyChanged(); }
        }
        public int Maximum { get; set; }
        public CounterPopup(SettingsClass _settings, int maximum)
        {
            settings = _settings;
            Number = 0;
            result = -1;

            TextSize = settings.FontSize;
            Maximum = maximum;

            InitializeComponent();

            BindingContext = this;
        }

        public CounterPopup()
        {

        }

        private void btn_OK_Clicked(object sender, EventArgs e)
        {
            result = 1;
            Navigation.PopPopupAsync();
        }

        private void btn_Cancel_Clicked(object sender, EventArgs e)
        {
            result = 0;
            Navigation.PopPopupAsync();
        }

        private void btn_Add_Clicked(object sender, EventArgs e)
        {
            if (Number != Maximum) Number++;
        }

        private void btn_Sub_Clicked(object sender, EventArgs e)
        {
            if (Number != 0) Number--;
        }
    }
}