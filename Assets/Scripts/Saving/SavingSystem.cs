﻿using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlavorfulStory.Saving
{
    /// <summary> Система сохранений.</summary>
    public class SavingSystem : MonoBehaviour
    {
        #region Public Methods
        /// <summary> Загрузка последней сцены.</summary>
        /// <param name="saveFile"> Название файла с сохранением.</param>
        /// <returns> Корутина, которая запускает асинхронную подгрузку сцены.</returns>
        public static System.Collections.IEnumerator LoadLastScene(string saveFile)
        {
            Dictionary<string, object> state = LoadFile(saveFile);
            if (state == null) yield break;

            int buildIndex = SceneManager.GetActiveScene().buildIndex;
            if (state.ContainsKey("lastSceneBuildIndex"))
            {
                buildIndex = (int)state["lastSceneBuildIndex"];
            }
            yield return SceneManager.LoadSceneAsync(buildIndex);
            RestoreState(state);
        }

        /// <summary> Сохранение состояния текущей сцены в заданном файле сохранения.</summary>
        /// <param name="saveFile"> Название файла, куда необходимо сохранить данные.</param>
        public static void Save(string saveFile)
        {
            Dictionary<string, object> state = LoadFile(saveFile);
            if (state == null) return;

            CaptureState(state);
            SaveFile(saveFile, state);
        }

        /// <summary> Загрузка текущего состояния сцены из заданного файла сохранения.</summary>
        /// <param name="saveFile"> Название файла, откуда необходимо загружать данные.</param>
        public static void Load(string saveFile) => RestoreState(LoadFile(saveFile));

        /// <summary> Удаление файла сохранения.</summary>
        /// <param name="saveFile"> Название файла, который необходимо удалить.</param>
        public static void Delete(string saveFile) => File.Delete(GetPathFromSaveFile(saveFile));

        /// <summary> Получение пути до сохраненного файла.</summary>
        /// <param name="saveFile"> Название файла сохранения.</param>
        /// <returns> Возвращает путь до сохраненного файла.</returns>
        public static string GetPathFromSaveFile(string saveFile) =>
            Path.Combine(Application.persistentDataPath, saveFile + ".sav");
        #endregion

        #region Private Methods
        /// <summary> Загрузка данных из файла.</summary>
        /// <param name="saveFile"> Название файла сохранения.</param>
        /// <returns> Возвращает словарь названия и объекта.</returns>
        private static Dictionary<string, object> LoadFile(string saveFile)
        {
            string path = GetPathFromSaveFile(saveFile);
            if (!File.Exists(path)) return new Dictionary<string, object>();

            using (FileStream stream = File.Open(path, FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                return formatter.Deserialize(stream) as Dictionary<string, object>;
            }
        }

        /// <summary> Сохранение данных в файл.</summary>
        /// <param name="saveFile"> Название файла сохранения.</param>
        /// <param name="state"> Состояние, которое необходимо записать в файл.</param>
        private static void SaveFile(string saveFile, object state)
        {
            string path = GetPathFromSaveFile(saveFile);
            print("Saving to " + path);
            using (FileStream stream = File.Open(path, FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, state);
            }
        }

        /// <summary> Фиксация состояний всех объектов при сохранении.</summary>
        /// <param name="state"> Словарь, содержащий состояния всех объектов, которые необходимо зафиксировать.</param>
        private static void CaptureState(Dictionary<string, object> state)
        {
            foreach (SaveableEntity saveable in FindObjectsOfType<SaveableEntity>())
            {
                state[saveable.UniqueIdentifier] = saveable.CaptureState();
            }
            state["lastSceneBuildIndex"] = SceneManager.GetActiveScene().buildIndex;
        }

        /// <summary> Восстановление состояний всех объектов при загрузке.</summary>
        /// <param name="state"> Словарь, содержащий состояния всех объектов, которые необходимо загрузить.</param>
        private static void RestoreState(Dictionary<string, object> state)
        {
            if (state == null) return;

            foreach (SaveableEntity saveable in FindObjectsOfType<SaveableEntity>())
            {
                string id = saveable.UniqueIdentifier;
                if (state.ContainsKey(id)) saveable.RestoreState(state[id]);
            }
        }
        #endregion
    }
}