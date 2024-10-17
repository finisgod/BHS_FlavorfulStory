using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary> Класс-стартер сцены для верного порядка инициализаций (на будущее).</summary>
public class HealthBar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]TMP_Text textObject;
    [SerializeField] Player player;
    Image HealthImage;
    void Start()
    {
        SetHealth(player.Health);
        player.OnChangeHealth += OnHealthChanged;
        textObject.gameObject.SetActive(false);
    }
    void SetHealth(int health)
    {
        textObject.text = health.ToString();
    }
    private void OnHealthChanged(int health)
    {
        SetHealth(health);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        textObject.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textObject.gameObject.SetActive(false);
    }
}