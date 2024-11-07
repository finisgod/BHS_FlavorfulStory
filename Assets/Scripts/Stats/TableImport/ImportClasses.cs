using System;
using UnityEngine.Serialization;

namespace FlavorfulStory.Stats.TableImport
{
    [Serializable]
    public class PlayerData
    {
        public string Name;
        public int Health;
        public int Energy;
        public int Mana;
        public int Strength;
    }
    
    [Serializable]
    public class NpcData
    {
        public string Name;
        public int Health;
        public int Strength;
    }
    
    [Serializable]
    public class ExpToLevelUp
    {
        public string Name;
        public int Level_0_1;
        public int Level_1_2;
        public int Level_2_3;
        public int Level_3_4;
        public int Level_4_5;
    }
    
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