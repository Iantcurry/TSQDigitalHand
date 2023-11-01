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
using System.Threading;

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

            //ImageFolderPath = DependencyService.Get<IGetImagePath>().Start();

            //System.Diagnostics.Debug.WriteLine(ImageFolderPath);
        }

        public interface IGetImagePath
        {
            string Start();
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


            foreach (Quest quest in _cards)
            {
                quest.MonsterGroups = new List<MonsterGroup>(quest.GetMonsterGroups());
            }
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
            settings.ImageFolderPath = Preferences.Get("ImageFolderPath", DependencyService.Get<IGetImagePath>().Start());
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

        private async Task SetMenuSizes()
        {
            SetMenuFontSizes();

            await Task.Delay(5);

            if (lb_title.FittedFontSize != -1) lb_title2.FontSize = lb_title.FittedFontSize;
            else lb_title2.FontSize = lb_title.FontSize;

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await SetMenuSizes();
        }

        private async void OnNewGameClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(Navigation.ModalStack.Count);

            var modalPage = new SetupMainPage(settings, _cards);
            await Navigation.showpageasdialog(modalPage);
            GameCardData data = modalPage.CardData;

            System.Diagnostics.Debug.WriteLine(data == null);

            // Start New Game
            if (data != null)
            {
                var page = new GameMainPage(data, settings);
                await Navigation.showpageasdialog(page);
            }
        }


    }
}
