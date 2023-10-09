using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using System.Windows.Input;

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
        public string Imagepath
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


        public CardViewerViewModel(SettingsClass settings, List<Quest> cards, List<string> cardList, string selectedCard, int cardlevel)
        {
            CardList = new List<string>(cardList);
            Cards = cards;
            TextSize = settings.FontSize;
            Imagepath = "NoPic.png";
            StartCard = selectedCard;
            CardLevel = cardlevel;
            CurrCard = Cards[0].GetCard(selectedCard);
            ImageMode = true;
        }

        public void SetCurrentCard(Card card, string Type)
        {
            string temp;
            switch (Type)
            {
                case "Hero":
                    Hero hero = Cards[0].GetHero(card);

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
                    Imagepath = currLevel.Image;

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


                    Imagepath = spell.Image;
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

                    Imagepath = weapon.Image;
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

                    Imagepath = item.Image;
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

                    Imagepath = monster.Image;
                    break;
                case "Guardian":
                    Guardian guardian = Cards[0].GetGuardian(card);

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

                    Imagepath = level.Image;
                    break;
            }


            
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

        public ICommand SwitchModeCommand => new Command(SwitchMode);
        public void SwitchMode()
        {
            if (ImageMode == true) ImageMode = false;
            else ImageMode = true;
        }

        public ICommand CloseWindowCommand => new Command(CloseWindow);
        async void CloseWindow()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

    }
}