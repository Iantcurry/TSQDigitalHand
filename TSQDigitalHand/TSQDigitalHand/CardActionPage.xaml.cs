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
    public partial class CardActionPage : ContentPage
    {
        public GameCardData GameData { get; set; }
        public SettingsClass settings { get; set; }
        public double _textsize;
        public double TextSize
        {
            get { return _textsize; }
            set { _textsize = value; OnPropertyChanged(); }
        }
        public string _imagefolderpath;
        public string ImageFolderPath
        {
            get { return _imagefolderpath;}
            set { _imagefolderpath = value; OnPropertyChanged(); }
        }
        public List<Card> Cards { get; set; }
        public List<Card> Draw { get; set; }
        public List<Card> Discard { get; set; }
        public bool _imageMode;
        public bool ImageMode
        {
            get { return _imageMode; }
            set { _imageMode = value; OnPropertyChanged(); }
        }
        public ImageSource _cardImageSource;
        public ImageSource CardImageSource
        {
            get { return _cardImageSource; }
            set { _cardImageSource = value; OnPropertyChanged(); }
        }
        public string _cardName;
        public string CardName
        {
            get { return _cardName; }
            set { _cardName = value; OnPropertyChanged(); }
        }

        public string _cardStrSkill;
        public string CardStrSkill
        {
            get { return _cardStrSkill; }
            set { _cardStrSkill = value; OnPropertyChanged(); }
        }
        public string _cardGoldLight;
        public string CardGoldLight
        {
            get { return _cardGoldLight; }
            set { _cardGoldLight = value; OnPropertyChanged(); }
        }
        public string _cardLevelExp;
        public string CardLevelExp
        {
            get { return _cardLevelExp; }
            set { _cardLevelExp = value; OnPropertyChanged(); }
        }
        public string _cardCost;
        public string CardCost
        {
            get { return _cardCost; }
            set { _cardCost = value; OnPropertyChanged(); }
        }
        public string _cardTraits;
        public string CardTraits
        {
            get { return _cardTraits; }
            set { _cardTraits = value; OnPropertyChanged(); }
        }
        public string _cardAbility;
        public string CardAbility
        {
            get { return _cardAbility; }
            set { _cardAbility = value; OnPropertyChanged(); }
        }
        public Card _currCard;
        public Card CurrCard
        {
            get { return _currCard; }
            set
            {
                _currCard = value;

                TextString = new TextModeString(GameData.AllCards, value, ImageFolderPath);

                OnPropertyChanged();
            }
        }
        public TextModeString _textstring;
        public TextModeString TextString
        {
            get { return _textstring; }
            set { _textstring = value; 
                
                CardName = value.CardName;
                CardStrSkill = value.CardStrSkill;
                CardGoldLight = value.CardGoldLight;
                CardLevelExp = value.CardLevelExp;
                CardCost = value.CardCost;
                CardTraits = value.CardTraits;
                CardAbility = value.CardAbility;
                CardImageSource = ImageSource.FromFile(value.ImagePath);

                OnPropertyChanged();
            }
        }
        public string Origin { get; set; }

        public CardActionPage(GameCardData data, SettingsClass _settings, List<Card> _cards, List<Card> draw, List<Card> discard, string origin)
        {
            // Set global Variables
            GameData = data;
            settings = _settings;
            Cards = new List<Card>(_cards);
            Draw = new List<Card>(draw);
            Discard = new List<Card>(discard);
            Origin = origin;

            // Set settings for binding variables
            TextSize = settings.FontSize;
            ImageFolderPath = settings.ImageFolderPath;

            InitializeComponent();

            if (_cards != null && _cards.Count != 0) CurrCard = _cards[0];
            else
            {
                CardName = "No Cards Available";
                CardStrSkill = "";
                CardGoldLight = "";
                CardLevelExp = "";
                CardCost = "";
                CardTraits = "";
                CardAbility = "";
                CardImageSource = "NoPic.png";
            }
            ImageMode = true;

            BindingContext = this;

            if (Origin.Equals("Graveyard"))
            {
                btn_Discard.IsVisible = false;
            }
            if (origin.Equals("Village"))
            {
                btn_Destroy.IsVisible = false;
            }

        }

        public CardActionPage()
        {

        }

        public async void OnCancel(object sender, EventArgs e)
        {
            // Close Page, and make sure data is saved properly
            await Navigation.PopModalAsync();
        }

        public void NextCard(object sender, EventArgs e)
        {
            if (Cards.Count == 0 || Cards == null) return;
            int index = Cards.IndexOf(CurrCard);
            if (index != -1)
            {
                if (index == Cards.Count - 1)
                    index = 0;
                else
                    index++;
            }
            System.Diagnostics.Debug.WriteLine(index);
            Card card = Cards[index];
            CurrCard = card;
        }

        public void PrevCard(object sender, EventArgs e)
        {
            if (Cards.Count == 0 || Cards == null) return;
            int index = Cards.IndexOf(CurrCard);
            if (index != -1)
            {
                if (index == 0)
                    index = Cards.Count - 1;
                else
                    index--;
            }
            Card card = Cards[index];
            CurrCard = card;
        }

        public async void OnInfo(object sender, EventArgs e)
        {
            if (Cards.Count == 0 || Cards == null) return;
            int cardlevel = -1;
            List<string> viewcard = new List<string>
            {
                CurrCard.Name
            };
            if (CurrCard != null)
            {
                if (CurrCard.Type.Equals("Hero")) cardlevel = 1;
                if (CurrCard.Type.Equals("Guardians")) cardlevel = 4;
                if (CurrCard.Name.Equals("Adventurer")) cardlevel = 0;
            }

            var modalPage = new CardViewer(settings, GameData.AllCards, viewcard, CurrCard.Name, cardlevel, Navigation);
            await Navigation.showpageasdialog(modalPage);
        }

        public void OnImageMode(object sender, EventArgs e)
        {
            ImageMode = !ImageMode;
        }

        public void OnDraw(object sender, EventArgs e)
        {
            if (Draw.Count == 0)
            {
                // in future pop message?
                // shuffle discard?
                // do something
                return;
            }
            else
            {
                if (Origin.Equals("Hand"))
                {
                    Cards.Add(Draw[0]);
                    Draw.RemoveAt(0);

                    CurrCard = Cards[Cards.Count - 1];
                }
                if (Origin.Equals("Deck") || Origin.Equals("Discard") || 
                    Origin.Equals("Graveyard") || Origin.Equals("Village")) 
                {
                    // Draw card into player hand, and remove from card list
                    if (Cards.Count == 0 || Cards == null) return;
                    GameData.PlayerHand.Add(CurrCard);
                    int index = Cards.IndexOf(CurrCard);
                    if (Cards.Count == 1)
                    {
                        // Set everything to basic
                        CardName = "No Cards Available";
                        CardStrSkill = "";
                        CardGoldLight = "";
                        CardLevelExp = "";
                        CardCost = "";
                        CardTraits = "";
                        CardAbility = "";
                        CardImageSource = "NoPic.png";
                    }
                    else
                    {
                        if (index == Cards.Count - 1) CurrCard = Cards[0];
                        else CurrCard = Cards[index + 1];
                    }
                    if (!(Origin.Equals("Village"))) Cards.RemoveAt(index);
                }
            }
        }

        public void OnDiscard(object sender, EventArgs e)
        {
            if (Cards.Count == 0 || Cards == null) return;
            int index = Cards.IndexOf(CurrCard);
            Discard.Add(CurrCard);
            if (Cards.Count == 1) // only card left
            {
                // Set everything to basic
                CardName = "No Cards Available";
                CardStrSkill = "";
                CardGoldLight = "";
                CardLevelExp = "";
                CardCost = "";
                CardTraits = "";
                CardAbility = "";
                CardImageSource = "NoPic.png";
            }
            else
            {
                if (index == Cards.Count - 1) CurrCard = Cards[0];
                else CurrCard = Cards[index + 1];
            }
            if (!(Origin.Equals("Village"))) Cards.RemoveAt(index);
        }

        public void OnPlaceONDeck(object sender, EventArgs e)
        {
            if (Cards.Count == 0 || Cards == null) return;
            int index = Cards.IndexOf(CurrCard);
            Draw.Insert(0, CurrCard);
            if (Cards.Count == 1) // only card left
            {
                // Set everything to basic
                CardName = "No Cards Available";
                CardStrSkill = "";
                CardGoldLight = "";
                CardLevelExp = "";
                CardCost = "";
                CardTraits = "";
                CardAbility = "";
                CardImageSource = "NoPic.png";
            }
            else
            {
                if (index == Cards.Count - 1) CurrCard = Cards[0];
                else CurrCard = Cards[index + 1];
            }
            if (!(Origin.Equals("Village"))) Cards.RemoveAt(index);
        }

        public void OnDestroy(object sender, EventArgs e)
        {
            if (Cards.Count == 0 || Cards == null) return;
            int index = Cards.IndexOf(CurrCard);
            if (Cards.Count == 1) // only card left
            {
                // Set everything to basic
                CardName = "No Cards Available";
                CardStrSkill = "";
                CardGoldLight = "";
                CardLevelExp = "";
                CardCost = "";
                CardTraits = "";
                CardAbility = "";
                CardImageSource = "NoPic.png";
            }
            else
            {
                if (index == Cards.Count - 1) CurrCard = Cards[0];
                else CurrCard = Cards[index + 1];
            }
            Cards.RemoveAt(index);
        }

    }
}