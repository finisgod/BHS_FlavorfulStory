using System.Collections;
using UnityEngine;
/// <summary> �����, ����������� ������ ������ ��������.</summary>
public class PortalCollider : MonoBehaviour //��� ���������� ��������������. ����� ������ �������� � OnTriggerEnter / Stay
{
    /// <summary> ����� ������������. </summary>
    [SerializeField] PathPoint destination;
    /// <summary> ������ ������������ ������.</summary>
    [SerializeField] GameObject loadingScreen;
    /// <summary> ��������, ������������ ����� ������������.</summary>
    public PathPoint Destination { get { return destination; } }
    /// <summary> Id ������� .</summary>
    public int id = 0;
    /// <summary> ���� ���������� ������������.</summary>
    public bool isTeleporting = false;
    /// <summary> ���� ���������� ������������ NPC.</summary>
    public bool isNpcTeleporting = false;

    /// <summary>����� ������������ ��� ���������� � ���������� ������� �� ������� ���� ������ ����� .</summary>
    /// <param name="other"> ��������� ��������� �������.</param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!isTeleporting)
            {
                if (destination != this.GetComponent<PathPoint>())
                {
                    StartCoroutine(LoadScreen());
                    destination.GetComponentInChildren<PortalCollider>().isTeleporting = true;
                    other.GetComponentInChildren<Rigidbody>().MovePosition(destination.GetPosition());
                }
            }
        }
        if (other.gameObject.tag == "Npc")
        {
            Npc npc = other.GetComponentInChildren<Npc>();
            if (!isNpcTeleporting)
            {
                if (destination != this.GetComponent<PathPoint>())
                {
                    Debug.Log("NPC TELEPORT " + id.ToString());
                    destination.GetComponentInChildren<PortalCollider>().isNpcTeleporting = true;
                    //other.transform.position = destination.GetPosition();
                    npc.MoveByPathPoint(destination);
                }
            }
        }
    }

    /// <summary>����� ������������ ��� ������ �� ���������� ������� �� ������� ���� ������ ����� .</summary>
    /// <param name="other"> ��������� ��������� �������.</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Trigger exit!! id:" +  id.ToString());
            isTeleporting = false;
        }
        if (other.gameObject.tag == "Npc")
        {
            Debug.Log("Trigger npc exit!! id:" + id.ToString());
            isNpcTeleporting = false;
        }
    }
    /// <summary> �����-�������� ��� ��������� ������������ ������.</summary>
    IEnumerator LoadScreen()
    {
        float Duration = 2;
        float LoadScreenTimer = 0;
        loadingScreen.SetActive(true);
        while (LoadScreenTimer < Duration)
        {
            Debug.Log("CORUTINE STARTED");
            LoadScreenTimer++;
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("CORUTINE ENDED");
        loadingScreen.SetActive(false);
    }
}