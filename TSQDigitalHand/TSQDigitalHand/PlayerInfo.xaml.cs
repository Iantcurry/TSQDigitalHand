using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static TSQDigitalHand.GameCardData;

namespace TSQDigitalHand
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerInfo : ContentPage
    {
        public List<Quest> AllCards;
        public List<Card> PlayerCards;
        public SettingsClass settings;
        public PlayerData playerData;

        public double _textsize;
        public double TextSize
        {
            get { return _textsize; }
            set { _textsize = value; OnPropertyChanged(); }
        }
        public PlayerInfo(List<Quest> _cards, List<Card> playercards, PlayerData player, SettingsClass _settings)
        {
            settings = _settings;
            PlayerCards = playercards;
            playerData = player;
            AllCards = _cards;

            TextSize = settings.FontSize;

            InitializeComponent();

            lbl_Life.Text = "Life: " + playerData?.life.ToString();
            lbl_Exp.Text = "Exp: " + playerData?.exp.ToString();

            BindingContext = this;
        }

        public PlayerInfo()
        {

        }

        public async void OnCancel(object sender, EventArgs e)
        {
            // Close ..... add an apply/ok button, or just always save?
            await Navigation.PopModalAsync();
        }

        public void OnLoseLife(object sender, EventArgs e)
        {
            playerData.LoseLife();
            lbl_Life.Text = "Life: " + playerData.life.ToString();
        }
        public void OnGainLife(object sender, EventArgs e)
        {
            playerData.AddLife();
            lbl_Life.Text = "Life: " + playerData.life.ToString();
        }
        public void OnLoseExp(object sender, EventArgs e)
        {
            playerData.LoseExp();
            lbl_Exp.Text = "Exp: " + playerData.exp.ToString();
        }
        public void OnGainExp(object sender, EventArgs e)
        {
            playerData.AddExp();
            lbl_Exp.Text = "Exp: " + playerData.exp.ToString();
        }

        public async void OnGuild(object sender, EventArgs e)
        {
            Card card = null;
            List<string> viewcard = new List<string>();
            foreach (Card c in PlayerCards)
            {
                if (c.Type.Equals("Guild"))
                {
                    card = c;
                    viewcard.Add(c.Name);
                }
            }

            var modalPage = new CardViewer(settings, AllCards, viewcard, card.Name, -1, Navigation);
            await Navigation.showpageasdialog(modalPage);
        }
        public async void OnSideQuest(object sender, EventArgs e)
        {
            Card card = null;
            List<string> viewcard = new List<string>();
            foreach (Card c in PlayerCards)
            {
                if (c.Type.Equals("PersonalQuest"))
                {
                    card = c;
                    viewcard.Add(c.Name);
                }
            }

            var modalPage = new CardViewer(settings, AllCards, viewcard, card.Name, -1, Navigation);
            await Navigation.showpageasdialog(modalPage);
        }

        public async void OnSettings(object sender, EventArgs e)
        {
            // Call Settings Page
            var page = new Settings(settings);
            await Navigation.showpageasdialog(page);

            // Update Settings
            TextSize = settings.FontSize;
        }
    }
}