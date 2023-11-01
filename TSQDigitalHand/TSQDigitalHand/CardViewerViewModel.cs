using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using System.Windows.Input;
using System.Threading;
using System.Threading.Tasks;

namespace TSQDigitalHand
{
    public class CardViewerViewModel : BindableObject
    {
        public double _textsize;
        public double TextSize
        {
            get { return _textsize; }
            set { _textsize = value; OnPropertyChanged(); }
        }
        public string _startCard;
        public string StartCard
        {
            get { return _startCard; }
            set { 
                _startCard = value;

                OnPropertyChanged(); 
            }
        }
        public List<Quest> _cards;
        public List<Quest> Cards
        {
            get { return _cards; }
            set { _cards = value; OnPropertyChanged(); }
        }
        public string _imagepath;
        public string ImagePath
        {
            get { return _imagepath; }
            set { _imagepath = value; OnPropertyChanged(); }
        }
        public Card _currCard;
        public Card CurrCard
        {
            get { return _currCard; }
            set { 
                _currCard = value;

                SetCurrentCard(value, value.Type);

                OnPropertyChanged(); 
            }
        }
        public int _cardlevel;
        public int CardLevel
        {
            get { return _cardlevel; }
            set { _cardlevel = value; OnPropertyChanged(); }
        }
        public List<string> _cardList;
        public List<string> CardList
        {
            get { return _cardList; }
            set { _cardList = value; OnPropertyChanged(); }
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
        public bool _imgMode;
        public bool ImageMode
        {
            get { return _imgMode; }
            set { _imgMode = value; OnPropertyChanged(); }
        }

        public bool _speechflag;
        public bool SpeechFlag
        {
            get { return _speechflag; }
            set { _speechflag = value; OnPropertyChanged(); }
        }

        public string _ttsstring;
        public string TTSString
        {
            get { return _ttsstring; }
            set { _ttsstring = value; OnPropertyChanged(); }
        }

        public string _imageFolderPath;
        public string ImageFolderPath
        {
            get { return _imageFolderPath; }
            set { _imageFolderPath = value; OnPropertyChanged(); }
        }

        public ImageSource _cardimagesource;
        public ImageSource CardImageSource
        {
            get { return _cardimagesource; }
            set { _cardimagesource = value; OnPropertyChanged(); }
        }

        public bool _isupvisible;
        public bool IsUpVisible
        {
            get { return _isupvisible;}
            set { _isupvisible = value; OnPropertyChanged(); }
        }
        public bool _isdownvisible;
        public bool IsDownVisible
        {
            get { return _isdownvisible;}
            set { _isdownvisible = value; OnPropertyChanged(); }
        }

        public INavigation Navigation;

        public CardViewerViewModel(SettingsClass settings, List<Quest> cards, List<string> cardList, string selectedCard, int cardlevel, INavigation navigation)
        {
            CardList = new List<string>(cardList);
            Cards = cards;
            TextSize = settings.FontSize;
            ImagePath = "NoPic.png";
            StartCard = selectedCard;
            CardLevel = cardlevel;
            ImageFolderPath = settings.ImageFolderPath;
            CurrCard = Cards[0].GetCard(selectedCard);
            ImageMode = true;
            SpeechFlag = false;
            Navigation = navigation;

        }

        public void SetCurrentCard(Card card, string Type)
        {
            IsUpVisible = false;
            IsDownVisible = false;
            string temp;
            switch (Type)
            {
                case "Hero":
                    Hero hero = Cards[0].GetHero(card);

                    if (hero.Name.Equals("Adventurer")) CardLevel = 0;
                    else
                    {
                        if (CardLevel != 4) IsUpVisible = true;
                        if (CardLevel != 1) IsDownVisible = true;
                    }

                    Levels currLevel = hero.GetLevel(CardLevel);

                    CardName = hero.Name;
                    CardStrSkill = "Str: " + currLevel.Strength + " " + currLevel.Attack_Type[0] + "     " + "WS: " + currLevel.Weapon_Skill;
                    CardGoldLight = "Gold: " + currLevel.Gold + "     " + "Light: " + currLevel.Light;
                    CardLevelExp = "Level: " + currLevel.Level.ToString() + "     " + "Exp: " + currLevel.Exp;
                    CardCost = "Cost: " + currLevel.Cost;
                    temp = "";
                    foreach (string s in currLevel.Traits)
                    {
                        temp += s + "  ";
                    }
                    CardTraits = temp;
                    CardAbility = currLevel.Ability;
                    ImagePath = ImageFolderPath + currLevel.Image;

                    TTSString = CardName + ", Strength = " + currLevel.Strength +
                        currLevel.Attack_Type + ", Weapon Skill = " + currLevel.Weapon_Skill +
                        ", Gold = " + currLevel.Gold + ", Light = " + currLevel.Light +
                        ", Level = " + currLevel.Level.ToString() + ", Experience = " + currLevel.Exp +
                        ", Cost = " + currLevel.Cost + ", Traits are " + CardTraits + ", Ability = " + CardAbility;

                    break;
                case "Spell":
                    Spell spell = Cards[0].GetSpell(card);

                    CardName = spell.Name;
                    CardStrSkill = "Str: " + spell.Strength + " " + spell.Attack_Type[0] + "     " + "WS: " + spell.Weapon_Skill;
                    CardGoldLight = "Gold: " + spell.Gold + "     " + "Light: " + spell.Light;
                    CardLevelExp = "Level: n/a" + "     " + "Exp: " + spell.Exp;
                    CardCost = "Cost: " + spell.Cost;
                    temp = "";
                    foreach (string s in spell.Traits)
                    {
                        temp += s + "  ";
                    }
                    CardTraits = temp;
                    CardAbility = spell.Ability;

                    TTSString = CardName + ", Strength = " + spell.Strength +
                        spell.Attack_Type + ", Weapon Skill = " + spell.Weapon_Skill +
                        ", Gold = " + spell.Gold + ", Light = " + spell.Light +
                        ", Experience = " + spell.Exp +
                        ", Cost = " + spell.Cost + ", Traits are " + CardTraits + ", Ability = " + CardAbility;


                    ImagePath = ImageFolderPath + spell.Image;
                    break;
                case "Weapon":
                    Weapon weapon = Cards[0].GetWeapon(card);

                    CardName = weapon.Name;
                    CardStrSkill = "Str: " + weapon.Strength + " " + weapon.Attack_Type[0] + "     " + "WS: " + weapon.Weapon_Skill;
                    CardGoldLight = "Gold: " + weapon.Gold + "     " + "Light: " + weapon.Light;
                    CardLevelExp = "Level: n/a" + "     " + "Exp: " + weapon.Exp;
                    CardCost = "Cost: " + weapon.Cost;
                    temp = "";
                    foreach (string s in weapon.Traits)
                    {
                        temp += s + "  ";
                    }
                    CardTraits = temp;
                    CardAbility = weapon.Ability;

                    ImagePath = ImageFolderPath + weapon.Image;

                    TTSString = CardName + ", Strength = " + weapon.Strength +
                        weapon.Attack_Type + ", Weapon Skill = " + weapon.Weapon_Skill +
                        ", Gold = " + weapon.Gold + ", Light = " + weapon.Light +
                        ", Experience = " + weapon.Exp +
                        ", Cost = " + weapon.Cost + ", Traits are " + CardTraits + ", Ability = " + CardAbility;

                    break;
                case "Item":
                    Item item = Cards[0].GetItem(card);

                    CardName = item.Name;
                    CardStrSkill = "Str: " + item.Strength + " " + item.Attack_Type[0] + "     " + "WS: " + item.Weapon_Skill;
                    CardGoldLight = "Gold: " + item.Gold + "     " + "Light: " + item.Light;
                    CardLevelExp = "Level: n/a" + "     " + "Exp: " + item.Exp;
                    CardCost = "Cost: " + item.Cost;
                    temp = "";
                    foreach (string s in item.Traits)
                    {
                        temp += s + "  ";
                    }
                    CardTraits = temp;
                    CardAbility = item.Ability;

                    //Imagepath = item.Image;

                    ImagePath = ImageFolderPath + item.Image;

                    TTSString = CardName + ", Strength = " + item.Strength +
                        item.Attack_Type + ", Weapon Skill = " + item.Weapon_Skill +
                        ", Gold = " + item.Gold + ", Light = " + item.Light +
                        ", Experience = " + item.Exp +
                        ", Cost = " + item.Cost + ", Traits are " + CardTraits + ", Ability = " + CardAbility;

                    break;
                case "Monster":
                    Monster monster = Cards[0].GetMonster(card);

                    CardName = monster.Name;
                    CardStrSkill = "HP: " + monster.HP + "     " + "Armor: " + monster.Armour + " " + monster.Armour_Type[0];
                    CardGoldLight = "Wounds: " + monster.Wounds + " " + monster.Wound_Type;
                    CardLevelExp = "Level: " + monster.Level + "     " + "Exp: " + monster.Exp;
                    CardCost = "Reward: " + monster.Reward;
                    temp = "";
                    foreach (string s in monster.Traits)
                    {
                        temp += s + "  ";
                    }
                    CardTraits = temp;
                    CardAbility = monster.Ability;

                    TTSString = CardName + ".... Hit Points = " + monster.HP + ", Armour = " +
                            monster.Armour + monster.Armour_Type +
                            ", Wounds = " + monster.Wounds + monster.Wound_Type + ", Level = " + monster.Level +
                            ", Experience = " + monster.Exp +
                            ", Reward = " + monster.Reward + ", Traits are " + CardTraits + ", Ability = " + CardAbility;

                    ImagePath = ImageFolderPath + monster.Image;
                    break;
                case "Guardian":
                    Guardian guardian = Cards[0].GetGuardian(card);

                    if (CardLevel != 6) IsUpVisible = true;
                    if (CardLevel != 4) IsDownVisible = true;

                    GLevel level = guardian.GetGLevel(CardLevel);

                    CardName = guardian.Name;
                    CardStrSkill = "HP: " + level.HP + "     " + "Armor: " + level.Armour + " " + level.Armour_Type[0];
                    CardGoldLight = "Wounds: " + level.Wounds + " " + level.Wound_Type;
                    CardLevelExp = "Level: " + level.Level + "     " + "Exp: " + level.Exp;
                    CardCost = "Reward: " + level.Reward;
                    temp = "";
                    foreach (string s in level.Traits)
                    {
                        temp += s + "  ";
                    }
                    CardTraits = temp;
                    CardAbility = level.Ability;

                    ImagePath = ImageFolderPath + level.Image;
                    TTSString = CardName + ", Hit Points = " + level.HP + ", Armour = " +
                           level.Armour + level.Armour_Type +
                           ", Wounds = " + level.Wounds + level.Wound_Type + ", Level = " + level.Level +
                           ", Experience = " + level.Exp +
                           ", Reward = " + level.Reward + ", Traits are " + CardTraits + ", Ability = " + CardAbility;


                    break;
                case "MonsterGroup":
                    MonsterGroup group = Cards[0].GetMonsterGroup(card);

                    CardName = group.Name;
                    CardStrSkill = "";
                    CardGoldLight = "";
                    CardLevelExp = "Level: " + group.Level;
                    CardCost = "";
                    temp = "";
                    CardTraits = temp;
                    CardAbility = "";

                    ImagePath = ImageFolderPath + group.Image;
                    TTSString = CardName + "\n" + "Level " + group.Level;


                    break;
                case "PersonalQuest":
                    PersonalQuest pq = Cards[0].GetPersonalQuest(card);

                    CardName = pq.Name;
                    CardStrSkill = pq.Description;
                    CardGoldLight = "Reward\n" +  pq.Reward;
                    CardLevelExp = "";
                    CardCost = "";
                    temp = "";
                    CardTraits = temp;
                    CardAbility = "";

                    ImagePath = ImageFolderPath + pq.Image;
                    TTSString = pq.Name + "\n" + pq.Description + "\nReward " + pq.Reward;

                    break;
                case "Guild":
                    Guild g = Cards[0].GetGuild(card);

                    CardName = g.Name;
                    CardStrSkill = g.Description;
                    CardGoldLight = "";
                    CardLevelExp = "";
                    CardCost = "";
                    temp = "";
                    CardTraits = temp;
                    CardAbility = "";

                    ImagePath = ImageFolderPath + g.Image;
                    TTSString = g.Name + "\n" + g.Description;
                    break;
                case "Treasure":
                    // To Do: Add treasure string here
                    break;
                case "Legendary":
                    // To Do: Add Legendary string Here
                    break;
            }

            CardImageSource = ImageSource.FromFile(ImagePath);
            
            //System.Diagnostics.Debug.WriteLine(ImagePath);
            //CardName = ImagePath;
        }

        public ICommand PrevCardCommand => new Command(PrevCard);
        public void PrevCard()
        {
            int index = CardList.IndexOf(CurrCard.Name);
            if (index != -1)
            {
                if (index == 0)
                    index = CardList.Count - 1;
                else
                    index--;
            }
            Card card = Cards[0].GetCard(CardList.ElementAt(index));
            if (card.Type.Equals("Hero")) CardLevel = 1;
            if (card.Type.Equals("Guardian")) CardLevel = 4;
            CurrCard = card;
        }

        public ICommand NextCardCommand => new Command(NextCard);
        public void NextCard()
        {
            int index = CardList.IndexOf(CurrCard.Name);
            if (index != -1)
            {
                if (index == CardList.Count - 1)
                    index = 0;
                else
                    index++;
            }
            Card card = Cards[0].GetCard(CardList.ElementAt(index));
            if (card.Type.Equals("Hero")) CardLevel = 1;
            if (card.Type.Equals("Guardian")) CardLevel = 4;
            CurrCard = card;
        }

        public ICommand UpLevelCommand => new Command(UpLevel);
        public void UpLevel()
        {
            if (CurrCard.Type.Equals("Hero"))
            {
                if (CardLevel < 4) CardLevel++;
                CurrCard = CurrCard;
            }
            if (CurrCard.Type.Equals("Guardian"))
            {
                if (CardLevel < 6) CardLevel++;
                CurrCard = CurrCard;
            }
        }
        public ICommand DownLevelCommand => new Command(DownLevel);
        public void DownLevel()
        {
            if (CurrCard.Type.Equals("Hero"))
            {
                if (CardLevel > 1) CardLevel--;
                CurrCard = CurrCard;
            }
            if (CurrCard.Type.Equals("Guardian"))
            {
                if (CardLevel > 4) CardLevel--;
                CurrCard = CurrCard;
            }
        }

        public ICommand OnMagnifierClickedCommand => new Command(OnMagnifierClicked);
        public void OnMagnifierClicked()
        {
            Navigation.PushModalAsync(new CardMagnifier(ImagePath));
        }

        public ICommand SwitchModeCommand => new Command(SwitchMode);
        public void SwitchMode()
        {
            if (ImageMode == true) ImageMode = false;
            else ImageMode = true;
        }

        public ICommand CloseWindowCommand => new Command(CloseWindow);
        async void CloseWindow()
        {
            await Navigation.PopModalAsync();
        }

        CancellationTokenSource cts;

        public ICommand OnClickSpeechCommand => new Command(OnClickSpeech);

        public async void OnClickSpeech()
        {
            if (SpeechFlag == false)
            {
                // Start Talking
                SpeechFlag = true;

                while (SpeechFlag == false)
                {
                    await Task.Delay(1);
                }

                cts = new CancellationTokenSource();
                await TextToSpeech.SpeakAsync(TTSString, cancelToken: cts.Token).ContinueWith((t) =>
                {
                    SpeechFlag = false;
                    while (SpeechFlag == true)
                    {
                    }

                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            else
            {
                // Cancel Speech

                cts.Cancel();

                SpeechFlag = false;

                while (SpeechFlag == true)
                {
                    await Task.Delay(1);
                }
            }
        }

    }
}