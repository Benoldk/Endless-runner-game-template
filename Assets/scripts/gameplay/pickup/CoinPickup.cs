using game.package.gameplay.services;
using UnityEngine;

namespace game.package.gameplay
{
    public class CoinPickup : CollidableGameObject, IGamePickup
    {
        public int value;

        public override void HandleCollision(Rigidbody rigidbod)
        {
            if(rigidbod.tag.CompareTo("Player") == 0)
            {
                Apply();
                gameObject.SetActive(false);
            }
        }

        public void Apply()
        {
            GameEvents.OnUIAddToCurrency?.Invoke(value);
        }
    }
}