using NorskaLib.Spreadsheets;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FlavorfulStory.Stats.TableImport
{
    /// <summary> Спарсенная информации из гугл таблицы.</summary>
    [Serializable]
    public class SpreadshetContent
    {
        /// <summary> Информация о игроке.</summary>
        [SpreadsheetPage("PlayerPage")]
        public List<PlayerData> PlayerData;
        
        /// <summary> Информация о NPC.</summary>
        [SpreadsheetPage("NpcPage")]
        public List<NpcData> NpcData;
        
        /// <summary> Информация об опыте для повышения уровня..</summary>
        [SpreadsheetPage("ExpToLevelUp")] 
        public List<ExpToLevelUp> ExpToLevelUps;
        
        /// <summary> Информация о собирательстве.</summary>
        [SpreadsheetPage("Collecting")] 
        public List<Activity> CollectingParameters;
        
        /// <summary> Информация о лесничестве.</summary>
        [SpreadsheetPage("Forestry")] 
        public List<Activity> ForestryParameters;

        /// <summary> Информация о шахтерстве.</summary>
        [SpreadsheetPage("Mining")] 
        public List<Activity> MiningParameters;
        
        /// <summary> Информация о бое.</summary>
        [SpreadsheetPage("Fighthing")] 
        public List<Activity> FighthingParameters;
        
        /// <summary> Информация о рыбалке.</summary>
        [SpreadsheetPage("Fishing")] 
        public List<Activity> FishingParameters;
        
        /// <summary> Информация о ловле призраков.</summary>
        [SpreadsheetPage("GhostCatching")] 
        public List<Activity> GhostCatchingParameters;

        /// <summary> Информация о выращивании кристаллов.</summary>
        [SpreadsheetPage("СrystalСultivation")] 
        public List<Activity> СrystalСultivationParameters;
    }

    /// <summary> Парсинг информации из гугл таблиц.</summary>
    [CreateAssetMenu(fileName = "SpreadsheetContainer", menuName = "ImportData/SpreadsheetContainer")]
    public class SpreadsheetContainer : SpreadsheetsContainerBase
    {
        [SpreadsheetContent]
        [SerializeField] SpreadshetContent content;
        public SpreadshetContent Content => content;
    }
}
