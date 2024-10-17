using Unity.AI.Navigation;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class RebuildNavMesh : MonoBehaviour
    {
        public void Update()
        {
            NavMeshSurface surface = GetComponent<NavMeshSurface>();
            //surface.UpdateNavMesh(surface.navMeshData);
            //surface.BuildNavMesh();
        }
    }
}
