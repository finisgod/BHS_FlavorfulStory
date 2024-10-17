using TMPro;
using UnityEngine;

/// <summary> ����� ���������� �� ��������� UI �������� �������.</summary>
public class TimeChanger : MonoBehaviour //������ ����� ������� singleton + �������� � �������� UI (��� ��������)
{
    [SerializeField] TMP_Text textObject;
    public void Update()
    {
        textObject.text = WorldTime.GetCurrentTime().ToString();
    }
}