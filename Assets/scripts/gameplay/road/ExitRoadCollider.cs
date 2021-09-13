using game.package.gameplay.services;
using UnityEngine;

namespace game.package.gameplay
{
    public class ExitRoadCollider : MonoBehaviour
    {
        [SerializeField] private Road road;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.CompareTo("Player") == 0)
            {
                GameplayManager.instance.DestroyRoad(road.index - 1);
            }
        }
    }
}