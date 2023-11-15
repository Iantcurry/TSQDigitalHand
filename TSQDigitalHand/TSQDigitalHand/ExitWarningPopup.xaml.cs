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
    public partial class ExitWarningPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public double _textsize;
        public double TextSize
        {
            get { return _textsize; }
            set { _textsize = value; OnPropertyChanged(); }
        }
        public bool verification;
        public ExitWarningPopup(SettingsClass _settings)
        {
            TextSize = _settings.FontSize;
            verification = false;

            InitializeComponent();

            BindingContext = this;
        }

        public ExitWarningPopup()
        {

        }

        public async void btn_Cancel_Clicked(object sender, EventArgs e)
        {
            verification = false;
            await Navigation.PopPopupAsync();

        }

        public async void btn_OK_Clicked(object sender, EventArgs e)
        {
            verification=true;
            await Navigation.PopPopupAsync();
        }
    }
}