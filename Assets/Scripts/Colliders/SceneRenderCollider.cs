using UnityEngine;
/// <summary> Класс описывающий логику коллайдера включения/отключения объектов при переходе на другой инстанс.</summary>
public class SceneRendererCollider : MonoBehaviour //Класс в разработке //все коллайдеры оптимизировать. Много лишних действий в OnTriggerEnter / Stay
{
    /// <summary> Объект класса SceneRenderer содержащий в себе методы включения/отключения объектов.</summary>
    [SerializeField] SceneRenderer Renderer;
    /// <summary> Имя сцены.</summary>
    [SerializeField] string SceneName = "";

    /// <summary>Метод вызывающийся при нахождении в коллайдере объекта на котором этот скрипт висит .</summary>
    /// <param name="other"> Коллайдер входящего объекта.</param>
    private void OnTriggerEnter(Collider other)
    {
        CurrentSceneManager.CurrentScene = SceneName;
        if (other.gameObject.tag == "Player")
        {
            Renderer.SceneRenderOn(SceneName);
        }
    }

    /// <summary>Метод вызывающийся при выходе из коллайдера объекта на котором этот скрипт висит .</summary>
    /// <param name="other"> Коллайдер входящего объекта.</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Renderer.SceneRenderOff(SceneName);
        }
    }
}