using System;

namespace FlavorfulStory.Stats.TableImport
{
    /// <summary> Характеристики персонажа.</summary>
    [Serializable]
    public class PlayerData
    {
        public string Name;
        public int Health;
        public int Energy;
        public int Mana;
        public int Strength;
    }
    
    /// <summary> Характеристики NPC.</summary>
    [Serializable]
    public class NpcData
    {
        public string Name;
        public int Health;
        public int Strength;
    }
    
    /// <summary> Количество опыта для перехода на новый уровень для каждой актвности.</summary>
    [Serializable]
    public class ExpToLevelUp
    {
        public string Levels;
        public int Collecting;
        public int Forestry;
        public int Mining;
        public int Fighting;
        public int Fishing;
        public int GhostCatching;
        public int CrystalCultivation;
    }
    
    /// <summary> Параметры, которые увеличивают активности.</summary>
    [Serializable]
    public class Activity
    {
        public string ParameterName;
        public int lvl1;
        public int lvl2;
        public int lvl3;
        public int lvl4;
        public int lvl5;
    }
}