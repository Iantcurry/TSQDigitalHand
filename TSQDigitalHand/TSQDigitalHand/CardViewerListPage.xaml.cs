using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace TSQDigitalHand
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardViewerListPage : ContentPage
    {
        public SettingsClass _settings;
        public ViewCell lastCell;

        public CardViewerListPage(SettingsClass settings, List<Quest> cards)
        {
            


            InitializeComponent();

            pck_CardType.ItemsSource = new PickerModel().CardTypes;
            //pck_CardType.SelectedIndex = 0;

            _settings = settings;
            var page = new CardViewerListPageViewModel(_settings, cards, Navigation);
            page.ScrollListView = ScrollToTop;
            BindingContext = page;

        }

        public void ScrollToTop(string cardname)
        {
            System.Diagnostics.Debug.WriteLine(cardname);
            //lv_CardNameList.ScrollTo(cardname, ScrollToPosition.MakeVisible, true);
            sv_ListView.ScrollToAsync(0, 0, false);
        }

        class PickerModel
        {
            public List<string> CardTypes { get; set; }

            public PickerModel()
            {
                CardTypes = new List<string>();
                CardTypes.Add("All");
                CardTypes.Add("Heroes");
                CardTypes.Add("Weapons");
                CardTypes.Add("Items");
                CardTypes.Add("Spells");
                CardTypes.Add("Monster");
                CardTypes.Add("Guardian");
                CardTypes.Add("Personal Quest");
                CardTypes.Add("Guild");
                CardTypes.Add("Treasure");
                CardTypes.Add("Legendary");
                CardTypes.Add("Rooms");
            }
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