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
    public partial class VillageMainPage : ContentPage
    {
        public GameCardData GameData { get; set; }
        public SettingsClass settings { get; set; }
        public double _textsize;
        public double TextSize
        {
            get { return _textsize; }
            set { _textsize = value; OnPropertyChanged(); }
        }

        public VillageMainPage(GameCardData data, SettingsClass _settings)
        {
            GameData = data;
            settings = _settings;

            TextSize = settings.FontSize;

            InitializeComponent();

            BindingContext = this;
        }

        public VillageMainPage()
        {

        }

        public async void OnHero(object sender, EventArgs e)
        {
            // Create set of heroes at all levels
            List<Card> heroes = new List<Card>((GameData.TownCards).Where(c => c.Type.Equals("Hero")).ToList());

            int n = heroes.Count;

            for (int i = 2; i < 5; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    heroes.Add(new Hero(heroes[j].Name, i));
                }
            }

            heroes.Sort();
            // Call CardActionPage
            //foreach (Card c in heroes)
            //{
            //    System.Diagnostics.Debug.WriteLine(c.Name + " : " + c.CardLevel.ToString());
            //}
            var page = new CardActionPage(GameData, settings, heroes, GameData.PlayerDeck, GameData.PlayerGraveyard, "Village");
            await Navigation.showpageasdialog(page);
            GameData = page.GameData;
            GameData.PlayerDeck = page.Draw;
            GameData.PlayerGraveyard = page.Discard;

            
        }

        public async void OnMarket(object sender, EventArgs e)
        {
            // Create set of market items
            List<Card> market = new List<Card>((GameData.TownCards).Where(c => (c.Type.Equals("Weapon") ||
                                                                                c.Type.Equals("Spell") ||
                                                                                c.Type.Equals("Item") ||
                                                                                c.Type.Equals("Ally"))));


            // Call Card Action Page
            var page = new CardActionPage(GameData, settings, market, GameData.PlayerDeck, GameData.PlayerGraveyard, "Village");
            await Navigation.showpageasdialog(page);
            GameData = page.GameData;
            GameData.PlayerDeck = page.Draw;
            GameData.PlayerGraveyard = page.Discard;
        }

        public async void OnTreasure(object sender, EventArgs e)
        {
            List<Card> treasures = new List<Card>();
            foreach (Quest q in GameData.AllCards)
            {
                treasures.AddRange(q.Treasures);
            }

            var page = new CardListPage(GameData, settings, treasures);
            await Navigation.showpageasdialog(page);
            if (page.result == 1)
            {
                // OK was clicked, save name, and call card selection screen for verification
                //System.Diagnostics.Debug.WriteLine(page.lvSelectedItem.ToString());
                Card card = null;
                foreach (Quest q in GameData.AllCards)
                {
                    if (q.GetCard(page.lvSelectedItem.ToString()) != null)
                    {
                        card = q.GetCard(page.lvSelectedItem.ToString());
                        break;
                    }
                }
                if (card != null)
                {
                    List<Card> chosencard = new List<Card>();
                    chosencard.Add(card);

                    var page2 = new CardSetup(new List<string>(), GameData.AllCards, chosencard, "Verify", settings);
                    await Navigation.showpageasdialog(page2);
                    if (page2.verification)
                    {
                        GameData.PlayerGraveyard.Add(card);
                    }
                }
            }
        }

        public async void OnAddCard(object sender, EventArgs e)
        {
            List<Card> allcards = new List<Card>();
            foreach (Quest q in GameData.AllCards)
            {
                allcards.AddRange(q.Heroes);
                allcards.AddRange(q.Weapons);
                allcards.AddRange(q.Spells);
                allcards.AddRange(q.Items);
                allcards.AddRange(q.Allies);
                allcards.AddRange(q.Monsters);
                allcards.AddRange(q.Treasures);
                allcards.AddRange(q.Legendaries);
            }

            var page = new CardListPage(GameData, settings, allcards);
            await Navigation.showpageasdialog(page);
            if (page.result == 1)
            {
                // OK was clicked, save name, and call card selection screen for verification
                //System.Diagnostics.Debug.WriteLine(page.lvSelectedItem.ToString());
                Card card = null;
                foreach (Quest q in GameData.AllCards)
                {
                    if (q.GetCard(page.lvSelectedItem.ToString()) != null)
                    {
                        card = q.GetCard(page.lvSelectedItem.ToString());
                        break;
                    }
                }
                if (card != null)
                {
                    List<Card> chosencard = new List<Card>();
                    chosencard.Add(card);

                    var page2 = new CardSetup(new List<string>(), GameData.AllCards, chosencard, "Verify", settings);
                    await Navigation.showpageasdialog(page2);
                    if (page2.verification)
                    {
                        GameData.PlayerGraveyard.Add(card);
                    }
                }
            }
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