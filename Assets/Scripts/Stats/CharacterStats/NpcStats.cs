using FlavorfulStory.Stats.TableImport;
using UnityEngine;

namespace FlavorfulStory.Stats.CharacterStats
{
    /// <summary> Менеджер статов персонажа.</summary>
    public class NpcStats : MonoBehaviour
    {
        /// <summary> Имя NPC.</summary>
        [SerializeField] private string _name;
        
        /// <summary> Информация из гугл таблицы.</summary>
        [SerializeField] private SpreadsheetContainer _data;
        
        /// <summary> Компонент здоровья.</summary>
        private Health _healthComponent;
        
        /// <summary> Компонент силы.</summary>
        private Strength _strengthComponent;

        /// <summary> Получение компонентов.</summary>
        private void Awake()
        {
            _healthComponent = GetComponent<Health>();
            _strengthComponent = GetComponent<Strength>();
        }

        /// <summary> Установка значений для НПС.</summary>
        private void Start()
        {
            SetStats();
        }

        /// <summary> Установка статов для персонажа.</summary>
        private void SetStats()
        {
            foreach (var data in _data.Content.NpcData)
            {
                if (data.Name == _name)
                {
                    _healthComponent.MaxValue = data.Health;
                    _strengthComponent.CurrentStrength = data.Strength;
                    break;
                }
            }
        }
    }
}