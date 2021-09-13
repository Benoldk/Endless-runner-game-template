using UnityEngine;

namespace game.package.gameplay
{
    public class Obstacle : CollidableGameObject
    {
        public override void HandleCollision(Rigidbody rigidbod)
        {
            Debug.Log($"{tag} collided with {name}");
        }
    }
}