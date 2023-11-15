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
    public partial class SetupMainPage : ContentPage
    {
        public SettingsClass AllSettings { get; set; }
        public List<Quest> _cards { get; set; }
        public double _textSize;
        public double TextSize
        {
            get { return _textSize; }
            set { _textSize = value; OnPropertyChanged(); }
        }
        public string _imagefolderpath;
        public string ImageFolderPath
        {
            get { return _imagefolderpath; }
            set { _imagefolderpath = value; OnPropertyChanged(); }
        }
        public List<Card> TownCards = new List<Card>();
        public List<Card> DungeonCards = new List<Card>();
        public List<Card> PlayerCards = new List<Card>();
        public GameCardData CardData { get; set; }

        public SetupMainPage()
        {

        }

        public SetupMainPage(SettingsClass settings, List<Quest> cards)
        {
            // Load into global variables
            _cards = new List<Quest>(cards);
            AllSettings = settings;

            // Set settings as necessary
            TextSize = AllSettings.FontSize;
            ImageFolderPath = AllSettings.ImageFolderPath;

            InitializeComponent();

            BindingContext = this;
        }

        public List<Card> GetCardList(string type, string trait)
        {
            List<Card> cards = new List<Card>();
            foreach (Quest quest in _cards)
            {
                cards.AddRange(quest.GetCardList(type, trait));
            }

            cards = new List<Card>(cards.GroupBy(x => x.Name).Select(g => g.First()).ToList());

            return cards;
        }

        async Task TownSetup()
        {
            List<string> setnames = new List<string>();
            List<Card> towncards = new List<Card>();
            List<Card> CardList = new List<Card>();
            TownCards.Clear();
            Card Cleric = null;
            Card Fighter = null;
            Card Rogue = null;
            Card Wizard = null;
            Card Weapon1 = null;
            Card Weapon2 = null;
            Card Spell1 = null;
            Card Spell2 = null;
            Card Item1 = null;
            Card Item2 = null;
            Card Misc1 = null;
            Card Misc2 = null;

            int index = 0;
            CardSetup page;

            while (index < 12)
            {
                switch (index)
                {
                    case 0:
                        if (Cleric != null)
                        {
                            setnames.Remove(Cleric.Name);
                            towncards.Remove(Cleric);
                        }

                        CardList = new List<Card>(GetCardList("Hero", "Cleric"));
                        page = new CardSetup(setnames, _cards, CardList, "Choose Cleric", AllSettings);
                        await Navigation.showpageasdialog(page);
                        Cleric = page.pageresult;

                        if (Cleric != null)
                        {
                            System.Diagnostics.Debug.WriteLine(Cleric.Name);
                            setnames.Add(Cleric.Name);
                            towncards.Add(Cleric);
                            index++;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("NULL");
                            index--;
                        }
                        break;
                    case 1:
                        if (Fighter != null)
                        {
                            setnames.Remove(Fighter.Name);
                            towncards.Remove(Fighter);
                        }

                        CardList = new List<Card>(GetCardList("Hero", "Fighter"));
                        page = new CardSetup(setnames, _cards, CardList, "Choose Fighter", AllSettings);
                        await Navigation.showpageasdialog(page);
                        Fighter = page.pageresult;

                        if (Fighter != null)
                        {
                            System.Diagnostics.Debug.WriteLine(Fighter.Name);
                            setnames.Add(Fighter.Name);
                            towncards.Add(Fighter);
                            index++;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("NULL");
                            index--;
                        }
                        break;
                    case 2:
                        if (Rogue != null)
                        {
                            setnames.Remove(Rogue.Name);
                            towncards.Remove(Rogue);
                        }

                        CardList = new List<Card>(GetCardList("Hero", "Rogue"));
                        page = new CardSetup(setnames, _cards, CardList, "Choose Rogue", AllSettings);
                        await Navigation.showpageasdialog(page);
                        Rogue = page.pageresult;

                        if (Rogue != null)
                        {
                            System.Diagnostics.Debug.WriteLine(Rogue.Name);
                            setnames.Add(Rogue.Name);
                            towncards.Add(Rogue);
                            index++;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("NULL");
                            index--;
                        }
                        break;
                    case 3:
                        if (Wizard != null)
                        {
                            setnames.Remove(Wizard.Name);
                            towncards.Remove(Wizard);
                        }

                        CardList = new List<Card>(GetCardList("Hero", "Wizard"));
                        page = new CardSetup(setnames, _cards, CardList, "Choose Wizard", AllSettings);
                        await Navigation.showpageasdialog(page);
                        Wizard = page.pageresult;

                        if (Wizard != null)
                        {
                            System.Diagnostics.Debug.WriteLine(Wizard.Name);
                            setnames.Add(Wizard.Name);
                            towncards.Add(Wizard);
                            index++;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("NULL");
                            index--;
                        }
                        break;
                    case 4: // Weapon 1
                        if (Weapon1 != null)
                        {
                            setnames.Remove(Weapon1.Name);
                            towncards.Remove(Weapon1);
                        }

                        CardList = new List<Card>(GetCardList("Weapon", "Weapon"));
                        page = new CardSetup(setnames, _cards, CardList, "Choose 1st Weapon", AllSettings);
                        await Navigation.showpageasdialog(page);
                        Weapon1 = page.pageresult;

                        if (Weapon1 != null)
                        {
                            System.Diagnostics.Debug.WriteLine(Weapon1.Name);
                            setnames.Add(Weapon1.Name);
                            towncards.Add(Weapon1);
                            index++;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("NULL");
                            index--;
                        }
                        break;
                    case 5: // Weapon 2
                        if (Weapon2 != null)
                        {
                            setnames.Remove(Weapon2.Name);
                            towncards.Remove(Weapon2);
                        }

                        CardList = new List<Card>(GetCardList("Weapon", "Weapon"));
                        page = new CardSetup(setnames, _cards, CardList, "Choose 2nd Weapon", AllSettings);
                        await Navigation.showpageasdialog(page);
                        Weapon2 = page.pageresult;

                        if (Weapon2 != null)
                        {
                            System.Diagnostics.Debug.WriteLine(Weapon2.Name);
                            setnames.Add(Weapon2.Name);
                            towncards.Add(Weapon2);
                            index++;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("NULL");
                            index--;
                        }
                        break;
                    case 6: // Spell 1
                        if (Spell1 != null)
                        {
                            setnames.Remove(Spell1.Name);
                            towncards.Remove(Spell1);
                        }

                        CardList = new List<Card>(GetCardList("Spell", "Spell"));
                        page = new CardSetup(setnames, _cards, CardList, "Choose 1st Spell", AllSettings);
                        await Navigation.showpageasdialog(page);
                        Spell1 = page.pageresult;

                        if (Spell1 != null)
                        {
                            System.Diagnostics.Debug.WriteLine(Spell1.Name);
                            setnames.Add(Spell1.Name);
                            towncards.Add(Spell1);
                            index++;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("NULL");
                            index--;
                        }
                        break;
                    case 7: // Spell 2
                        if (Spell2 != null)
                        {
                            setnames.Remove(Spell2.Name);
                            towncards.Remove(Spell2);
                        }

                        CardList = new List<Card>(GetCardList("Spell", "Spell"));
                        page = new CardSetup(setnames, _cards, CardList, "Choose 2nd Spell", AllSettings);
                        await Navigation.showpageasdialog(page);
                        Spell2 = page.pageresult;

                        if (Spell2 != null)
                        {
                            System.Diagnostics.Debug.WriteLine(Spell2.Name);
                            setnames.Add(Spell2.Name);
                            towncards.Add(Spell2);
                            index++;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("NULL");
                            index--;
                        }
                        break;
                    case 8: // Item 1
                        if (Item1 != null)
                        {
                            setnames.Remove(Item1.Name);
                            towncards.Remove(Item1);
                        }

                        CardList = new List<Card>(GetCardList("Item", "Item"));
                        page = new CardSetup(setnames, _cards, CardList, "Choose 1st Item", AllSettings);
                        await Navigation.showpageasdialog(page);
                        Item1 = page.pageresult;

                        if (Item1 != null)
                        {
                            System.Diagnostics.Debug.WriteLine(Item1.Name);
                            setnames.Add(Item1.Name);
                            towncards.Add(Item1);
                            index++;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("NULL");
                            index--;
                        }
                        break;
                    case 9: // Item 2
                        if (Item2 != null)
                        {
                            setnames.Remove(Item2.Name);
                            towncards.Remove(Item2);
                        }

                        CardList = new List<Card>(GetCardList("Item", "Item"));
                        page = new CardSetup(setnames, _cards, CardList, "Choose 2nd Item", AllSettings);
                        await Navigation.showpageasdialog(page);
                        Item2 = page.pageresult;

                        if (Item2 != null)
                        {
                            System.Diagnostics.Debug.WriteLine(Item2.Name);
                            setnames.Add(Item2.Name);
                            towncards.Add(Item2);
                            index++;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("NULL");
                            index--;
                        }
                        break;
                    case 10: // Misc 1
                        if (Misc1 != null)
                        {
                            setnames.Remove(Misc1.Name);
                            towncards.Remove(Misc1);
                        }

                        CardList = new List<Card>(GetCardList("Weapon", "Weapon"));
                        CardList.AddRange(GetCardList("Spell", "Spell"));
                        CardList.AddRange(GetCardList("Item", "Item"));
                        CardList.AddRange(GetCardList("Ally", "Ally"));
                        page = new CardSetup(setnames, _cards, CardList, "Choose 1st Misc", AllSettings);
                        await Navigation.showpageasdialog(page);
                        Misc1 = page.pageresult;

                        if (Misc1 != null)
                        {
                            System.Diagnostics.Debug.WriteLine(Misc1.Name);
                            setnames.Add(Misc1.Name);
                            towncards.Add(Misc1);
                            index++;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("NULL");
                            index--;
                        }
                        break;
                    case 11: // Misc 2
                        if (Misc2 != null)
                        {
                            setnames.Remove(Misc2.Name);
                            towncards.Remove(Misc2);
                        }

                        CardList = new List<Card>(GetCardList("Weapon", "Weapon"));
                        CardList.AddRange(GetCardList("Spell", "Spell"));
                        CardList.AddRange(GetCardList("Item", "Item"));
                        CardList.AddRange(GetCardList("Ally", "Ally"));
                        page = new CardSetup(setnames, _cards, CardList, "Choose 2nd Misc", AllSettings);
                        await Navigation.showpageasdialog(page);
                        Misc2 = page.pageresult;

                        if (Misc2 != null)
                        {
                            System.Diagnostics.Debug.WriteLine(Misc2.Name);
                            setnames.Add(Misc2.Name);
                            towncards.Add(Misc2);
                            index++;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("NULL");
                            index--;
                        }
                        break;
                }
                if (index == -1) break; // To do: Make sure this exits back to menu
            }
            if (index == -1)
            {
                //Go To main Menu
                System.Diagnostics.Debug.WriteLine("Main Menu");
            }
            else
            {
                // Verify Town Card Selection
                TownCards = new List<Card>();
                TownCards.Add(Cleric);
                TownCards.Add(Fighter);
                TownCards.Add(Rogue);
                TownCards.Add(Wizard);
                TownCards.Add(Weapon1);
                TownCards.Add(Weapon2);
                TownCards.Add(Spell1);
                TownCards.Add(Spell2);
                TownCards.Add(Item1);
                TownCards.Add(Item2);
                TownCards.Add(Misc1);
                TownCards.Add(Misc2);

                page = new CardSetup(new List<string>(), _cards, TownCards, "Verify Town Cards", AllSettings);
                await Navigation.showpageasdialog(page);
                bool verification = page.verification;

                // Restart Town Setup
                if (verification == false)
                {
                    await TownSetup();
                    return;
                }

                // Start Dungeon Setup
                System.Diagnostics.Debug.WriteLine("Dungeon Setup");
            }
        }

        public async Task DungeonSetup()
        {
            CardSetup page;
            List<string> setnames = new List<string>();
            List<Card> CardList = new List<Card>();
            List<Card> dungeoncards = new List<Card>();
            DungeonCards = new List<Card>();

            Card MonsterGroup1 = null;
            Card MonsterGroup2 = null;
            Card MonsterGroup3 = null;
            Card Guardian = null;

            int index = 0;
            while (index < 5)
            {
                switch (index)
                {
                    case 0:
                        if (MonsterGroup1 != null)
                        {
                            setnames.Remove(MonsterGroup1.Name);
                            dungeoncards.Remove(MonsterGroup1);
                        }

                        CardList = new List<Card>(GetCardList("MonsterGroup", "1"));
                        page = new CardSetup(setnames, _cards, CardList, "Choose 1st Monster Group", AllSettings);
                        await Navigation.showpageasdialog(page);
                        MonsterGroup1 = page.pageresult;

                        if (MonsterGroup1 != null)
                        {
                            System.Diagnostics.Debug.WriteLine(MonsterGroup1.Name);
                            setnames.Add(MonsterGroup1.Name);
                            dungeoncards.Add(MonsterGroup1);
                            index++;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("NULL");
                            index--;
                        }
                        break;
                    case 1:
                        if (MonsterGroup2 != null)
                        {
                            setnames.Remove(MonsterGroup2.Name);
                            dungeoncards.Remove(MonsterGroup2);
                        }

                        CardList = new List<Card>(GetCardList("MonsterGroup", "2"));
                        page = new CardSetup(setnames, _cards, CardList, "Choose 2nd Monster Group", AllSettings);
                        await Navigation.showpageasdialog(page);
                        MonsterGroup2 = page.pageresult;

                        if (MonsterGroup2 != null)
                        {
                            System.Diagnostics.Debug.WriteLine(MonsterGroup2.Name);
                            setnames.Add(MonsterGroup2.Name);
                            dungeoncards.Add(MonsterGroup2);
                            index++;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("NULL");
                            index--;
                        }
                        break;
                    case 2:
                        if (MonsterGroup3 != null)
                        {
                            setnames.Remove(MonsterGroup3.Name);
                            dungeoncards.Remove(MonsterGroup3);
                        }

                        CardList = new List<Card>(GetCardList("MonsterGroup", "3"));
                        page = new CardSetup(setnames, _cards, CardList, "Choose 3rd Monster Group", AllSettings);
                        await Navigation.showpageasdialog(page);
                        MonsterGroup3 = page.pageresult;

                        if (MonsterGroup3 != null)
                        {
                            System.Diagnostics.Debug.WriteLine(MonsterGroup3.Name);
                            setnames.Add(MonsterGroup3.Name);
                            dungeoncards.Add(MonsterGroup3);
                            index++;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("NULL");
                            index--;
                        }
                        break;
                    case 3:
                        if (Guardian != null)
                        {
                            setnames.Remove(Guardian.Name);
                            dungeoncards.Remove(Guardian);
                        }

                        CardList = new List<Card>(GetCardList("Guardian", "Guardian"));
                        page = new CardSetup(setnames, _cards, CardList, "Choose Guardian", AllSettings);
                        await Navigation.showpageasdialog(page);
                        Guardian = page.pageresult;

                        if (Guardian != null)
                        {
                            System.Diagnostics.Debug.WriteLine(Guardian.Name);
                            setnames.Add(Guardian.Name);
                            dungeoncards.Add(Guardian);
                            index++;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("NULL");
                            index--;
                        }
                        break;
                    case 4:
                        CardList = new List<Card>();
                        Card temp = _cards[0].GetCard(Guardian.Name);

                        Card temp2 = new Guardian(temp.Name, 4);
                        CardList.Add(temp2);
                        temp2 = new Guardian(temp.Name, 5);
                        CardList.Add(temp2);
                        temp2 = new Guardian(temp.Name, 6);
                        CardList.Add(temp2);
                        page = new CardSetup(new List<string>(), _cards, CardList, "Choose Guardian Level", AllSettings);
                        await Navigation.showpageasdialog(page);
                        if (page.pageresult != null) Guardian = page.pageresult;
                        if (page.pageresult != null)
                        {
                            System.Diagnostics.Debug.WriteLine(Guardian.CardLevel);
                            setnames.Add(Guardian.Name);
                            dungeoncards.Add(Guardian);
                            index++;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("NULL");
                            index--;
                        }


                        break;
                }
                if (index == -1) break;
            }
            if (index == -1)
            {
                //Go Back to Town Setup
                System.Diagnostics.Debug.WriteLine("Town Setup");
            }
            else
            {
                // Verify Dungeon Cards
                DungeonCards = new List<Card>();
                DungeonCards.Add(MonsterGroup1);
                DungeonCards.Add(MonsterGroup2);
                DungeonCards.Add(MonsterGroup3);
                DungeonCards.Add(Guardian);

                page = new CardSetup(new List<string>(), _cards, DungeonCards, "Verify Dungeon Cards", AllSettings);
                await Navigation.showpageasdialog(page);
                bool verification = page.verification;

                // Restart Dungeon Setup
                if (verification == false)
                {
                    await DungeonSetup();
                    return;
                }
                // Move on to Player Setup
                System.Diagnostics.Debug.WriteLine("Player Setup");
                
            }
        }

        public async Task PlayerSetup()
        {
            CardSetup page;
            List<string> setnames = new List<string>();
            List<Card> CardList = new List<Card>();
            List<Card> playercards = new List<Card>();
            PlayerCards = new List<Card>();

            Card PersonalQuest = null;
            Card Guild = null;

            int index = 0;
            while (index < 2)
            {
                switch (index)
                {
                    case 0:
                        if (PersonalQuest != null)
                        {
                            setnames.Remove(PersonalQuest.Name);
                            playercards.Remove(PersonalQuest);
                        }

                        CardList = new List<Card>();
                        foreach (Quest q in _cards)
                        {
                            CardList.AddRange(q.PersonalQuests);
                        }
                        page = new CardSetup(setnames, _cards, CardList, "Choose Personal Quest", AllSettings);
                        await Navigation.showpageasdialog(page);
                        PersonalQuest = page.pageresult;

                        if (PersonalQuest != null)
                        {
                            System.Diagnostics.Debug.WriteLine(PersonalQuest.Name);
                            setnames.Add(PersonalQuest.Name);
                            playercards.Add(PersonalQuest);
                            index++;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("NULL");
                            index--;
                        }
                        break;
                    case 1:
                        if (Guild != null)
                        {
                            setnames.Remove(Guild.Name);
                            playercards.Remove(Guild);
                        }

                        CardList = new List<Card>();
                        foreach (Quest q in _cards)
                        {
                            CardList.AddRange(q.Guilds);
                        }
                        page = new CardSetup(setnames, _cards, CardList, "Choose Guild", AllSettings);
                        await Navigation.showpageasdialog(page);
                        Guild = page.pageresult;

                        if (Guild != null)
                        {
                            System.Diagnostics.Debug.WriteLine(Guild.Name);
                            setnames.Add(Guild.Name);
                            playercards.Add(Guild);
                            index++;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("NULL");
                            index--;
                        }
                        break;
                }
                if (index == -1) break;
            }
            if (index == -1)
            {
                //Go Back to Dungeon Setup
                System.Diagnostics.Debug.WriteLine("Dungeon Setup");
            }
            else
            {
                // Verify Cards Chosen
                PlayerCards = new List<Card>();
                PlayerCards.Add(PersonalQuest);
                PlayerCards.Add(Guild);

                page = new CardSetup(new List<string>(), _cards, PlayerCards, "Verify Player Cards", AllSettings);
                await Navigation.showpageasdialog(page);
                bool verification = page.verification;

                // Restart Player Setup
                if (verification == false)
                {
                    await PlayerSetup();
                    return;
                }
                // Start Town screen
                System.Diagnostics.Debug.WriteLine("Town Screen");

            }

        }

        public async void OnManual(object sender, EventArgs e)
        {
            
            int index = 0;
            while (index < 3)
            {
                if (index == 0)
                {
                    await TownSetup();
                    if (TownCards.Count == 0) index--;
                    else index++;
                }
                if (index == 1)
                {
                    await DungeonSetup();
                    if (DungeonCards.Count == 0) index--;
                    else index++;
                }
                if (index == 2)
                {
                    await PlayerSetup();
                    if (PlayerCards.Count == 0) index--;
                    else index++;
                }

                if (index == -1) break;
            }
            
            if (index != -1)
            {
                SetupComplete();
            }

            // Fall though if unsuccessful
        }

        public async void OnRandom(object sender, EventArgs e)
        {
            List<Card> CardList = new List<Card>();
            TownCards = new List<Card>();
            DungeonCards = new List<Card>();
            Random rand = new Random();

            // Choose Random TownCards
            // Cleric
            CardList = new List<Card>(GetCardList("Hero", "Cleric"));
            int c = rand.Next(0, CardList.Count);
            TownCards.Add(CardList[c]);
            System.Diagnostics.Debug.WriteLine("Cleric: " + TownCards[0].Name);
            // Fighter
            CardList = new List<Card>(GetCardList("Hero", "Fighter"));
            do
            {
                c = rand.Next(0, CardList.Count);
            } while (TownCards.Any(y => y.Name == CardList[c].Name));
            TownCards.Add(CardList[c]);
            System.Diagnostics.Debug.WriteLine("Fighter: " + TownCards[1].Name);
            // Rogue
            CardList = new List<Card>(GetCardList("Hero", "Rogue"));
            do
            {
                c = rand.Next(0, CardList.Count);
            } while (TownCards.Any(y => y.Name == CardList[c].Name));
            TownCards.Add(CardList[c]);
            System.Diagnostics.Debug.WriteLine("Rogue: " + TownCards[2].Name);
            // Wizard
            CardList = new List<Card>(GetCardList("Hero", "Wizard"));
            do
            {
                c = rand.Next(0, CardList.Count);
            } while (TownCards.Any(y => y.Name == CardList[c].Name));
            TownCards.Add(CardList[c]);
            System.Diagnostics.Debug.WriteLine("Wizard: " + TownCards[3].Name);
            // Weapon1
            CardList = new List<Card>(GetCardList("Weapon", "Weapon"));
            CardList.Remove(_cards[0].GetCard("Dagger"));
            do
            {
                c = rand.Next(0, CardList.Count);
            } while (TownCards.Any(y => y.Name == CardList[c].Name));
            TownCards.Add(CardList[c]);
            System.Diagnostics.Debug.WriteLine("Weapon1: " + TownCards[4].Name);
            // Weapon2
            do
            {
                c = rand.Next(0, CardList.Count);
            } while (TownCards.Any(y => y.Name == CardList[c].Name));
            TownCards.Add(CardList[c]);
            System.Diagnostics.Debug.WriteLine("Weapon2: " + TownCards[5].Name);
            // Spell1
            CardList = new List<Card>(GetCardList("Spell", "Spell"));
            do
            {
                c = rand.Next(0, CardList.Count);
            } while (TownCards.Any(y => y.Name == CardList[c].Name));
            TownCards.Add(CardList[c]);
            System.Diagnostics.Debug.WriteLine("Spell1: " + TownCards[6].Name);
            // Spell2
            do
            {
                c = rand.Next(0, CardList.Count);
            } while (TownCards.Any(y => y.Name == CardList[c].Name));
            TownCards.Add(CardList[c]);
            System.Diagnostics.Debug.WriteLine("Spell2: " + TownCards[7].Name);
            // Item1
            CardList = new List<Card>(GetCardList("Item", "Item"));
            CardList.Remove(_cards[0].GetCard("Lantern"));
            CardList.Remove(_cards[0].GetCard("Thunderstone Shard"));

            do
            {
                c = rand.Next(0, CardList.Count);
            } while (TownCards.Any(y => y.Name == CardList[c].Name));
            TownCards.Add(CardList[c]);
            System.Diagnostics.Debug.WriteLine("Item1: " + TownCards[8].Name);
            // Item2
            do
            {
                c = rand.Next(0, CardList.Count);
            } while (TownCards.Any(y => y.Name == CardList[c].Name));
            TownCards.Add(CardList[c]);
            System.Diagnostics.Debug.WriteLine("Item2: " + TownCards[9].Name);
            // Misc1
            CardList = new List<Card>(GetCardList("Weapon", "Weapon"));
            CardList.AddRange(GetCardList("Spell", "Spell"));
            CardList.AddRange(GetCardList("Item", "Item"));
            CardList.AddRange(GetCardList("Ally", "Ally"));
            CardList.Remove(_cards[0].GetCard("Dagger"));
            CardList.Remove(_cards[0].GetCard("Lantern"));
            CardList.Remove(_cards[0].GetCard("Thunderstone Shard"));
            do
            {
                c = rand.Next(0, CardList.Count);
            } while (TownCards.Any(y => y.Name == CardList[c].Name));
            TownCards.Add(CardList[c]);
            System.Diagnostics.Debug.WriteLine("Misc1: " + TownCards[10].Name);
            // Misc2
            do
            {
                c = rand.Next(0, CardList.Count);
            } while (TownCards.Any(y => y.Name == CardList[c].Name));
            TownCards.Add(CardList[c]);
            System.Diagnostics.Debug.WriteLine("Misc2: " + TownCards[11].Name);

            // Choose Random DungeonCards
            // Monster Group Level 1
            CardList = new List<Card>(GetCardList("MonsterGroup", "1"));
            do
            {
                c = rand.Next(0, CardList.Count);
            } while (DungeonCards.Any(y => y.Name == CardList[c].Name));
            DungeonCards.Add(CardList[c]);
            System.Diagnostics.Debug.WriteLine("Level 1 Monster Group: " + DungeonCards[0].Name);
            // Monster Group Level 2
            // Monster Group Level 1
            CardList = new List<Card>(GetCardList("MonsterGroup", "2"));
            do
            {
                c = rand.Next(0, CardList.Count);
            } while (DungeonCards.Any(y => y.Name == CardList[c].Name));
            DungeonCards.Add(CardList[c]);
            System.Diagnostics.Debug.WriteLine("Level 2 Monster Group: " + DungeonCards[1].Name);
            // Monster Group Level 3
            // Monster Group Level 1
            CardList = new List<Card>(GetCardList("MonsterGroup", "3"));
            do
            {
                c = rand.Next(0, CardList.Count);
            } while (DungeonCards.Any(y => y.Name == CardList[c].Name));
            DungeonCards.Add(CardList[c]);
            System.Diagnostics.Debug.WriteLine("Level 3 Monster Group: " + DungeonCards[2].Name);
            // Guardian
            // Monster Group Level 1
            CardList = new List<Card>(GetCardList("Guardian", "Guardian"));
            do
            {
                c = rand.Next(0, CardList.Count);
            } while (DungeonCards.Any(y => y.Name == CardList[c].Name));
            // Set Guardian Level
            DungeonCards.Add(CardList[c]);
            DungeonCards[3].CardLevel = rand.Next(4, 7);
            System.Diagnostics.Debug.WriteLine("Guardian: " + DungeonCards[3].Name + 
                "; Level: " + DungeonCards[3].CardLevel);
            // Verify Random Cards
            
            List<Card> chosencards = new List<Card>();
            chosencards.AddRange(TownCards);
            chosencards.AddRange(DungeonCards);

            CardSetup page = new CardSetup(new List<string>(), _cards, chosencards, "Verify Random Cards", AllSettings);
            await Navigation.showpageasdialog(page);
            bool verification = page.verification;

            // Go back to main Menu
            if (verification == false)
            {
                return;
            }

            // Choose Player Cards <------ NOT RANDOM
            await PlayerSetup();
            if (PlayerCards.Count != 0)
            {
                // Go to Game Screen
                SetupComplete();
            }

            // Return to main menu
            // Just let this fall through
            
        }

        public async void SetupComplete()
        {
            System.Diagnostics.Debug.WriteLine("Setup Complete");
            CardData = new GameCardData(_cards, TownCards, DungeonCards, PlayerCards);
            await Task.Delay(750); // Find a better way around this bug
            await Navigation.PopModalAsync();
        }

        public async void OnCancel(object sender, EventArgs e)
        {
            CardData = null;
            await Navigation.PopModalAsync();
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