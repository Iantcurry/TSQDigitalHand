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
    public partial class GameMainPage : ContentPage
    {
        public GameCardData GameData { get; set; }
        public SettingsClass settings { get; set; }
        public double _textsize;
        public double TextSize
        {
            get { return _textsize; }
            set { _textsize = value; OnPropertyChanged(); }
        }

        public GameMainPage(GameCardData startdata, SettingsClass _settings)
        {
            // Set Screen Data
            GameData = startdata;
            settings = _settings;

            // Setup settings values as needed
            TextSize = settings.FontSize;

            InitializeComponent();

            // Adjust objects as necessary
            // Should be nothing here

            BindingContext = this;
        }

        public GameMainPage()
        {

        }

        public async void OnPlayerInfo(object sender, EventArgs e)
        {
            // Call player info screen, pass player cards
            var page = new PlayerInfo(GameData.AllCards, GameData.PlayerCards, GameData.playerData, settings);
            await Navigation.showpageasdialog(page);
            GameData.playerData = page.playerData;
        }

        public void OnPlayerCards(object sender, EventArgs e)
        {
            // Call player card screen, pass player deck/hand/graveyard
        }

        public void OnVillage(object sender, EventArgs e)
        {
            // Call village screen, pass player deck/hand/graveyard and Town cards
        }

        public void OnDungeon(object sender, EventArgs e)
        {
            // Call dungeon screen, pass Dungeon cards, and rooms
        }

        public async void OnCancel(object sender, EventArgs e)
        {
            // Add warning here??
            // Close Page back to main menu
            await Navigation.PopModalAsync();
        }
    }
}