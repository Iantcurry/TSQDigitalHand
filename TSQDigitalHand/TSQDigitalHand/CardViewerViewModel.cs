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
            set { _startCard = value; OnPropertyChanged(); }
        }

        public CardViewerViewModel(SettingsClass settings, List<Quest> Cards, List<string> cardList, string selectedCard)
        {
            TextSize = settings.FontSize;
            StartCard = selectedCard;
        }
    }
}