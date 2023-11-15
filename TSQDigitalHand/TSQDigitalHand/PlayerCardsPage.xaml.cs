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
    public partial class PlayerCardsPage : ContentPage
    {
        public SettingsClass AllSettings { get; set; }
        public GameCardData GameData { get; set; }
        public double _textsize;
        public double TextSize
        {
            get { return _textsize; }
            set { _textsize = value; OnPropertyChanged(); }
        }

        public PlayerCardsPage(GameCardData data, SettingsClass settings)
        {
            // Set global variables
            GameData = data;
            AllSettings = settings;

            // Set Bound variables
            TextSize = AllSettings.FontSize;

            InitializeComponent();

            // Update Local variables, or widget properties
            // Shouldn't be anything here, i don't think

            // Set Binding Context
            BindingContext = this;
        }

        public PlayerCardsPage()
        {

        }

        public async void OnCancel(object sender, EventArgs e)
        {
            // Pop window, and return to game main page
            await Navigation.PopModalAsync();
        }

        public async void OnPlayerHand(object sender, EventArgs e)
        {
            // Open CardAction page with player hand
            var page = new CardActionPage(GameData, AllSettings, GameData.PlayerHand, GameData.PlayerDeck, GameData.PlayerGraveyard, "Hand");
            await Navigation.showpageasdialog(page);
            
            // Update player card state
            GameData.PlayerHand = page.Cards;
            GameData.PlayerDeck = page.Draw;
            GameData.PlayerGraveyard = page.Discard;
        }

        public async void OnPlayerDeck(object sender, EventArgs e)
        {
            // Open DeckMainPage
            var page = new DeckMainPage(GameData, AllSettings);
            await Navigation.showpageasdialog(page);

            // Update player card state
            GameData = page.CardData;
        }

        public async void OnPlayerDiscard(object sender, EventArgs e)
        {
            // Open DeckMainPage
            var page = new DiscardMainPage(GameData, AllSettings);
            await Navigation.showpageasdialog(page);

            // Update player card state
            GameData = page.CardData;
        }

        public async void OnSettings(object sender, EventArgs e)
        {
            // Call Settings Page
            var page = new Settings(AllSettings);
            await Navigation.showpageasdialog(page);

            // Update Settings
            TextSize = AllSettings.FontSize;
        }
    }
}