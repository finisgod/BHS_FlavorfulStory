using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlavorfulStory.UI
{
    /// <summary> Действия кнопок в гламном меню.</summary>
    public class MainMenuButtons : MonoBehaviour
    {
        /// <summary> Начать новую игру.</summary>
        public void OnClickNewGame()
        {
            // HACK: Переделать с названиями сцен
            SceneManager.LoadScene(1);
        }

        /// <summary> Продолжить игру.</summary>
        public void OnClickContinue()
        {
            // TODO
            //SceneManager.LoadScene(1);
        }

        /// <summary> Выйти из игры.</summary>
        public void OnClickQuit() => Application.Quit();
    }
}