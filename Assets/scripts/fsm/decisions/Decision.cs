using UnityEngine;

namespace game.package.fsm
{
    public abstract class Decision : ScriptableObject
    {
        public abstract bool Decide(PlayerStateController controller);
    }
}