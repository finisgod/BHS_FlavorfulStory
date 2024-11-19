using TMPro;
using UnityEngine;

namespace FlavorfulStory.UI.Bars
{
    public class BaseBar : MonoBehaviour
    {
        /// <summary> Объект текста.</summary>
        [SerializeField] protected TMP_Text _textObject;
        
        /// <summary> Объект игрока.</summary>
        protected GameObject Player;

        /// <summary> Установка текстового значения.</summary>
        /// <param name="value"> Текущее значение энергии.</param>
        protected void SetBarText(int value)
        {
            _textObject.text = value.ToString();
        }
    }
}
