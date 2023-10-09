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
    public partial class CardViewer : ContentPage
    {
        public CardViewer(SettingsClass settings, List<Quest> Cards, List<string> cardList, string selectedCard, int cardLevel)
        {
            InitializeComponent();

            BindingContext = new CardViewerViewModel(settings, Cards, cardList, selectedCard, cardLevel);
        }
    }
}