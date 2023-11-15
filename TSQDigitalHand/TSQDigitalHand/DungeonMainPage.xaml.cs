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
    public partial class DungeonMainPage : ContentPage
    {
        public GameCardData GameData { get; set; }
        public SettingsClass settings { get; set; }
        public double _textsize;
        public double TextSize
        {
            get { return _textsize; }
            set { _textsize = value; OnPropertyChanged(); }
        }

        public DungeonMainPage(GameCardData data, SettingsClass _settings)
        {
            GameData = data;
            settings = _settings;

            TextSize = settings.FontSize;

            InitializeComponent();

            BindingContext = this;
        }

        public DungeonMainPage()
        {

        }

        public async void OnWilderness(object sender, EventArgs e)
        {
            var page = new DungeonRoomPage(GameData, settings, "Wilderness");
            await Navigation.showpageasdialog(page);

            GameData = page.GameData;
        }

        public async void OnFloor1(object sender, EventArgs e)
        {
            var page = new DungeonRoomPage(GameData, settings, "Level_1_1");
            await Navigation.showpageasdialog(page);

            GameData = page.GameData;
        }

        public async void OnFloor2(object sender, EventArgs e)
        {
            var page = new DungeonRoomPage(GameData, settings, "Level_2_1");
            await Navigation.showpageasdialog(page);

            GameData = page.GameData;
        }

        public async void OnFloor3(object sender, EventArgs e)
        {
            var page = new DungeonRoomPage(GameData, settings, "Level_3_1");
            await Navigation.showpageasdialog(page);

            GameData = page.GameData;
        }

        public async void OnGuardian(object sender, EventArgs e)
        {
            List<Card> chosencard = new List<Card>();
            foreach (Card c in GameData.DungeonCards)
            {
                if (c.Type.Equals("Guardian")) chosencard.Add(c);
            }

            var page = new CardSetup(new List<string>(), GameData.AllCards,
                                     chosencard, "Guardian", settings);
            await Navigation.showpageasdialog(page);
        }

        public async void OnCancel(object sender, EventArgs e)
        {
            // Make sure Game data is fully updated
            // should be done by each function.

            // Close Page back to main menu
            await Navigation.PopModalAsync();
        }

        public async void OnSettings(object sender, EventArgs e)
        {
            // Call Settings Page
            var page = new Settings(settings);
            await Navigation.showpageasdialog(page);

            // Update Settings
            TextSize = settings.FontSize;
        }

    }
}