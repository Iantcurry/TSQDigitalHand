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
    //public partial class CardSetup : AwaitContentPage<Card>
    public partial class CardSetup : ContentPage
    {
        public Card _currCard;
        public Card CurrCard
        {
            get { return _currCard; }
            set { 
                _currCard = value;

                TextString = new TextModeString(AllCards, value, ImageFolderPath);
                
                OnPropertyChanged(); }
        }

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
        public List<Card> Cards;
        public List<Quest> AllCards;

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

        public List<Card> _cardList;
        public List<Card> CardList
        {
            get { return _cardList; }
            set { _cardList = value; OnPropertyChanged(); }
        }
        public TextModeString _textstring;
        public TextModeString TextString
        {
            get { return _textstring; }
            set { 
                _textstring = value;

                CardName = value.CardName;
                CardStrSkill = value.CardStrSkill;
                CardGoldLight = value.CardGoldLight;
                CardLevelExp = value.CardLevelExp;
                CardCost = value.CardCost;
                CardTraits = value.CardTraits;
                CardAbility = value.CardAbility;
                CardImageSource = ImageSource.FromFile(value.ImagePath);

                OnPropertyChanged(); }
        }
        string _imageFolderPath;
        string ImageFolderPath
        {
            get { return _imageFolderPath; }
            set { _imageFolderPath = value; OnPropertyChanged(); }
        }
        public double _textSize;
        public double TextSize
        {
            get { return _textSize; }
            set { _textSize = value; OnPropertyChanged(); }
        }
        public int CardLevel;
        public List<string> SetNames;
        public SettingsClass Settings;

        public Card pageresult;
        public bool verification;

        public CardSetup()
        {

        }

        public CardSetup(List<string> setnames, List<Quest> _allcards, List<Card> _cards, string ChoiceName, SettingsClass settings)
        {
            Settings = settings;
            ImageFolderPath = settings.ImageFolderPath;
            TextSize = settings.FontSize;
            ImageMode = true;
            SetNames = new List<string>(setnames);

            Cards = new List<Card>(_cards);
            AllCards = new List<Quest>(_allcards);
            CardList = new List<Card>(GetCardList());
            InitializeComponent();

            //System.Diagnostics.Debug.WriteLine(CardList.Count);


            lb_CardType.Text = ChoiceName;
            
            // Manual Setup, grab first card in list
            CurrCard = CardList[0];
            CardLevel = CurrCard.CardLevel;

            //_navigationResult = CurrCard;
            pageresult = CurrCard;
            verification = false;

            BindingContext = this;
        }

        public List<Card> GetCardList()
        {
            List<Card> cards = new List<Card>();

            foreach (Card card in Cards)
            {
                if (!SetNames.Contains(card.Name)) cards.Add(card);
            }
            return cards;
        }

        async void OKClicked(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(CurrCard.Name);
            if (!SetNames.Contains(CurrCard.Name))
            {
                //_navigationResult = CurrCard;
                verification = true;
                pageresult = CurrCard;
                await Navigation.PopModalAsync();
            }
            else
            {
                // Show some message that that card is already chosen
                // and ignore close command
            }
        }

        async void CancelClicked(object sender, EventArgs e)
        {
            //_navigationResult = null;
            verification = false;
            pageresult = null;
            await Navigation.PopModalAsync();
        }

        public void ModeClicked(object sender, EventArgs e)
        {
            ImageMode = !ImageMode;
        }

        public async void InfoClicked(object sender, EventArgs e)
        {
            int cardlevel = -1;
            List<string> viewcard = new List<string>();
            viewcard.Add(CurrCard.Name);
            if (CurrCard != null)
            {
                if (CurrCard.Type.Equals("Hero")) cardlevel = 1;
                if (CurrCard.Type.Equals("Guardians")) cardlevel = 4;
                if (CurrCard.Name.Equals("Adventurer")) cardlevel = 0;
            }
            
            
            var waithandle = new EventWaitHandle(false, EventResetMode.AutoReset);
            var modalPage = new CardViewer(Settings, AllCards, viewcard, CurrCard.Name, cardlevel, Navigation);
            await Navigation.showpageasdialog(modalPage);

        }

        public void PrevCard(object sender, EventArgs e)
        {
            int index = CardList.IndexOf(CurrCard);
            if (index != -1)
            {
                if (index == 0)
                    index = CardList.Count - 1;
                else
                    index--;
            }
            Card card = CardList[index];
            CurrCard = card;
        }

        public void NextCard(object sender, EventArgs e)
        {
            int index = CardList.IndexOf(CurrCard);
            if (index != -1)
            {
                if (index == CardList.Count - 1)
                    index = 0;
                else
                    index++;
            }
            Card card = CardList[index];
            CurrCard = card;
        }

    }
}