using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonsHandler : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _settingsMenu;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowSettingsMenu()
    {
        _mainMenu.SetActive(false);
        _settingsMenu.SetActive(true);
    }

    public void Quit() => Application.Quit();
}
