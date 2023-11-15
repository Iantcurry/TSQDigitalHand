using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            // Call player info screen, pass player cards, player data, and All Cards
            var page = new PlayerInfo(GameData.AllCards, GameData.PlayerCards, GameData.playerData, settings);
            await Navigation.showpageasdialog(page);
            GameData.playerData = page.playerData;
        }

        public async void OnPlayerCards(object sender, EventArgs e)
        {
            // Call player card screen, pass player cards, player data(?), and All Cards
            var page = new PlayerCardsPage(GameData, settings);
            await Navigation.showpageasdialog(page);
            GameData = page.GameData;

        }

        public async void OnVillage(object sender, EventArgs e)
        {
            // Call village screen, pass player deck/hand/graveyard and Town cards
            var page = new VillageMainPage(GameData, settings);
            await Navigation.showpageasdialog(page);
            GameData = page.GameData;
        }

        public async void OnDungeon(object sender, EventArgs e)
        {
            // Call dungeon screen, pass Dungeon cards, and rooms
            var page = new DungeonMainPage(GameData, settings);
            await Navigation.showpageasdialog(page);
            GameData = page.GameData;
        }

        public async void OnSettings(object sender, EventArgs e)
        {
            // Call Settings Page
            var page = new Settings(settings);
            await Navigation.showpageasdialog(page);

            // Update Settings
            TextSize = settings.FontSize;
        }

        public async void OnCancel(object sender, EventArgs e)
        {
            // Add warning here??
            var popup = new ExitWarningPopup(settings);
            var waithandle = new EventWaitHandle(false, EventResetMode.AutoReset);
            popup.Disappearing += (s, f) =>
            {
                waithandle.Set();
            };
            await Navigation.PushPopupAsync(popup);
            //System.Diagnostics.Debug.WriteLine(navigation.ModalStack.Count);
            await Task.Run(() => waithandle.WaitOne());

            // Close Page back to main menu
            if (popup.verification)
            {
                await Navigation.PopModalAsync();
            }
        }
    }
}