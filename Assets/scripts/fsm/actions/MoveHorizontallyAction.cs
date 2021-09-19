using UnityEngine;

namespace game.package.fsm
{
    public class MoveHorizontallyAction : Action
    {
        public override void Act(PlayerStateController controller)
        {
            MoveHorizontally(controller);
            UpdatePosition(controller);
        }

        protected virtual void MoveHorizontally(PlayerStateController controller)
        {

        }

        protected virtual void SetPlayerPositionToTargetLanePosition(PlayerStateController controller)
        {
            Vector3 playerPos = controller.transform.position;
            playerPos.x = controller.horizontalMovementAction.targetPosition.x;
            controller.transform.position = playerPos;
            controller.horizontalMovementAction.isActive = false;
        }
    }
}