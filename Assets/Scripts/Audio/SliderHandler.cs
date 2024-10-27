using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Класс, считывающий значение слайдера.
/// </summary>
[RequireComponent(typeof(Slider))]
public class SliderHandler : MonoBehaviour
{
    /// <summary> Название канала в микшере.</summary>
    [SerializeField] private string _name;
    /// <summary> Ссылка на слайдер.</summary>
    private Slider _slider;
    /// <summary>Получение компонента Слайдер</summary>
    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }
    /// <summary>Назначение действия на слайдер, при измененении его значения.</summary>
    private void Start()
    {
        _slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    /// <summary> Метод, вызываемый при изменении значения слайдера.</summary>
    private void ValueChangeCheck()
    {
        AudioManager.Instance.SetMixerValue(_name, _slider.value);
    }
}