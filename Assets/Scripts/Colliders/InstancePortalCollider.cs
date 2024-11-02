using NPC;
using System.Collections;
using UnityEngine;
/// <summary> �����, ����������� ������ ������ ��������.</summary>
public class InstancePortalCollider : MonoBehaviour //��� ���������� ��������������. ����� ������ �������� � OnTriggerEnter / Stay
{
    /// <summary> ����� ������������. </summary>
    [SerializeField] NPC.NpcPathPoint destination;
    /// <summary> ������ ������������ ������.</summary>
    //[SerializeField] GameObject loadingScreen;
    /// <summary> ���� ���������� ������������.</summary>
    public bool isTeleporting = false;

    /// <summary> ��������, ������������ ����� ������������.</summary>
    public NPC.NpcPathPoint Destination
    {
        get { return destination; }
    }

    /// <summary>����� ������������ ��� ���������� � ���������� ������� �� ������� ���� ������ ����� .</summary>
    /// <param name="other"> ��������� ��������� �������.</param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!isTeleporting)
            {
                if (destination != this.GetComponent<NpcPathPoint>())
                {
                    //StartCoroutine(LoadScreen());
                    destination.GetComponentInChildren<InstancePortalCollider>().isTeleporting = true;
                    other.GetComponentInChildren<Rigidbody>().MovePosition(destination.Coordinate);
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
            isTeleporting = false;
        }
    }

    /*
    /// <summary> �����-�������� ��� ��������� ������������ ������.</summary>
    IEnumerator LoadScreen()
    {
        float Duration = 2;
        float LoadScreenTimer = 0;
        loadingScreen.SetActive(true);
        while (LoadScreenTimer < Duration)
        {
            //Debug.Log("CORUTINE STARTED");
            LoadScreenTimer++;
            yield return new WaitForSeconds(1f);
        }
        //Debug.Log("CORUTINE ENDED");
        loadingScreen.SetActive(false);
    }
    */
}