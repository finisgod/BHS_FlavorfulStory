using UnityEngine;

//Not Used yet
public class PlayerGlobalColliders : MonoBehaviour //��� ���������� ��������������. ����� ������ �������� � OnTriggerEnter / Stay
{
    [SerializeField] ToolCollider m_ToolCollider;
    protected ToolCollider OwnToolCollider { get { return m_ToolCollider; } }
}