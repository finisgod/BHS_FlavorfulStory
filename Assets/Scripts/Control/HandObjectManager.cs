using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace FlavorfulStory.Control
{
    public class HandObjectManager : MonoBehaviour
    {
        [SerializeField] public GameObject container;
        [SerializeField] public GameObject leftHand;
        [SerializeField] public GameObject rightHand;
        [SerializeField] public InventoryManagerUI playerInventoryEventManager;

        private GameObject spawnedHandObject;

        public void Start()
        {
            playerInventoryEventManager.ItemSelectedChangedEvent += PutToHand;
        }
        public void PutToHand(Item item)
        {
            if (spawnedHandObject != null)
            {
                Destroy(spawnedHandObject);
            }
            spawnedHandObject = Instantiate(Resources.Load("Prefabs/GameObjects/Object/" + item.Name + "ObjectHand"), container.transform).GameObject();
        }
        public void Update()
        {
            if (spawnedHandObject != null)
            {
                HandObject obj = spawnedHandObject.GetComponent<HandObject>();
                if (obj != null)
                {
                    if (!obj._isTwoHand)
                    {
                        spawnedHandObject.transform.position = rightHand.transform.position;
                    }
                    else
                    {
                        spawnedHandObject.transform.position = leftHand.transform.position;
                        Vector3 normal = rightHand.transform.position - leftHand.transform.position;
                        spawnedHandObject.transform.forward = normal;
                    }
                }
            }
        }
    }
}