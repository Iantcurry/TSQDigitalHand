using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace TSQDigitalHand
{

    public partial class MainPage : ContentPage
    {
        private SettingsClass settings;
        public List<Quest> _cards;

        public MainPage()
        {
            InitializeComponent();

            LoadJSONData();

            settings = new SettingsClass();
            LoadSettings();
        }

        public void LoadJSONData()
        {
            RootValue rootValue = new RootValue();
            _cards = new List<Quest>();
            //_cards = JsonConvert.DeserializeObject<Card>("Cards.json");
            string jsonString;
            string jsonFileName = "Cards.json";
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
            using (var reader = new StreamReader(stream))
            {
                jsonString = reader.ReadToEnd();
            }
            System.Diagnostics.Debug.WriteLine(jsonString);

            rootValue = JsonConvert.DeserializeObject<RootValue>(jsonString);
            _cards = new List<Quest>(rootValue.Quests);
            //System.Diagnostics.Debug.WriteLine("Name Here:");
            //System.Diagnostics.Debug.WriteLine(_cards[0].Name);

        }

        public class RootValue
        {
            public List<Quest> Quests;

            public RootValue()
            {
                Quests = new List<Quest>();
            }
        }

        private void OnSettingsClicked(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new Settings(settings));
        }

        public void LoadSettings()
        {
            settings.FontSize = Preferences.Get("FontSize", 50.0);
        }

        private void OnCardViewCliked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CardViewerListPage(settings, _cards));
        }
    }
}
