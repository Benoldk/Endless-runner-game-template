using game.package.gameplay.services;
using UnityEngine;

namespace game.package.gameplay
{
    public class EnterRoadCollider : MonoBehaviour
    {
        [SerializeField] private Road road;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.CompareTo("Player") == 0)
            {
                GameplayManager.instance.CreateRoad(road.index + 1, road.connector.position);
            }
        }
    }
}