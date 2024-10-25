using System.Collections.Generic;
using UnityEngine;
/// <summary> ����� ���������� �� ���������� ������� �������� �� ������ (���� �� �� ����� ���������) .</summary>
///<remarks> ��������� �����. �������� �� 1 ������ �����, ���������� �� ������ ������ .</remarks>
public class DeactivateObjectsOnStart : MonoBehaviour
{
    [SerializeField] List<GameObject> ObjectsToDeactivate;
    void Update()
    {
        if (AllActivated()) { DeactivateAll(); this.gameObject.SetActive(false); }
    }

    /// <summary>����� ��� ����������� �������� .</summary>
    public void DeactivateAll()
    {
        foreach (var item in ObjectsToDeactivate)
        {
            item.SetActive(false);
        }
    }

    /// <summary>Bool , ���������� ��������: ������������ �� ��� �������/������������ �� ��� .</summary>
    bool AllActivated()
    {
        foreach (var item in ObjectsToDeactivate)
        {
            if (item.activeSelf == false) { return false; };
        }
        return true;
    }
}
