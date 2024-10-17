using Assets.Scripts.Items.Instruments;
using UnityEngine;

/// <summary> Базовый класс для подбираемого объекта (дропа).</summary>
public class Drop : PickableObject
{
    public Drop(string name) : base(name) { }
    /// <summary> Метод для подбора объекта и преобразования его в Item.</summary>
    public new Item PickAndDestroy()
    {
        Destroy(this.gameObject);
        return GetComponentInParent<ItemObjectFactory>().ProduceItem(this);
    }

    //RotationAnimation
    public void Update()
    {
        this.gameObject.transform.Rotate(0, 10 * Time.deltaTime, 0);
    }
}