using FlavorfulStory.Saving;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlavorfulStory.SceneManagement
{
    public class SavingWrapper : MonoBehaviour
    {
        /// <summary> Первая загружаемая сцена после главного меню.</summary>
        [SerializeField] private SceneType _firstUploadedScene;

        private const string CurrentSaveKey = "currentSaveName";

        /// <summary> Продолжить игру.</summary>
        /// <remarks> Вызывается из главного меню.</remarks>
        public void ContinueGame()
        {
            if (!PlayerPrefs.HasKey(CurrentSaveKey) ||
                !SavingSystem.SaveFileExists(GetCurrentSave()))
                return;

            StartCoroutine(LoadLastScene());
        }

        /// <summary> Начать новую игру.</summary>
        /// <param name="saveFile"> Название файла сохранения.</param>
        public void StartNewGame(string saveFile)
        {
            if (string.IsNullOrEmpty(saveFile)) return;

            SetCurrentSave(saveFile);
            StartCoroutine(LoadFirstScene());
        }

        /// <summary> Установить текущее сохранение.</summary>
        /// <param name="saveFile"> Название файла сохранения.</param>
        private static void SetCurrentSave(string saveFile)
        {
            PlayerPrefs.SetString(CurrentSaveKey, saveFile);
        }

        /// <summary> Получить текущее сохранение.</summary>
        /// <returns> Возвращает название текущего сохранения.</returns>
        private static string GetCurrentSave() => PlayerPrefs.GetString(CurrentSaveKey);

        /// <summary> Загрузить первую сцену.</summary>
        /// <returns> Возвращает корутину, которая запускает первую сцену.</returns>
        public IEnumerator LoadFirstScene()
        {
            yield return SceneManager.LoadSceneAsync(_firstUploadedScene.ToString());
        }

        /// <summary> Загрузить последнюю сцену.</summary>
        /// <returns> Возвращает корутину, которая запускает послендюю сцену при сохранении.</returns>
        public static IEnumerator LoadLastScene()
        {
            yield return SavingSystem.LoadLastScene(GetCurrentSave());
            //Fader.Instance.FadeOutImmediate();
            //yield return Fader.Instance.FadeIn(Fader.FadeInTime);
        }

        #region Debug
#if UNITY_EDITOR
        [SerializeField] private KeyCode _saveKey;
        [SerializeField] private KeyCode _loadKey;
        [SerializeField] private KeyCode _deleteKey;

        private void Update()
        {
            if (Input.GetKeyDown(_saveKey)) Save();
            if (Input.GetKeyDown(_loadKey)) Load();
            if (Input.GetKeyDown(_deleteKey)) Delete();
        }

        /// <summary> Загрузка данных игры из файла.</summary>
        public static void Load() => SavingSystem.Load(GetCurrentSave());

        /// <summary> Сохранение данных игры в файл.</summary>
        public static void Save() => SavingSystem.Save(GetCurrentSave());

        /// <summary> Удаление сохранения данных игры.</summary>
        public static void Delete() => SavingSystem.Delete(GetCurrentSave());
#endif
        #endregion
    }
}