using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace TSQDigitalHand
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public double TextSize = 0;
        public SettingsClass _settings { get; set; }

        public string ImageFolderPath = "";

        public Settings(SettingsClass currSettings)
        {
            _settings = currSettings;


            InitializeComponent();

            sld_textsize.Value = _settings.FontSize;
            TextSize = _settings.FontSize;
            ImageFolderPath = _settings.ImageFolderPath;
            ent_ImageFolder.Text = _settings.ImageFolderPath;

        }

        private void Sld_textsize_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            TextSize = sld_textsize.Value;
            
        }

        private async void Btn_Cancel_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        private void btn_Accept_Clicked(object sender, EventArgs e)
        {
            // Save Settings Here
            SaveSettings();
        }

        private async void btn_OK_Clicked(object sender, EventArgs e)
        {
            // Save SEttings HEre
            SaveSettings();
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        public void SaveSettings()
        {
            // Update Values
            _settings.FontSize = TextSize;
            _settings.ImageFolderPath = ImageFolderPath;

            // Set Settings
            Preferences.Set("FontSize", _settings.FontSize);
            Preferences.Set("ImageFolderPath", _settings.ImageFolderPath);
        }

        private void ent_ImageFolder_TextChanged(object sender, TextChangedEventArgs e)
        {
            ImageFolderPath = ent_ImageFolder.Text;
        }
    }
}