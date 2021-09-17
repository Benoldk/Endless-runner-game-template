using game.package.fsm;
using UnityEngine;

namespace game.package.gameplay
{
    public class Obstacle : CollidableGameObject
    {
        private void OnCollisionEnter(Collision collision)
        {
            HandleCollision(gameObject);
        }

        public override void HandleCollision(GameObject target)
        {
            
        }
    }
}