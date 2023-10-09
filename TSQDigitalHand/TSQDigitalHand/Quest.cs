using System;
using System.Collections.Generic;
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

        public Quest()
        {
            Heroes = new List<Hero>();
            Spells = new List<Spell>();
            Weapons = new List<Weapon>();
            Items = new List<Item>();
            Monsters = new List<Monster>();
            Guardians = new List<Guardian>();
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
    }
    
    public interface Card
    {
        string Name { get; set; }
        string Type { get; set; }
    }

    public class Hero : Card
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<Levels> Levels { get; set; }

        public Hero()
        {
            Levels = new List<Levels>();
            Type = "Hero";
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

        public Spell()
        {
            Type = "Spell";
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

        public Item()
        {
            Type = "Item";
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

        public Weapon()
        {
            Type = "Weapon";
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

        public Monster()
        {
            Type = "Monster";
        }
    }

    public class Guardian : Card
    {
        public string Name { set; get; }
        public List<GLevel> Levels { set; get; }
        public string Type { get; set; }
        public Guardian()
        {
            Levels = new List<GLevel>();
            Type = "Guardian";
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

}
