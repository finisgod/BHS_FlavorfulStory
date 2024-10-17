using UnityEngine;

public class TwoHandObject : MonoBehaviour
{
    [SerializeField] GameObject rightHand;
    [SerializeField] GameObject leftHand;

    private void Update()
    {
        this.gameObject.transform.position = leftHand.transform.position;
        Vector3 normal = rightHand.transform.position - leftHand.transform.position;
        this.transform.forward = normal.normalized;
    }

}