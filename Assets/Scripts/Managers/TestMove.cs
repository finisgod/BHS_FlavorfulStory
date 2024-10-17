using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class TestMove : MonoBehaviour
    {
        private Vector3 offset = Vector3.zero;
        public bool forward = true;
        public void FixedUpdate()
        {
            if (forward)
            {
                offset += new Vector3(0.01f, 0.01f, 0);
                this.gameObject.transform.position += new Vector3(0.01f, 0.01f, 0);               
            }
            else
            {
                offset -= new Vector3(0.01f, 0.01f, 0);
                this.gameObject.transform.position -= new Vector3(0.01f, 0.01f, 0);
            }
        }
    }
}
