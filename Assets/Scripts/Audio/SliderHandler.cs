using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderHandler : MonoBehaviour
{
    [SerializeField] private string _name;
    private Slider _slider;
    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Invoked when the value of the slider changes.
    private void ValueChangeCheck()
    {
        AudioManager.Instance.SetMixerValue(_name, _slider.value);
    }
}