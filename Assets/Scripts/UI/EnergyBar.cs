using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.EventSystems.EventTrigger;
/// <summary> Класс-стартер сцены для верного порядка инициализаций (на будущее).</summary>
public class EnergyBar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]TMP_Text textObject;
    [SerializeField] Player player;
    void Start()
    {   
        SetEnergy(player.Energy);
        player.OnChangeEnergy += OnEnergyChanged;
        textObject.gameObject.SetActive(false);
    }
    void SetEnergy(int energy)
    {
        textObject.text = energy.ToString();
    }
    private void OnEnergyChanged(int energy)
    {
        SetEnergy(energy);
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