using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Threading;

namespace TSQDigitalHand
{

    public class CardViewerListPageViewModel : BindableObject
    {
        public INavigation Navigation { get; set; }
        public SettingsClass _settings { get; set; }
        public ObservableCollection<String> _cardnames { get; set; }
        public ObservableCollection<String> CardNames
        {
            get { return _cardnames; }
            set { _cardnames = value; OnPropertyChanged(); }
        }
        public double _textsize;
        public double TextSize
        {
            get { return _textsize; }
            set { _textsize = value; OnPropertyChanged(); }
        }
        public int _height;
        public int Height
        {
            get { return _height; }
            set { _height = value; OnPropertyChanged(); }
        }
        public List<Quest> _cards;
        public List<Quest> Cards
        {
            get { return _cards; }
            set { _cards = value; OnPropertyChanged(); }
        }
        public string _itemType;
        public string ItemType
        {
            get { return _itemType; }
            set {
                if (_itemType != value)
                {
                    _itemType = value;

                    CreateCardNameList();

                    OnPropertyChanged();
                }
            }
        }
        public string _lvSelectedItem;
        public string lvSelectedItem
        {
            get { return _lvSelectedItem; }
            set {
                if (_lvSelectedItem != value)
                {
                    _lvSelectedItem = value;

                    //May need to do something here????

                    OnPropertyChanged();
                }
                 }
        }


        public CardViewerListPageViewModel()
        {

        }

        public CardViewerListPageViewModel(SettingsClass settings, List<Quest> cards, INavigation navigation)
        {
            _settings = settings;
            Cards = cards;
            Navigation = navigation;
            
            CreateCardNameList();

            ItemType = "All";
            TextSize = _settings.FontSize;
            Height = (int) TextSize + 25;


        }

        public void CreateCardNameList()
        {
            List<string> tempnames = new List<string>();
            for (int i = 0; i < Cards.Count; i++)
            {
                if (ItemType == "All" || ItemType == "Heroes")
                {
                    for (int j = 0; j < Cards[i].Heroes.Count; j++)
                    {
                        tempnames.Add(Cards[i].Heroes[j].Name);
                    }
                }
                if (ItemType == "All" || ItemType == "Spells")
                {
                    for (int j = 0; j < Cards[i].Spells.Count; j++)
                    {
                        tempnames.Add(Cards[i].Spells[j].Name);
                    }
                }
                if (ItemType == "All" || ItemType == "Items")
                {
                    for (int j = 0; j < Cards[i].Items.Count; j++)
                    {
                        tempnames.Add(Cards[i].Items[j].Name);
                    }
                }
                if (ItemType == "All" || ItemType == "Weapons")
                {
                    for (int j = 0; j < Cards[i].Weapons.Count; j++)
                    {
                        tempnames.Add(Cards[i].Weapons[j].Name);
                    }
                }
                if (ItemType == "All" || ItemType == "Monster")
                {
                    for (int j = 0; j < Cards[i].Monsters.Count; j++)
                    {
                        tempnames.Add(Cards[i].Monsters[j].Name);
                    }
                }
                if (ItemType == "All" || ItemType == "Guardian")
                {
                    for (int j = 0; j < Cards[i].Guardians.Count; j++)
                    {
                        tempnames.Add(Cards[i].Guardians[j].Name);
                    }
                }
            }
            tempnames.Sort();
            CardNames = new ObservableCollection<string>(tempnames);
        }

        public ICommand CloseWindowCommand => new Command(CloseWindow);
        async void CloseWindow()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }


        public ICommand OnOkClickedCommand => new Command(OnOkClicked);
        void OnOkClicked()
        {
            if (lvSelectedItem != "")
            {
                int cardlevel = -1;
                Card card = Cards[0].GetCard(lvSelectedItem);
                if (card != null)
                {
                    if (card.Type.Equals("Hero")) cardlevel = 1;
                    if (card.Type.Equals("Guardians")) cardlevel = 4;
                }
                Navigation.PushModalAsync(new CardViewer(_settings, Cards, new List<string>(CardNames), lvSelectedItem, cardlevel, Navigation));
            }
        }


    }

}