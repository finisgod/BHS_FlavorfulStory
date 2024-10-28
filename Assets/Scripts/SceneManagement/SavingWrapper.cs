using FlavorfulStory.Saving;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlavorfulStory.SceneManagement
{
    public class SavingWrapper : MonoBehaviour
    {
        [SerializeField] private KeyCode _saveKey;
        [SerializeField] private KeyCode _loadKey;
        [SerializeField] private KeyCode _deleteKey;

        private const string DefaultSaveFile = "Save";

        /// <summary> Является ли текущая сцена главным меню?</summary>
        /// <returns> Возвращает True - если текущая сцена - главное меню, False - в противном случае.</returns>
        private static bool IsCurrentSceneMainMenu() => SceneManager.GetActiveScene().buildIndex == 0;

        /// <summary> Запускаем последнюю сцену, если не находимся в главном меню.</summary>
        private void Awake()
        {
            if (IsCurrentSceneMainMenu()) return;
            StartCoroutine(LoadLastScene());
        }

        /// <summary> Загрузка последней сцены.</summary>
        /// <returns> Возвращает корутину последней сцены.</returns>
        public static IEnumerator LoadLastScene()
        {
            yield return SavingSystem.LoadLastScene(DefaultSaveFile);
            //Fader.Instance.FadeOutImmediate();
            //yield return Fader.Instance.FadeIn(Fader.FadeInTime);
        }

        /// <summary> Загрузка данных игры из файла.</summary>
        public static void Load() => SavingSystem.Load(DefaultSaveFile);
        
        /// <summary> Сохранение данных игры в файл.</summary>
        public static void Save() => SavingSystem.Save(DefaultSaveFile);

        /// <summary> Удаление сохранения данных игры.</summary>
        public static void Delete() => SavingSystem.Delete(DefaultSaveFile);

        /// <summary> Существует ли сохраненный файл?</summary>
        /// <returns> Возвращает True - если файл сохранения существует, False - в противном случае.</returns>
        public static bool SaveFileExist() =>
            System.IO.File.Exists(SavingSystem.GetPathFromSaveFile(DefaultSaveFile));

#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(_saveKey)) Save();
            if (Input.GetKeyDown(_loadKey)) Load();
            if (Input.GetKeyDown(_deleteKey)) Delete();
        }
#endif
    }
}