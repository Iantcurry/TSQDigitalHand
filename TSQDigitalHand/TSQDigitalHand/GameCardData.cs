using System;
using System.Collections.Generic;
using System.Text;

namespace TSQDigitalHand
{
    public class GameCardData
    {
        public List<Quest> AllCards { get; set; }
        public List<Card> TownCards { get; set; }
        public List<Card> DungeonCards { get; set; }
        public List<Card> PlayerCards { get; set; }
        public List<Card> PlayerDeck { get; set; }
        public List<Card> PlayerHand { get; set; }
        public List<Card> PlayerGraveyard { get; set; }
        public List<Card> PlayerStatic { get; set; }
        public PlayerData playerData { get; set; }

        public GameCardData()
        {
            TownCards = new List<Card>();
            DungeonCards = new List<Card>();
            PlayerCards = new List<Card>();
            PlayerDeck = new List<Card>();
            PlayerHand = new List<Card>();
            PlayerGraveyard = new List<Card>();
            PlayerStatic = new List<Card>();
            playerData = new PlayerData();
        }

        public GameCardData(List<Quest> cards, List<Card> town, List<Card> dungeon, List<Card> player)
        {
            AllCards = new List<Quest>(cards);
            TownCards = new List<Card>(town);
            DungeonCards = new List<Card>(dungeon);
            PlayerCards = new List<Card>(player);
            PlayerDeck = new List<Card>();
            PlayerHand = new List<Card>();
            PlayerGraveyard = new List<Card>();
            PlayerStatic = new List<Card>();
            playerData = new PlayerData();
            CreateStartingDeck();
        }

        public class PlayerData
        {
            public int life;
            public int exp;
            public string prestige;

            public PlayerData()
            {
                life = 6;
                exp = 0;
                prestige = "None";
            }

            public PlayerData(int life, int exp, string prestige)
            {
                this.life = life;
                this.exp = exp;
                this.prestige = prestige;
            }

            public void AddLife(int inc = 1)
            {
                this.life += inc;
                if (this.life > 6) this.life = 6;
            }
            public void LoseLife(int dec = 1)
            {
                this.life -= dec;
                if (this.life < 0) this.life = 0;
            }
            public void AddExp(int inc = 1)
            {
                this.exp += inc;
            }
            public void LoseExp(int dec = 1)
            {
                this.exp -= dec;
                if (this.exp < 0) this.exp = 0;
            }
        }

        public void AddLife(int inc = 1)
        {
            this.playerData.life += inc;
            if (this.playerData.life > 6) this.playerData.life = 6;
        }
        public void LoseLife(int dec = 1)
        {
            this.playerData.life -= dec;
            if (this.playerData.life < 0) this.playerData.life = 0;
        }
        public void AddExp(int inc = 1)
        {
            this.playerData.exp += inc;
        }
        public void LoseExp(int dec = 1)
        {
            this.playerData.exp -= dec;
            if (this.playerData.exp < 0) this.playerData.exp = 0;
        }

        private Card GetCard(string cardname)
        {
            Card card = null;

            foreach (Quest q in AllCards)
            {
                Card temp = q.GetCard(cardname);
                if (temp != null) card = temp;
            }

            return card;
        }


        public void CreateStartingDeck()
        {
            for (int i = 0; i < 6; i++)
            {
                PlayerDeck.Add(new Hero("Adventurer", 0));
            }
            for (int i = 0; i < 2; i++)
            {
                PlayerDeck.Add(new Weapon("Dagger"));
            }
            for (int i = 0; i < 2; i++)
            {
                PlayerDeck.Add(new Item("Lantern"));
            }
            for (int i = 0; i < 2; i++)
            {
                PlayerDeck.Add(new Item("Thunderstone Shard"));
            }
        }
    }
}
