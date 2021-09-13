using game.package.gameplay.services;
using UnityEngine;

namespace game.package.gameplay.infinitetrail
{
    public class EnterTrailCollider : MonoBehaviour
    {
        [SerializeField] private Trail trail;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.CompareTo("Player") == 0)
            {
                GameplayManager.instance.CreateRoad(trail.index + 1, trail.connector.position);
            }
        }
    }
}