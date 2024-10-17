using System.Collections;
using UnityEngine;
/// <summary>����� ����������� ������ �������� ��.</summary>
public class PlayerAnimationController : MonoBehaviour
{
    /// <summary> �������� ������������� � ������ ������.</summary>
    [SerializeField] private Animator _animator;
    /// <summary> Rigidbody ������.</summary>
    [SerializeField] Rigidbody rb;
    /// <summary> ���� �������� ������.</summary>
    static bool isMoving = false;

    public bool isAnimated = false;

    private void Update() //��������, ����� �� ������� �����. �������� �����������
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


    /// <summary>������� ��� ������ ����������� ����� ��������.</summary>
    public delegate void AnimationStartedEvent();
    public event AnimationEndedEvent AnimationStartedEventHandler;
    /// <summary>������� ��� ������ ����������� �������� ���������.</summary>
    public delegate void AnimationEndedEvent();
    public event AnimationEndedEvent AnimationEndedEventHandler;
}
