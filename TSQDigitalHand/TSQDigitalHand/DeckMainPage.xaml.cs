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
    public partial class DeckMainPage : ContentPage
    {
        public GameCardData CardData { get; set; }
        public SettingsClass settings { get; set; }
        public double _textsize;
        public double TextSize
        {
            get { return _textsize; }
            set { _textsize = value; OnPropertyChanged(); }
        }

        public DeckMainPage(GameCardData data, SettingsClass _settings)
        {
            CardData = data;
            settings = _settings;

            TextSize = settings.FontSize;

            InitializeComponent();

            BindingContext = this;
            UpdateTitle();
        }

        public void UpdateTitle()
        {
            lbl_MenuTitle.Text = "Card Count: " + CardData.PlayerDeck.Count.ToString();
        }

        public DeckMainPage()
        {

        }

        public async void OnReveal(object sender, EventArgs e)
        {
            var page = new CounterPopup(settings, CardData.PlayerDeck.Count);

            var waithandle = new EventWaitHandle(false, EventResetMode.AutoReset);
            page.Disappearing += (s, f) =>
            {
                waithandle.Set();
            };
            await Navigation.PushPopupAsync(page);
            //System.Diagnostics.Debug.WriteLine(navigation.ModalStack.Count);
            await Task.Run(() => waithandle.WaitOne());

            
            System.Diagnostics.Debug.WriteLine("Before Action");
            
            if (page.result == 1)
            {
                System.Diagnostics.Debug.WriteLine("Clicked OK");
                // Get Value, and launch card action window
                System.Diagnostics.Debug.WriteLine(page.Number);
                int num = page.Number;
                List<Card> revealedcards = new List<Card>();
                List<Card> playerdeck = new List<Card>(CardData.PlayerDeck);

                for (int i = 0; i < num; i++)
                {
                    revealedcards.Add(playerdeck[0]);
                    playerdeck.RemoveAt(0);
                }

                // Open CardAction page with player hand
                var page2 = new CardActionPage(CardData, settings, revealedcards, playerdeck, CardData.PlayerGraveyard, "Deck");
                await Navigation.showpageasdialog(page2);

                // Update player card state
                CardData = page2.GameData;
                CardData.PlayerDeck = page2.Draw;
                for (int i = page2.Cards.Count - 1; i >= 0; i--)
                {
                    CardData.PlayerDeck.Insert(0, page2.Cards[i]);
                }
                CardData.PlayerGraveyard = page2.Discard;

                UpdateTitle();
            }
            else if (page.result == 0)
            {
                System.Diagnostics.Debug.WriteLine("Clicked Cancel");
                // Do nothing, return to main deck page.
            }

        }

        public async void OnDiscard(object sender, EventArgs e)
        {
            var page = new CounterPopup(settings, CardData.PlayerDeck.Count);

            var waithandle = new EventWaitHandle(false, EventResetMode.AutoReset);
            page.Disappearing += (s, f) =>
            {
                waithandle.Set();
            };
            await Navigation.PushPopupAsync(page);
            //System.Diagnostics.Debug.WriteLine(navigation.ModalStack.Count);
            await Task.Run(() => waithandle.WaitOne());


            System.Diagnostics.Debug.WriteLine("Before Action");

            if (page.result == 1)
            {
                System.Diagnostics.Debug.WriteLine("Clicked OK");
                // Get Value, and launch card action window
                System.Diagnostics.Debug.WriteLine(page.Number);
                int num = page.Number;
                List<Card> discardedcards = new List<Card>();
                List<Card> playerdeck = new List<Card>(CardData.PlayerDeck);

                for (int i = 0; i < num; i++)
                {
                    discardedcards.Add(playerdeck[0]);
                    playerdeck.RemoveAt(0);
                }

                // Open CardAction page with player hand
                var page2 = new CardActionPage(CardData, settings, discardedcards, playerdeck, CardData.PlayerGraveyard, "Discard");
                await Navigation.showpageasdialog(page2);

                // Update player card state
                CardData = page2.GameData;
                CardData.PlayerDeck = page2.Draw;
                CardData.PlayerGraveyard = page2.Discard;
                for (int i = 0; i < page2.Cards.Count; i++)
                {
                    CardData.PlayerGraveyard.Insert(0, page2.Cards[i]);
                }

                UpdateTitle();
            }
            else if (page.result == 0)
            {
                System.Diagnostics.Debug.WriteLine("Clicked Cancel");
                // Do nothing, return to main deck page.
            }
        }

        public void OnShuffle(object sender, EventArgs e)
        {
            // shuffle player deck
            Shuffler.Shuffle(CardData.PlayerDeck, new Random());
        }

        public void OnFullShuffle(object sender, EventArgs e)
        {
            // add discard to deck, and then shuffle deck
            foreach (Card c in CardData.PlayerGraveyard)
            {
                CardData.PlayerDeck.Add(c);
            }
            CardData.PlayerGraveyard.Clear();

            Shuffler.Shuffle(CardData.PlayerDeck, new Random());

            UpdateTitle();
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