using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary> Класс, описывающий логику смены сцены при вхождении в коллайдер, прикрепленный к объекту.</summary>
/// <remarks>Вешается на порталы / триггеры, которые при заходе в них должны сменить сцену .</remarks>
public class ChangeSceneCollider : MonoBehaviour //все коллайдеры оптимизировать. Много лишних действий в OnTriggerEnter / Stay
{
    /// <summary> Название сцены на которую нужно переключиться.</summary>
    [SerializeField] string sceneName;
    /// <summary> Префаб загрузочного экрана.</summary>
    [SerializeField] GameObject loadingScreen;

    /// <summary>Метод вызывающийся при нахождении в коллайдере объекта на котором этот скрипт висит .</summary>
    /// <param name="other"> Коллайдер входящего объекта.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            loadingScreen.SetActive(true);

            string currSceneName = SceneManager.GetActiveScene().name;
            PositionManager.SavePlayerPosition(currSceneName, other.gameObject.transform.position);

            SceneManager.LoadScene(sceneName);
        }
    }

}
