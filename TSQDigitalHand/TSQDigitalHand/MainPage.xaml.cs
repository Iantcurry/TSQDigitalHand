using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using Xamarin.Forms.PlatformConfiguration;
using System.Drawing;
using Forms9Patch;

namespace TSQDigitalHand
{

    public partial class MainPage : ContentPage
    {
        private SettingsClass settings;
        public List<Quest> _cards;
        public string _imageFolderPath;
        public string ImageFolderPath
        {
            get { return _imageFolderPath; }
            set { _imageFolderPath = value; OnPropertyChanged(); }
        }

        public MainPage()
        {
            InitializeComponent();

            LoadJSONData();

            settings = new SettingsClass();
            LoadSettings();
            SetMenuSizes();

            ImageFolderPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            System.Diagnostics.Debug.WriteLine(ImageFolderPath);
        }

        public void LoadJSONData()
        {
            RootValue rootValue = new RootValue();
            _cards = new List<Quest>();
            //_cards = JsonConvert.DeserializeObject<Card>("Cards.json");
            string jsonString;
            string jsonFileName = "Cards.json";
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
            using (var reader = new StreamReader(stream))
            {
                jsonString = reader.ReadToEnd();
            }

            rootValue = JsonConvert.DeserializeObject<RootValue>(jsonString);
            _cards = new List<Quest>(rootValue.Quests);

            //System.Diagnostics.Debug.WriteLine(_cards.Count.ToString() + " " +
            //    _cards[0].Heroes.Count.ToString() + " " +
            //    _cards[0].Spells.Count.ToString() + " " + _cards[0].Weapons.Count.ToString() + " " +
            //    _cards[0].Items.Count.ToString() + " " + _cards[0].Monsters.Count.ToString() + " " +
            //    _cards[0].Guardians.Count.ToString() + " : End");

        }

        public class RootValue
        {
            public List<Quest> Quests;

            public RootValue()
            {
                Quests = new List<Quest>();
            }
        }

        private void OnSettingsClicked(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new Settings(settings));
        }

        public void LoadSettings()
        {
            settings.FontSize = Preferences.Get("FontSize", 50.0);
        }

        private void OnCardViewCliked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CardViewerListPage(settings, _cards));
        }

        private void SetMenuFontSizes()
        {
            lb_title.FontSize = settings.FontSize;
            lb_subtitle.FontSize = settings.FontSize;
            //lb_title2.FontSize = settings.FontSize;
            lb_subtitle2.FontSize = settings.FontSize;
            btn_cardview.FontSize = settings.FontSize;
            btn_newgame.FontSize = settings.FontSize;
            btn_settings.FontSize = settings.FontSize;

        }

        private async void SetMenuSizes()
        {
            SetMenuFontSizes();

            await Task.Delay(5);

            if (lb_title.FittedFontSize != -1) lb_title2.FontSize = lb_title.FittedFontSize;
            else lb_title2.FontSize = lb_title.FontSize;


            System.Diagnostics.Debug.WriteLine(lb_title.FittedFontSize.ToString());
            System.Diagnostics.Debug.WriteLine(lb_title2.FontSize.ToString());
            System.Diagnostics.Debug.WriteLine(rw_row4.Height.ToString());

            //var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            //double factor = mainDisplayInfo.Width / 160 * 2;

            //double textsize = settings.FontSize;
            //double titlesize = settings.FontSize;
            //if (titlesize > (mainDisplayInfo.Width / factor)) titlesize = mainDisplayInfo.Width / factor;

            //lb_title.FontSize = titlesize;
            //lb_subtitle.FontSize = titlesize;
            //btn_cardview.FontSize = textsize;
            //btn_newgame.FontSize = textsize;
            //btn_settings.FontSize = textsize;

            //rw_row1.Height = (titlesize * 2) + 50;
            //rw_row2.Height = (titlesize * 2) + 60;

            //if (rw_row1.Height.Value > lb_title.Height) 
            //if (lb_title.Height != -1) rw_row1.Height = lb_title.Height;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            SetMenuSizes();
        }
    }
}
