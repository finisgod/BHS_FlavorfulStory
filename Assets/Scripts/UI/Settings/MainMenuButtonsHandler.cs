using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// �����, ���������� �������� ��� ������ � ������� ����.
/// </summary>
public class MainMenuButtonsHandler : MonoBehaviour
{
    [Header("Menus")]
    /// <summary>������ �� ������ �������� ����.</summary>
    [SerializeField] private GameObject _mainMenu;
    /// <summary>������ �� ������ ���� ��������.</summary>
    [SerializeField] private GameObject _settingsMenu;
    /// <summary>����� ��� �������� �����.</summary>
    public void StartGame() // TODO
    {
        SceneManager.LoadScene(1);
    }
    /// <summary>����� ��� ������� �������� ���� � �������� ���� ��������</summary>
    public void ShowSettingsMenu()
    {
        _mainMenu.SetActive(false);
        _settingsMenu.SetActive(true);
    }
    /// <summary>����� ��� ������ �� ���������</summary>
    public void Quit() => Application.Quit();
}
