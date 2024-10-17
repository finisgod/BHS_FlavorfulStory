using System.Collections;
using UnityEngine;
/// <summary>Класс описывающий логику анимаций гг.</summary>
public class PlayerAnimationController : MonoBehaviour
{
    /// <summary> Аниматор прикрепленный к модели игрока.</summary>
    [SerializeField] private Animator _animator;
    /// <summary> Rigidbody игрока.</summary>
    [SerializeField] Rigidbody rb;
    /// <summary> Флаг движения игрока.</summary>
    static bool isMoving = false;

    public bool isAnimated = false;

    private void Update() //Подумать, можно ли сделать лучше. Выглядит сомнительно
    {
        if (!isAnimated)
        {
            if (rb.velocity.magnitude > 0)
            {
                // Player is moving.
                if (!isMoving)
                {
                    isMoving = true;
                    _animator.SetTrigger("runTrigger");
                }
            }
            else
            {
                isMoving = false;
                _animator.SetTrigger("idleTrigger");
            }
        }
    }
    public void SetAnimated(bool state)
    {
        isAnimated = state;
    }
    public void SetTrigger(string trigger)
    {
        _animator.SetTrigger(trigger);
    }


    /// <summary>Хендлер для эвента отражающего конец анимации.</summary>
    public delegate void AnimationStartedEvent();
    public event AnimationEndedEvent AnimationStartedEventHandler;
    /// <summary>Хендлер для эвента отражающего открытие инвентаря.</summary>
    public delegate void AnimationEndedEvent();
    public event AnimationEndedEvent AnimationEndedEventHandler;
}
