using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace TSQDigitalHand
{
    public class Quest : BindableObject
    {
        public string Name;
        public List<Hero> Heroes { get; set; } 
        public List<Spell> Spells { get; set; }
        public List<Weapon> Weapons { get; set; }
        public List<Item> Items { get; set; }
        public List<Monster> Monsters { get; set; }
        public List<Guardian> Guardians { get; set; }
        public List<Ally> Allies { get; set; }
        public List<MonsterGroup> MonsterGroups { get; set; }
        public List<PersonalQuest> PersonalQuests { get; set; }
        public List<Guild> Guilds { get; set; }
        public List<Treasure> Treasures { get; set; }
        public List<Legendary> Legendaries { get; set; }

        public Quest()
        {
            Heroes = new List<Hero>();
            Spells = new List<Spell>();
            Weapons = new List<Weapon>();
            Items = new List<Item>();
            Monsters = new List<Monster>();
            Guardians = new List<Guardian>();
            Allies = new List<Ally>();
            MonsterGroups = new List<MonsterGroup>();
            PersonalQuests = new List<PersonalQuest>();
            Guilds = new List<Guild>();
            Treasures = new List<Treasure>();
            Legendaries = new List<Legendary>();
        }

        public Card GetCard(string cardname)
        {
            Card card;

            foreach (Hero hero in Heroes)
            {
                if (hero.Name.Equals(cardname))
                {
                    card = hero;
                    return hero;
                }
            }

            foreach (Spell spell in Spells)
            {
                if (spell.Name.Equals(cardname))
                {
                    card = spell;
                    return spell;
                }
            }

            foreach (Weapon weapon in Weapons)
            {
                if (weapon.Name.Equals(cardname))
                { 
                    card = weapon;
                    return weapon;
                }
            }

            foreach (Item item in Items)
            {
                if (item.Name.Equals(cardname))
                {
                    card = item;
                    return item;
                }
            }

            foreach (Monster monster in Monsters)
            {
                if (monster.Name.Equals(cardname))
                {
                    card = monster;
                    return monster;
                }
            }

            foreach (Guardian guardian in Guardians)
            {
                if (guardian.Name.Equals(cardname))
                {
                    card = guardian;
                    return guardian;

                }
            }

            foreach (MonsterGroup group in MonsterGroups)
            {
                if (group.Name.Equals(cardname))
                {
                    card = group;
                    return group;
                }
            }

            foreach (PersonalQuest pq in PersonalQuests)
            {
                if (pq.Name.Equals(cardname))
                {
                    card = pq;
                    return pq;
                }
            }

            foreach (Guild g in Guilds)
            {
                if (g.Name.Equals(cardname))
                {
                    card = g;
                    return g;
                }
            }

            foreach (Treasure t in Treasures)
            {
                if(t.Name.Equals(cardname))
                {
                    card = t;
                    return t;
                }
            }

            foreach (Legendary l in Legendaries)
            {
                if(l.Name.Equals(cardname))
                {
                    card = l;
                    return l;
                }
            }

            return null;
        }

        public Hero GetHero(Card card)
        {
            foreach (Hero hero in Heroes)
            {
                if (card.Name.Equals(hero.Name)) return hero;
            }
            return null;
        }

        public Spell GetSpell(Card card)
        {
            foreach (Spell spell in Spells)
            {
                if (spell.Name.Equals(card.Name)) return spell;
            }
            return null;
        }

        public Item GetItem(Card card)
        {
            foreach(Item item in Items)
            {
                if (item.Name.Equals(card.Name)) return item;
            }
            return null;
        }

        public Weapon GetWeapon(Card card)
        {
            foreach(Weapon weapon in Weapons)
            {
                if (weapon.Name.Equals(card.Name)) return weapon;
            }
            return null;
        }

        public Monster GetMonster(Card card)
        {
            foreach(Monster monster in Monsters)
            {
                if (monster.Name.Equals(card.Name)) return monster;
            }
            return null;
        }

        public Guardian GetGuardian(Card card)
        {
            foreach(Guardian guardian in Guardians)
            {
                if (guardian.Name.Equals(card.Name)) return guardian;
            }
            return null;
        }

        public MonsterGroup GetMonsterGroup(Card card)
        {
            foreach(MonsterGroup group in MonsterGroups)
            {
                if (group.Name.Equals(card.Name)) return group;
            }
            return null;
        }

        public PersonalQuest GetPersonalQuest(Card card)
        {
            foreach(PersonalQuest personalQuest in PersonalQuests)
            {
                if (personalQuest.Name.Equals(card.Name)) return personalQuest;
            }
            return null;
        }

        public Guild GetGuild(Card card)
        {
            foreach (Guild guild in Guilds)
            {
                if (guild.Name.Equals(card.Name)) return guild;
            }
            return null;
        }

        public Treasure GetTreasure(Card card)
        {
            foreach (Treasure treasure in Treasures)
            {
                if (treasure.Name.Equals(card.Name)) return treasure;
            }
            return null;
        }

        public Legendary GetLegendary(Card card)
        {
            foreach (Legendary legendary in Legendaries)
            {
                if (!legendary.Name.Equals(card.Name)) return legendary;
            }
            return null;
        }

        public List<Card> GetCardList(string type, string trait)
        {
            List<Card> cards = new List<Card>();

            switch (type)
            {
                case "Hero":
                    foreach (Hero hero in Heroes)
                    {
                        foreach (Levels level in hero.Levels)
                        {
                            if (level.Traits.Contains(trait))
                            {
                                cards.Add(hero);
                                break;
                            }
                        }
                    }
                    break;
                case "Item":
                    foreach (Item i in Items)
                    {
                        cards.Add(i);
                    }
                    break;
                case "Weapon":
                    foreach (Weapon w in Weapons)
                    {
                        cards.Add(w);
                    }
                    break;
                case "Spell":
                    foreach (Spell s in Spells)
                    {
                        cards.Add(s);
                    }
                    break;
                case "Ally":
                    foreach (Ally a in Allies)
                    {
                        cards.Add(a);
                    }
                    break;
                case "Monster":
                    foreach (Monster m in Monsters)
                    {
                        if (m.Group.Equals(trait)) cards.Add(m);
                    }
                    break;
                case "Guardian":
                    foreach (Guardian g in Guardians)
                    {
                        foreach (GLevel gLevel in g.Levels)
                        {
                            if (gLevel.Traits.Contains(trait)) cards.Add(g);
                        }
                    }
                    break;
                case "MonsterGroup":
                    foreach (MonsterGroup g in MonsterGroups)
                    {
                        if (g.Level == trait) cards.Add(g);
                    }
                    break;
                case "PersonalQuest":
                    foreach (PersonalQuest personalQuest in PersonalQuests)
                    {
                        if (personalQuest.Name.Equals(trait)) cards.Add(personalQuest);
                    }
                    break;
                case "Guild":
                    foreach (Guild g in Guilds)
                    {
                        if (g.Name.Equals(trait)) cards.Add(g);
                    }
                    break;
                case "Treasure":
                    foreach (Treasure t in Treasures)
                    {
                        if (t.Traits.Contains(trait)) cards.Add(t);
                    }
                    break;
                case "Legendary":
                    foreach (Legendary l in Legendaries)
                    {
                        if (l.Traits.Contains(trait)) cards.Add(l);
                    }
                    break;
            }

            return cards;
        }

        public List<MonsterGroup> GetMonsterGroups()
        {
            List<MonsterGroup> groups = new List<MonsterGroup>();

            foreach(Monster m in Monsters)
            {
                groups.Add(new MonsterGroup(m.Group, m.Level, m.Image));
            }

            groups = new List<MonsterGroup>(groups.GroupBy(x => x.Name).Select(g => g.First()).ToList());

            return groups;
        }

    }

    public interface Card : IComparable
    {
        string Name { get; set; }
        string Type { get; set; }

        int CardLevel { get; set; }
        int BaseLevel { get; set; }
    }

    public class Hero : Card
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public int CardLevel { get; set; }
        public int BaseLevel { get; set; }
        public List<Levels> Levels { get; set; }

        public Hero()
        {
            Levels = new List<Levels>();
            Type = "Hero";
            CardLevel = 1;
            BaseLevel = 1;
        }

        public Hero(string name, int level)
        {
            Name = name;
            Type = "Hero";
            CardLevel = level;
            BaseLevel = 4;
        }

        public Levels GetLevel(int level)
        {
            //System.Diagnostics.Debug.WriteLine(level.ToString());
            foreach (Levels l in Levels)
            {
                if (l.Level == level) return l;
            }

            return null;
        }

        public int CompareTo(object incomingobject)
        {
            Card incomingcard = incomingobject as Card;

            return this.Name.CompareTo(incomingcard.Name);
        }
    }

    public class Levels
    {
        public int Level { get; set; }
        public string Strength { get; set; }
        public string Attack_Type { get; set; }
        public string Weapon_Skill { get; set; }
        public string Gold { get; set; }
        public string Light { get; set; }
        public string Exp { get; set; }
        public string Cost { get; set; }
        public List<string> Traits { get; set; }
        public string Ability { get; set; }
        public string Image { get; set; }
    }

    public class Spell : Card
    {
        public string Name { get; set; }
        public string Strength { set; get; }
        public string Attack_Type { set; get; }
        public string Weapon_Skill { set; get; }
        public string Gold { set; get; }
        public string Light { set; get; }
        public string Exp { set; get; }
        public string Cost { set; get; }
        public List<string> Traits { get; set; }
        public string Ability { set; get; }
        public string Image { get; set; }
        public string Type { get; set; }
        public int CardLevel { get; set; }
        public int BaseLevel { get; set; }

        public Spell()
        {
            Type = "Spell";
            CardLevel = -1;
            BaseLevel = -1;
        }

        public Spell(string name)
        {
            Name = name;
            Type = "Spell";
            CardLevel = -1;
            BaseLevel = -1;
        }

        public int CompareTo(object incomingobject)
        {
            Card incomingcard = incomingobject as Card;

            return this.Name.CompareTo(incomingcard.Name);
        }
    }

    public class Item : Card
    {
        public string Name { get; set; }
        public string Strength { set; get; }
        public string Attack_Type { set; get; }
        public string Weapon_Skill { set; get; }
        public string Gold { set; get; }
        public string Light { set; get; }
        public string Exp { set; get; }
        public string Cost { set; get; }
        public List<string> Traits { get; set; }
        public string Ability { set; get; }
        public string Image { get; set; }
        public string Type { get; set; }
        public int CardLevel { get; set; }
        public int BaseLevel { get; set; }

        public Item()
        {
            Type = "Item";
            CardLevel = -1;
            BaseLevel = -1;
        }
        public Item(string name)
        {
            Name = name;
            Type = "Item";
            CardLevel = -1;
            BaseLevel = -1;
        }

        public int CompareTo(object incomingobject)
        {
            Card incomingcard = incomingobject as Card;

            return this.Name.CompareTo(incomingcard.Name);
        }
    }
    public class Weapon : Card
    {
        public string Name { get; set; }
        public string Strength { set; get; }
        public string Attack_Type { set; get; }
        public string Weapon_Skill { set; get; }
        public string Gold { set; get; }
        public string Light { set; get; }
        public string Exp { set; get; }
        public string Cost { set; get; }
        public List<string> Traits { get; set; }
        public string Ability { set; get; }
        public string Image { get; set; }
        public string Type { get; set; }
        public int CardLevel { get; set; }
        public int BaseLevel { get; set; }

        public Weapon()
        {
            Type = "Weapon";
            CardLevel = -1;
            BaseLevel = -1;
        }
        public Weapon(string name)
        {
            Name = name;
            Type = "Weapon";
            CardLevel = -1;
            BaseLevel = -1;
        }
        public int CompareTo(object incomingobject)
        {
            Card incomingcard = incomingobject as Card;

            return this.Name.CompareTo(incomingcard.Name);
        }
    }

    public class Ally : Card
    {
        public string Name { get; set; }
        public string Strength { set; get; }
        public string Attack_Type { set; get; }
        public string Weapon_Skill { set; get; }
        public string Gold { set; get; }
        public string Light { set; get; }
        public string Exp { set; get; }
        public string Cost { set; get; }
        public List<string> Traits { get; set; }
        public string Ability { set; get; }
        public string Image { get; set; }
        public string Type { get; set; }
        public int CardLevel { get; set; }
        public int BaseLevel { get; set; }

        public Ally()
        {
            Type = "Ally";
            CardLevel = 1;
            BaseLevel = 1;
        }
        public Ally(string name)
        {
            Name = name;
            Type = "Ally";
            CardLevel = 1;
            BaseLevel = 1;
        }
        public int CompareTo(object incomingobject)
        {
            Card incomingcard = incomingobject as Card;

            return this.Name.CompareTo(incomingcard.Name);
        }
    }
    public class Monster : Card
    {
        public string Name { set; get; }
        public string Group { set; get; }
        public string Type { set; get; }
        public string HP { set; get; }
        public string Armour { set; get; }
        public string Armour_Type { set; get; }
        public string Wounds { set; get; }
        public string Wound_Type { set; get; }
        public string Exp { set; get; }
        public string Reward { set; get; }
        public string Level { set; get; }
        public List<string> Traits { set; get; }
        public string Ability { get; set; }
        public string Image { set; get; }
        public int CardLevel { get; set; }
        public int BaseLevel { get; set; }

        public Monster()
        {
            Type = "Monster";
            CardLevel = -1;
            BaseLevel = -1;
        }
        public int CompareTo(object incomingobject)
        {
            Card incomingcard = incomingobject as Card;

            return this.Name.CompareTo(incomingcard.Name);
        }
    }

    public class MonsterGroup : Card
    {
        public string Name { set; get; }
        public string Level { get; set; }
        public string Type { set; get; }
        public int CardLevel { get; set; }
        public int BaseLevel { set; get; }
        public string Image { set; get; }

        public MonsterGroup(string name, string level, string imagePath)
        {
            Name = name;
            Level = level;
            Type = "MonsterGroup";
            CardLevel = Int32.Parse(level);
            BaseLevel = CardLevel;
            Image = imagePath;
        }

        public int CompareTo(object incomingobject)
        {
            MonsterGroup incominggroup = incomingobject as MonsterGroup;

            return this.Name.CompareTo(incominggroup.Name);
        }
    }

    public class Guardian : Card
    {
        public string Name { set; get; }
        public List<GLevel> Levels { set; get; }
        public string Type { get; set; }
        public int CardLevel { get; set; }
        public int BaseLevel { get; set; }

        public Guardian()
        {
            Levels = new List<GLevel>();
            Type = "Guardian";
            CardLevel = 4;
            BaseLevel = 4;
        }

        public Guardian(string name, int cardlevel)
        {
            Name = name;
            Type = "Guardian";
            CardLevel = cardlevel;
            BaseLevel= cardlevel;
        }
          

        

        public GLevel GetGLevel(int level)
        {
            foreach (GLevel l in Levels)
            {
                if (l.Level.Equals(level.ToString()))
                {
                    return l;
                }
            }


            return null;
        }
        public int CompareTo(object incomingobject)
        {
            Card incomingcard = incomingobject as Card;

            return this.Name.CompareTo(incomingcard.Name);
        }
    }

    public class GLevel
    {
        public string HP { set; get; }
        public string Armour { set; get; }
        public string Armour_Type { set; get; }
        public string Wounds { set; get; }
        public string Wound_Type { set; get; }
        public string Exp { set; get; }
        public string Reward { set; get; }
        public string Level { set; get; }
        public List<string> Traits { set; get; }
        public string Ability { get; set; }
        public string Image { set; get; }

    }

    public class PersonalQuest : Card
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public string Reward { get; set; }
        public string Type { set; get; }
        public int CardLevel { set; get; }
        public int BaseLevel { set; get; }
        public string Image { get; set; }

        public PersonalQuest()
        {
            Type = "PersonalQuest";
            CardLevel = -1;
            BaseLevel = -1;
        }
        public int CompareTo(object incomingobject)
        {
            Card incomingcard = incomingobject as Card;

            return this.Name.CompareTo(incomingcard.Name);
        }
    }

    public class Guild : Card
    {
        public string Name { set; get; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int CardLevel { get; set; }
        public int BaseLevel { get; set; }
        public string Image { get; set; }

        public Guild()
        {
            Type = "Guild";
            CardLevel = -1;
            BaseLevel = -1;
        }
        public int CompareTo(object incomingobject)
        {
            Card incomingcard = incomingobject as Card;

            return this.Name.CompareTo(incomingcard.Name);
        }
    }

    public class Treasure : Card
    {
        public string Name { set; get; }
        public string Type { get; set; }
        public int CardLevel { get; set; }
        public int BaseLevel { get; set; }
        public List<string> Traits { get; set; }
        public string Image { get; set; }

        public Treasure()
        {
            Type = "Treasure";
            CardLevel = -1;
            BaseLevel = -1;
        }
        public int CompareTo(object incomingobject)
        {
            Card incomingcard = incomingobject as Card;

            return this.Name.CompareTo(incomingcard.Name);
        }

    }
    public class Legendary : Card
    {
        public string Name { set; get; }
        public string Type { get; set; }
        public int CardLevel { get; set; }
        public int BaseLevel { get; set; }
        public List<string> Traits { get; set; }
        public string Image { get; set; }

        public Legendary()
        {
            Type = "Treasure";
            CardLevel = -1;
            BaseLevel = -1;
        }
        public int CompareTo(object incomingobject)
        {
            Card incomingcard = incomingobject as Card;

            return this.Name.CompareTo(incomingcard.Name);
        }

    }

}
