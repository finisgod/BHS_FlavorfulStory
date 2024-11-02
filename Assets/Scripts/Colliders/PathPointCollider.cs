using UnityEngine;
/// <summary>����� ����������� ������ ���������� � ����� ��������.</summary>
///<remarks> �������� ��������������, ��� ��������� ����� "�����������" .</remarks>
public class PathPointCollider : MonoBehaviour //��� ���������� ��������������. ����� ������ �������� � OnTriggerEnter / Stay
{
    /// <summary>PathPoint �� ������� ����� ���������.</summary>
    PathPoint PathPoint;

    /// <summary>����� ������������ ��� ������ �������.</summary>
    public void Start()
    {
        PathPoint = GetComponent<PathPoint>(); 
    }

    /// <summary>����� ������������ ��� ����� � ��������� ������� �� ������� ���� ������ ����� .</summary>
    /// <param name="other"> ��������� ��������� �������.</param>
    private void OnTriggerEnter(Collider other) //ToDo: �������� ��� �������� ��� � 1 ����������
    {
        if (other.gameObject.tag == "Npc")
        {
            Npc npc = other.gameObject.GetComponent<Npc>();
            PathPoint.SetAcheved(npc.Name); //ToDo: �������� �� null
        }
    }

    /// <summary>����� ������������ ��� ���������� � ���������� ������� �� ������� ���� ������ ����� .</summary>
    /// <param name="other"> ��������� ��������� �������.</param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Npc")
        {
            Npc npc = other.gameObject.GetComponent<Npc>();
            PathPoint.SetAcheved(npc.Name); //ToDo: �������� �� null
        }
    }
    
}