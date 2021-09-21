using UnityEngine;

namespace game.package.fsm
{
    public class MoveToLaneDecision : Decision
    {
        public override bool Decide(PlayerStateController controller)
        {
            return DecideToMove(controller);
        }

        protected virtual bool DecideToMove(PlayerStateController controller)
        {
            return false;
        }

        protected virtual bool GetAxisKeyDown(string axis)
        {
            return false;
        }
    }
}