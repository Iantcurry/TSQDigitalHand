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

            BindingContext = new CardViewerListPageViewModel(_settings, cards, Navigation);

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