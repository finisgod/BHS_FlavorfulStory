using NorskaLib.Spreadsheets;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FlavorfulStory.Stats.TableImport
{
    
    
    [Serializable]
    public class SpreadshetContent
    {
        [SpreadsheetPage("PlayerPage")]
        public List<PlayerData> PlayerData;
        
        [SpreadsheetPage("NpcPage")]
        public List<NpcData> NpcData;
        
        [SpreadsheetPage("ExpToLevelUp")] 
        public List<ExpToLevelUp> ExpToLevelUps;

        [SpreadsheetPage("Hunting")] 
        public List<Activity> HuntingParameters;
        
        [SpreadsheetPage("Collecting")] 
        public List<Activity> CollectingParameters;
        
        [SpreadsheetPage("Fishing")] 
        public List<Activity> FishingParameters;
        
        [SpreadsheetPage("Cultivation")] 
        public List<Activity> CultivationParameters;
        
        [SpreadsheetPage("AnimalFarming")] 
        public List<Activity> AnimalFarmingParameters;
    }

    [CreateAssetMenu(fileName = "SpreadsheetContainer", menuName = "ImportData/SpreadsheetContainer")]
    public class SpreadsheetContainer : SpreadsheetsContainerBase
    {
        [SpreadsheetContent]
        [SerializeField] SpreadshetContent content;
        public SpreadshetContent Content => content;
    }
}
