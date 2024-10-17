using TMPro;
using UnityEngine;

/// <summary> Класс отвечающий за изменение UI счетчика времени.</summary>
public class TimeChanger : MonoBehaviour //Скорее всего сделать singleton + положить в название UI (для четкости)
{
    [SerializeField] TMP_Text textObject;
    public void Update()
    {
        textObject.text = WorldTime.GetCurrentTime().ToString();
    }
}