using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// �����, ����������� �������� ��������.
/// </summary>
[RequireComponent(typeof(Slider))]
public class SliderHandler : MonoBehaviour
{
    /// <summary> �������� ������ � �������.</summary>
    [SerializeField] private string _name;
    /// <summary> ������ �� �������.</summary>
    private Slider _slider;
    /// <summary>��������� ���������� �������</summary>
    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }
    /// <summary>���������� �������� �� �������, ��� ����������� ��� ��������.</summary>
    private void Start()
    {
        _slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    /// <summary> �����, ���������� ��� ��������� �������� ��������.</summary>
    private void ValueChangeCheck()
    {
        AudioManager.Instance.SetMixerValue(_name, _slider.value);
    }
}