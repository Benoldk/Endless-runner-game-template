using UnityEngine;

namespace game.package.gameplay
{
    public abstract class CollidableGameObject : MonoBehaviour
    {
        public abstract void HandleCollision(Rigidbody rigidbod);
    }
}