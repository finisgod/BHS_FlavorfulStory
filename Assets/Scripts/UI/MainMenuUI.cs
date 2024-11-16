using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlavorfulStory.UI
{
    /// <summary> UI главного меню.</summary>
    public class MainMenuUI : MonoBehaviour
    {
        /// <summary> Начать новую игру.</summary>
        public void OnClickNewGame()
        {
            // HACK: Переделать с названиями сцен
            SceneManager.LoadScene(1);
        }

        /// <summary> Продолжить игру.</summary>
        public void OnClickContinue() => 
            PersistentObject.Instance.GetSavingWrapper().ContinueGame();

        /// <summary> Выйти из игры.</summary>
        public void OnClickQuit() => Application.Quit();
    }
}