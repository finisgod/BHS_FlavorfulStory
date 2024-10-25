using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlavorfulStory.Saving
{
    /// <summary> ������� ����������.</summary>
    public class SavingSystem : MonoBehaviour
    {
        #region Public Methods
        /// <summary> �������� ��������� �����.</summary>
        /// <param name="saveFile"> �������� ����� � �����������.</param>
        /// <returns> ��������, ������� ��������� ����������� ��������� �����.</returns>
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

        /// <summary> ���������� ��������� ������� ����� � �������� ����� ����������.</summary>
        /// <param name="saveFile"> �������� �����, ���� ���������� ��������� ������.</param>
        public static void Save(string saveFile)
        {
            Dictionary<string, object> state = LoadFile(saveFile);
            if (state == null) return;

            CaptureState(state);
            SaveFile(saveFile, state);
        }

        /// <summary> �������� �������� ��������� ����� �� ��������� ����� ����������.</summary>
        /// <param name="saveFile"> �������� �����, ������ ���������� ��������� ������.</param>
        public static void Load(string saveFile) => RestoreState(LoadFile(saveFile));

        /// <summary> �������� ����� ����������.</summary>
        /// <param name="saveFile"> �������� �����, ������� ���������� �������.</param>
        public static void Delete(string saveFile) => File.Delete(GetPathFromSaveFile(saveFile));

        /// <summary> ��������� ���� �� ������������ �����.</summary>
        /// <param name="saveFile"> �������� ����� ����������.</param>
        /// <returns> ���������� ���� �� ������������ �����.</returns>
        public static string GetPathFromSaveFile(string saveFile) =>
            Path.Combine(Application.persistentDataPath, saveFile + ".sav");
        #endregion

        #region Private Methods
        /// <summary> �������� ������ �� �����.</summary>
        /// <param name="saveFile"> �������� ����� ����������.</param>
        /// <returns> ���������� ������� �������� � �������.</returns>
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

        /// <summary> ���������� ������ � ����.</summary>
        /// <param name="saveFile"> �������� ����� ����������.</param>
        /// <param name="state"> ���������, ������� ���������� �������� � ����.</param>
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

        /// <summary> �������� ��������� ���� �������� ��� ����������.</summary>
        /// <param name="state"> �������, ���������� ��������� ���� ��������, ������� ���������� �������������.</param>
        private static void CaptureState(Dictionary<string, object> state)
        {
            foreach (SaveableEntity saveable in FindObjectsOfType<SaveableEntity>())
            {
                state[saveable.UniqueIdentifier] = saveable.CaptureState();
            }
            state["lastSceneBuildIndex"] = SceneManager.GetActiveScene().buildIndex;
        }

        /// <summary> �������������� ��������� ���� �������� ��� ��������.</summary>
        /// <param name="state"> �������, ���������� ��������� ���� ��������, ������� ���������� ���������.</param>
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