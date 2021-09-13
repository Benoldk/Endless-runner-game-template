using game.package.gameplay.services;
using UnityEngine;

namespace game.package.gameplay.infinitetrail
{
    public class ExitTailCollider : MonoBehaviour
    {
        [SerializeField] private Trail trail;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.CompareTo("Player") == 0)
            {
                GameplayManager.instance.DestroyRoad(trail.index - 1);
            }
        }
    }
}