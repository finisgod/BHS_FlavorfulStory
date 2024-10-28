using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Класс, содержащий действия для кнопок в гламном меню.
/// </summary>
public class MainMenuButtonsHandler : MonoBehaviour
{
    [Header("Menus")]
    /// <summary>Ссылка на объект главного меню.</summary>
    [SerializeField] private GameObject _mainMenu;
    /// <summary>Ссылка на объект меню настроек.</summary>
    [SerializeField] private GameObject _settingsMenu;
    /// <summary>Метод для загрузки сцены.</summary>
    public void StartGame() // TODO
    {
        SceneManager.LoadScene(1);
    }
    /// <summary>Метод для скрытия главного меню и открытия меню настроек</summary>
    public void ShowSettingsMenu()
    {
        _mainMenu.SetActive(false);
        _settingsMenu.SetActive(true);
    }
    /// <summary>Метод для выхода из программы</summary>
    public void Quit() => Application.Quit();
}
