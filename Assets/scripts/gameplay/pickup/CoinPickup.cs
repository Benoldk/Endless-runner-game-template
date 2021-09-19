using game.package.gameplay.services;
using game.package.ui;
using UnityEngine;

namespace game.package.gameplay
{
    public class CoinPickup : CollidableGameObject, IGamePickup
    {
        public int value;

        public override void HandleCollision(GameObject _gameObject)
        {
            if(_gameObject.tag.CompareTo("Player") == 0)
            {
                Apply();
                gameObject.SetActive(false);
            }
        }

        public void Apply()
        {
            HUDEvents.OnUIAddToCurrency?.Invoke(value);
        }
    }
}