using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TSQDigitalHand
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DungeonRoomPage : ContentPage
    {
        public GameCardData GameData { get; set; }
        public SettingsClass settings { get; set; }
        public double _textsize;
        public double TextSize
        {
            get { return _textsize; }
            set { _textsize = value; OnPropertyChanged(); }
        }
        public int _whichroom;
        public int WhichRoom
        {
            get { return _whichroom; }
            set { _whichroom = value; 
                
                //change rooms here
                
                OnPropertyChanged(); }
        }

        public Monster RoomMonster { get; set; }
        public string _roomvalue;
        public string RoomValue
        {
            get { return _roomvalue; }
            set { _roomvalue = value; OnPropertyChanged(); }
        }
        public Room ThisRoom { get; set; }
        public bool _speechflag;
        public bool SpeechFlag
        {
            get { return _speechflag; }
            set { _speechflag = value; OnPropertyChanged(); }
        }

        public DungeonRoomPage(GameCardData data, SettingsClass _settings, string room)
        {
            GameData = data;
            settings = _settings;
            RoomValue = room;

            TextSize = settings.FontSize;
            WhichRoom = 1;
            RoomMonster = GameData.DungeonData.Monsters[room];
            ThisRoom = GameData.DungeonData.Rooms[room];

            InitializeComponent();

            SetRoom(ThisRoom);

            if (room.Equals("Wilderness"))
            {
                btn_SwitchRoom.IsVisible = false;
            }

            BindingContext = this;
        }

        public DungeonRoomPage()
        {

        }
        public void SetRoom(Room r)
        {
            if (r == null) SetRoomValues("Choose Room", "0", "0", "0", "0", "None", "0", "n/a", "0", "None");
            else SetRoomValues(r.Name, r.Light_Req, r.HP_Bonus, r.Armour_Bonus, r.Resistance_Bonus,
                               r.Ability, r.Wound_Bonus, r.Wound_Type, r.Exp_Bonus, r.Reward);
        }

        public void SetRoomValues(string name, string light, string hp, string ar, string res, string ab, 
                                  string wnd, string wt, string xp, string rw)
        {
            btn_RoomName.Text = name;
            lbl_Light.Text = "Light req: " + light;
            lbl_HP.Text = "HP: " + hp;
            lbl_Armour.Text = "Ar: " + ar;
            lbl_Resistance.Text = "Res: " + res;
            lbl_Ability.Text = ab;
            lbl_Wounds.Text = "Wnd: " + wnd;
            lbl_WoundType.Text = "Type: " + wt;
            lbl_Exp.Text = "Exp: " + xp;
            lbl_Reward.Text = "Reward: " + rw;
        }

        public async void OnRoomName(object sender, EventArgs e)
        {
            if (RoomValue != "Wilderness")
            {
                List<Room> goodrooms = new List<Room>();
                goodrooms.AddRange(GameData.GetRoomList().Where(r => r.Level.Equals(RoomValue[RoomValue.Length - 3].ToString())).ToList());


                // Call room choice page (can use setup??)
                var page = new CardListPage(GameData, settings, goodrooms);
                await Navigation.showpageasdialog(page);

                if (page.result == 1)
                {
                    GameData.DungeonData.Rooms[RoomValue] = GameData.GetRoom(page.lvSelectedItem);
                    ThisRoom = GameData.DungeonData.Rooms[RoomValue];
                    SetRoom(ThisRoom);
                }
            }
        }

        CancellationTokenSource cts;
        public async void OnTextToSpeech(object sender, EventArgs e)
        {
            string TTSString = "";
            if (GameData.DungeonData.Rooms[RoomValue] == null)
            {
                TTSString = "No room chosen, please choose a room.";
            }
            else
            {
                TTSString += ThisRoom.Name + ".\n";
                TTSString += "Light Requirement is " + ThisRoom.Light_Req + ".\n";
                if ((!ThisRoom.HP_Bonus.Equals("+0")) || (!ThisRoom.Armour_Bonus.Equals("+0")) || (!ThisRoom.Resistance_Bonus.Equals("+0")))
                    TTSString += "HP Bonus is " + ThisRoom.HP_Bonus + ", Armor Bonus is " + ThisRoom.Armour_Bonus +
                             ", Resistance Bonus is " + ThisRoom.Resistance_Bonus + ".\n";
                if (!(ThisRoom.Ability.Equals("None")))
                    TTSString += ThisRoom.Ability + ".\n";
                if (!(ThisRoom.Wound_Bonus.Equals("0")))
                    TTSString += "Wound Bonus is " + ThisRoom.Wound_Bonus + ", of " + ThisRoom.Wound_Type + " type.\n";
                TTSString += "Experience bonus is " + ThisRoom.Exp_Bonus + ", Reward is " + ThisRoom.Reward + ".\n";
                if (GameData.DungeonData.Monsters[RoomValue] == null)
                    TTSString += "No Monster Set";
                else TTSString += "Monster is " + GameData.DungeonData.Monsters[RoomValue].Name;
            }
            // create string for speech
            // make sound happen here.....
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

        public async void OnMonster(object sender, EventArgs e)
        {
            if (ThisRoom == null) return;
            // show current monster
            if (GameData.DungeonData.Monsters[RoomValue] == null) // No monster set
            {
                Card mg = GameData.GetMonsterGroupByLevel(Int32.Parse(ThisRoom.Level));
                List<Card> monsters = new List<Card>(GameData.GetCardList("Monster", mg.Name));

                var page = new CardListPage(GameData, settings, monsters);
                await Navigation.showpageasdialog(page);
                if (page.result == 1)
                {
                    // OK was clicked, save name, and call card selection screen for verification
                    //System.Diagnostics.Debug.WriteLine(page.lvSelectedItem.ToString());
                    Card card = GameData.GetCard(page.lvSelectedItem);
                    if (card != null)
                    {
                        List<Card> chosencard = new List<Card>();
                        chosencard.Add(card);

                        var page2 = new CardSetup(new List<string>(), GameData.AllCards, chosencard, "Verify", settings);
                        await Navigation.showpageasdialog(page2);
                        if (page2.verification)
                        {
                            Monster m = null;
                            foreach (Quest q in GameData.AllCards)
                            {
                                m = q.GetMonster(card);
                            }
                            GameData.DungeonData.Monsters[RoomValue] = m;
                        }
                    }
                }
            }
            else // Monster Set
            {
                List<Card> chosencard = new List<Card>();
                chosencard.Add(GameData.DungeonData.Monsters[RoomValue]);

                var page = new CardSetup(new List<string>(), GameData.AllCards,
                                         chosencard, "Change Monster?", settings);
                await Navigation.showpageasdialog(page);
                if (!RoomValue.Equals("Wilderness"))
                {
                    if (page.verification)
                    {
                        GameData.DungeonData.Monsters[RoomValue] = null;
                        OnMonster(sender, e);
                    }
                }
            }
        }

        public void OnSwitchRoom(object sender, EventArgs e)
        {
            if (WhichRoom == 1)
            {
                WhichRoom = 2;
                RoomValue = RoomValue.Substring(0, RoomValue.Length - 1) + '2';
                btn_SwitchRoom.Source = "one.png";
            }
            else
            {
                WhichRoom = 1;
                RoomValue = RoomValue.Substring(0, RoomValue.Length - 1) + '1';
                btn_SwitchRoom.Source = "two.png";
            }
            //System.Diagnostics.Debug.WriteLine(WhichRoom);
            ThisRoom = GameData.DungeonData.Rooms[RoomValue];
            SetRoom(ThisRoom);
        }
        public async void OnCancel(object sender, EventArgs e)
        {
            // Make sure Game data is fully updated
            // should be done by each function.

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
    }
}