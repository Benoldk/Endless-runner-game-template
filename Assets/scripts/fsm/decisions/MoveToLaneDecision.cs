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

        protected virtual void SetPlayerPositionToTargetLanePosition(PlayerStateController controller)
        {
            Vector3 playerPos = controller.transform.position;
            playerPos.x = controller.targetPosition.x;
            controller.transform.position = playerPos;
            controller.isMovingHorizontally = false;
        }
    }
}