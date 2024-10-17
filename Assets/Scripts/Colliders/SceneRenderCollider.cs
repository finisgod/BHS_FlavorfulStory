using UnityEngine;
/// <summary> ����� ����������� ������ ���������� ���������/���������� �������� ��� �������� �� ������ �������.</summary>
public class SceneRendererCollider : MonoBehaviour //����� � ���������� //��� ���������� ��������������. ����� ������ �������� � OnTriggerEnter / Stay
{
    /// <summary> ������ ������ SceneRenderer ���������� � ���� ������ ���������/���������� ��������.</summary>
    [SerializeField] SceneRenderer Renderer;
    /// <summary> ��� �����.</summary>
    [SerializeField] string SceneName = "";

    /// <summary>����� ������������ ��� ���������� � ���������� ������� �� ������� ���� ������ ����� .</summary>
    /// <param name="other"> ��������� ��������� �������.</param>
    private void OnTriggerEnter(Collider other)
    {
        CurrentSceneManager.CurrentScene = SceneName;
        if (other.gameObject.tag == "Player")
        {
            Renderer.SceneRenderOn(SceneName);
        }
    }

    /// <summary>����� ������������ ��� ������ �� ���������� ������� �� ������� ���� ������ ����� .</summary>
    /// <param name="other"> ��������� ��������� �������.</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Renderer.SceneRenderOff(SceneName);
        }
    }
}