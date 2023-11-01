using System;
using System.Collections.Generic;
using System.Text;

namespace TSQDigitalHand
{
    public class TextModeString
    {
        public String CardName;
        public String Type;
        public String CardStrSkill;
        public String CardGoldLight;
        public String CardLevelExp;
        public String CardCost;
        public String CardTraits;
        public String CardAbility;
        public String ImagePath;

        public TextModeString(List<Quest> Cards, Card card, string ImageFolderPath)
        {
            string temp;
            switch (card.Type)
            {
                case "Hero":
                    Hero hero = Cards[0].GetHero(card);
                    Levels currLevel = hero.GetLevel(card.CardLevel);

                    CardName = hero.Name;
                    CardStrSkill = "Str: " + currLevel.Strength + " " + currLevel.Attack_Type[0] + "     " + "WS: " + currLevel.Weapon_Skill;
                    CardGoldLight = "Gold: " + currLevel.Gold + "     " + "Light: " + currLevel.Light;
                    CardLevelExp = "Level: " + currLevel.Level.ToString() + "     " + "Exp: " + currLevel.Exp;
                    CardCost = "Cost: " + currLevel.Cost;
                    temp = "";
                    foreach (string s in currLevel.Traits)
                    {
                        temp += s + "  ";
                    }
                    CardTraits = temp;
                    CardAbility = currLevel.Ability;
                    ImagePath = ImageFolderPath + currLevel.Image;

                    break;
                case "Spell":
                    Spell spell = Cards[0].GetSpell(card);

                    CardName = spell.Name;
                    CardStrSkill = "Str: " + spell.Strength + " " + spell.Attack_Type[0] + "     " + "WS: " + spell.Weapon_Skill;
                    CardGoldLight = "Gold: " + spell.Gold + "     " + "Light: " + spell.Light;
                    CardLevelExp = "Level: n/a" + "     " + "Exp: " + spell.Exp;
                    CardCost = "Cost: " + spell.Cost;
                    temp = "";
                    foreach (string s in spell.Traits)
                    {
                        temp += s + "  ";
                    }
                    CardTraits = temp;
                    CardAbility = spell.Ability;

                    ImagePath = ImageFolderPath + spell.Image;
                    break;
                case "Weapon":
                    Weapon weapon = Cards[0].GetWeapon(card);

                    CardName = weapon.Name;
                    CardStrSkill = "Str: " + weapon.Strength + " " + weapon.Attack_Type[0] + "     " + "WS: " + weapon.Weapon_Skill;
                    CardGoldLight = "Gold: " + weapon.Gold + "     " + "Light: " + weapon.Light;
                    CardLevelExp = "Level: n/a" + "     " + "Exp: " + weapon.Exp;
                    CardCost = "Cost: " + weapon.Cost;
                    temp = "";
                    foreach (string s in weapon.Traits)
                    {
                        temp += s + "  ";
                    }
                    CardTraits = temp;
                    CardAbility = weapon.Ability;

                    ImagePath = ImageFolderPath + weapon.Image;

                    break;
                case "Item":
                    Item item = Cards[0].GetItem(card);

                    CardName = item.Name;
                    CardStrSkill = "Str: " + item.Strength + " " + item.Attack_Type[0] + "     " + "WS: " + item.Weapon_Skill;
                    CardGoldLight = "Gold: " + item.Gold + "     " + "Light: " + item.Light;
                    CardLevelExp = "Level: n/a" + "     " + "Exp: " + item.Exp;
                    CardCost = "Cost: " + item.Cost;
                    temp = "";
                    foreach (string s in item.Traits)
                    {
                        temp += s + "  ";
                    }
                    CardTraits = temp;
                    CardAbility = item.Ability;

                    //Imagepath = item.Image;

                    ImagePath = ImageFolderPath + item.Image;

                    break;
                case "Monster":
                    Monster monster = Cards[0].GetMonster(card);

                    CardName = monster.Name;
                    CardStrSkill = "HP: " + monster.HP + "     " + "Armor: " + monster.Armour + " " + monster.Armour_Type[0];
                    CardGoldLight = "Wounds: " + monster.Wounds + " " + monster.Wound_Type;
                    CardLevelExp = "Level: " + monster.Level + "     " + "Exp: " + monster.Exp;
                    CardCost = "Reward: " + monster.Reward;
                    temp = "";
                    foreach (string s in monster.Traits)
                    {
                        temp += s + "  ";
                    }
                    CardTraits = temp;
                    CardAbility = monster.Ability;

                    ImagePath = ImageFolderPath + monster.Image;
                    break;
                case "Guardian":
                    Guardian guardian = Cards[0].GetGuardian(card);

                    GLevel level = guardian.GetGLevel(card.CardLevel);

                    CardName = guardian.Name;
                    CardStrSkill = "HP: " + level.HP + "     " + "Armor: " + level.Armour + " " + level.Armour_Type[0];
                    CardGoldLight = "Wounds: " + level.Wounds + " " + level.Wound_Type;
                    CardLevelExp = "Level: " + level.Level + "     " + "Exp: " + level.Exp;
                    CardCost = "Reward: " + level.Reward;
                    temp = "";
                    foreach (string s in level.Traits)
                    {
                        temp += s + "  ";
                    }
                    CardTraits = temp;
                    CardAbility = level.Ability;

                    ImagePath = ImageFolderPath + level.Image;
                    break;
                case "MonsterGroup":
                    MonsterGroup group = Cards[0].GetMonsterGroup(card);

                    CardName = group.Name;
                    CardStrSkill = "";
                    CardGoldLight = "";
                    CardLevelExp = "Level: " + group.Level;
                    CardCost = "";
                    temp = "";
                    CardTraits = temp;
                    CardAbility = "";

                    ImagePath = ImageFolderPath + group.Image;

                    break;
                case "PersonalQuest":
                    PersonalQuest pq = Cards[0].GetPersonalQuest(card);

                    CardName = pq.Name;
                    CardStrSkill = pq.Description;
                    CardGoldLight = "Reward\n" + pq.Reward;
                    CardLevelExp = "";
                    CardCost = "";
                    temp = "";
                    CardTraits = temp;
                    CardAbility = "";

                    ImagePath = ImageFolderPath + pq.Image;

                    break;
                case "Guild":
                    Guild g = Cards[0].GetGuild(card);

                    CardName = g.Name;
                    CardStrSkill = g.Description;
                    CardGoldLight = "";
                    CardLevelExp = "";
                    CardCost = "";
                    temp = "";
                    CardTraits = temp;
                    CardAbility = "";

                    ImagePath = ImageFolderPath + g.Image;

                    break;
                case "Treasure":
                    // To Do: Add treasure string here
                    break;
                case "Legendary":
                    // To Do: Add Legendary string Here
                    break;
            }
        }
    }
}
