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
    public partial class DiscardMainPage : ContentPage
    {
        public GameCardData CardData { get; set; }
        public SettingsClass settings { get; set; }
        public double _textsize;
        public double TextSize
        {
            get { return _textsize; }
            set { _textsize = value; OnPropertyChanged(); }
        }

        public DiscardMainPage(GameCardData data, SettingsClass _settings)
        {
            CardData = data;
            settings = _settings;

            TextSize = settings.FontSize;

            InitializeComponent();

            BindingContext = this;
            UpdateTitle();
        }

        public DiscardMainPage()
        {

        }

        public void UpdateTitle()
        {
            lbl_MenuTitle.Text = "Card Count: " + CardData.PlayerGraveyard.Count.ToString();
        }

        public async void OnCancel(object sender, EventArgs e)
        {
            // Make sure Game data is fully updated
            // should be done by each function.

            // Close Page back to main menu
            await Navigation.PopModalAsync();
        }

        public async void OnView(object sender, EventArgs e)
        {
            // Open CardAction page with player hand
            var page = new CardActionPage(CardData, settings, CardData.PlayerGraveyard, CardData.PlayerDeck, CardData.PlayerGraveyard, "Graveyard");
            await Navigation.showpageasdialog(page);

            // Update player card state
            CardData = page.GameData;
            CardData.PlayerGraveyard = page.Cards;
            CardData.PlayerDeck = page.Draw;

            UpdateTitle();
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