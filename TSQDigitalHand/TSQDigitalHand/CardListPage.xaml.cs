using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TSQDigitalHand
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardListPage : ContentPage
    {
        public SettingsClass settings { get; set; }
        public GameCardData GameData { get; set; }
        public ViewCell lastCell { get; set; }
        public double _textsize;
        public double TextSize
        {
            get { return _textsize; }
            set { _textsize = value; OnPropertyChanged();  }
        }
        public int result;
        public string _entrytext;
        public string EntryText
        {
            get { return _entrytext; }
            set { _entrytext = value;

                CreateCardNameList(ViewableCards);

                SetCardList();

                OnPropertyChanged(); }
        }
        public ObservableCollection<string> _cardnames;
        public ObservableCollection<string> CardNames
        {
            get { return _cardnames; }
            set { _cardnames = value; OnPropertyChanged(); }
        }
        public List<Card> ViewableCards;
        public string _lvselecteditem;
        public string lvSelectedItem
        {
            get { return _lvselecteditem; }
            set { _lvselecteditem = value; OnPropertyChanged(); }
        }
        public List<Room> ViewableRooms;
        public string mode;

        public CardListPage(GameCardData data, SettingsClass _settings, List<Card> _cards)
        {
            settings = _settings;
            GameData = data;
            ViewableCards = new List<Card>(_cards);
            mode = "Card";

            TextSize = settings.FontSize;
            result = -1;

            CreateCardNameList(ViewableCards);
            
            InitializeComponent();

            BindingContext = this;
        }

        public CardListPage(GameCardData data, SettingsClass _settings, List<Room> _rooms)
        {
            settings= _settings;
            GameData = data;
            ViewableRooms = new List<Room>(_rooms);
            mode = "Rooms";

            TextSize = settings.FontSize;
            result = -1;

            CreateRoomNameList(ViewableRooms);

            InitializeComponent();

            BindingContext = this;
        }

        public CardListPage()
        {

        }
        public void CreateRoomNameList(List<Room> rooms)
        {
            List<string> temp = new List<string>();
            foreach (Room r in rooms)
            {
                temp.Add(r.Name);
            }
            temp.Sort();

            CardNames = new ObservableCollection<string>(temp);

        }

        public void CreateCardNameList(List<Card> cards)
        {
            List<string> temp = new List<string>();
            foreach (Card c in cards)
            {
                temp.Add(c.Name);
            }
            temp.Sort();

            CardNames = new ObservableCollection<string>(temp);
            
        }

        public void SetCardList()
        {
            CardNames = new ObservableCollection<string>(CardNames.Where(c => c.ToLower().Contains(EntryText.ToLower())));

            sv_ListView.ScrollToAsync(0, 0, false);
        }

        public async void OnOk(object sender, EventArgs e)
        {
            result = 1;
            // Close current window
            await Navigation.PopModalAsync();
        }

        public async void OnCancel(object sender, EventArgs e)
        {
            // Make sure Game data is fully updated
            // should be done by each function.
            result = 0;
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

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            if (lastCell != null)
                lastCell.View.BackgroundColor = Color.Transparent;
            var viewCell = (ViewCell)sender;
            if (viewCell.View != null)
            {
                viewCell.View.BackgroundColor = Color.DarkGray;
                lastCell = viewCell;
            }
        }
    }
}