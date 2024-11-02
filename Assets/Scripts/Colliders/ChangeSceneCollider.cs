using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary> �����, ����������� ������ ����� ����� ��� ��������� � ���������, ������������� � �������.</summary>
/// <remarks>�������� �� ������� / ��������, ������� ��� ������ � ��� ������ ������� ����� .</remarks>
public class ChangeSceneCollider : MonoBehaviour //��� ���������� ��������������. ����� ������ �������� � OnTriggerEnter / Stay
{
    /// <summary> �������� ����� �� ������� ����� �������������.</summary>
    [SerializeField] string sceneName;
    /// <summary> ������ ������������ ������.</summary>
    [SerializeField] GameObject loadingScreen;

    /// <summary>����� ������������ ��� ���������� � ���������� ������� �� ������� ���� ������ ����� .</summary>
    /// <param name="other"> ��������� ��������� �������.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            loadingScreen.SetActive(true);

            string currSceneName = SceneManager.GetActiveScene().name;
            PositionManager.SavePlayerPosition(currSceneName, other.gameObject.transform.position);

            SceneManager.LoadScene(sceneName);
        }
    }

}
