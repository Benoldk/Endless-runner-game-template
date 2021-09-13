using UnityEngine;

namespace game.package.fsm
{
    public class MoveToLaneDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            return DecideToMove(controller);
        }

        protected virtual bool DecideToMove(StateController controller)
        {
            return false;
        }

        protected virtual bool IsMovingToLaneTargetPosition(StateController controller)
        {
            Vector3 playerCurPos = new Vector3(controller.transform.position.x, 0, 0);
            if (Vector3.Distance(playerCurPos, controller.targetPosition) < controller.targetDistanceThreshold)
            {
                Vector3 playerPos = controller.transform.position;
                playerPos.x = controller.targetPosition.x;
                controller.transform.position = playerPos;
                controller.isMovingLeft = false;
                return false;
            }
            return true;
        }
    }
}