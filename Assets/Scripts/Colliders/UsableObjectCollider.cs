using UnityEngine;
/// <summary>����� ����������� ��������� ��� �������������� � ������������� ��������.</summary>
public class UsableObjectCollider : MonoBehaviour //��� ���������� ��������������. ����� ������ �������� � OnTriggerEnter / Stay
{
    /// <summary>����� ������������ ��� ���������� � ���������� ������� �� ������� ���� ������ ����� .</summary>
    /// <param name="other"> ��������� ��������� �������.</param>
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Stating");
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("IsPlayer");
            if (Input.GetKeyDown((KeyCode)UserKeys.UseObject))
            {
                IUsableObject obj = this.gameObject.GetComponent<IUsableObject>();
                obj.Use();
                //Debug.Log(obj != null);
            }
        }
    }
}