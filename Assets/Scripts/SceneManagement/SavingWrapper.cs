using FlavorfulStory.Saving;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlavorfulStory.SceneManagement
{
    public class SavingWrapper : MonoBehaviour
    {
        public const string DefaultSaveFile = "Save";

        private void Awake()
        {
            if (SceneManager.GetActiveScene().buildIndex == 0) return;
            StartCoroutine(LoadLastScene());
        }

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
        /// <returns> Возвращает True - если файл сохранения существует,
        /// False - в противном случае.</returns>
        public static bool SaveFileExist() =>
            System.IO.File.Exists(SavingSystem.GetPathFromSaveFile(DefaultSaveFile));

#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L)) Load();

            if (Input.GetKeyDown(KeyCode.K)) Save();

            if (Input.GetKeyDown(KeyCode.Delete)) Delete();
        }
#endif
    }
}