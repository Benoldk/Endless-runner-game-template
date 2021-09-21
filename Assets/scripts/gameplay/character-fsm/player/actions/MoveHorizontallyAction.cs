using UnityEngine;

namespace game.package.fsm
{
    public class MoveHorizontallyAction : Action
    {
        public override void Act(PlayerStateController controller)
        {
            MoveHorizontally(controller);
            base.Act(controller);
        }

        protected virtual void MoveHorizontally(PlayerStateController controller)
        {

        }

        protected virtual void SetPlayerPositionToTargetLanePosition(PlayerStateController controller)
        {
            Vector3 playerPos = controller.transform.position;
            playerPos.x = controller.horizontalMovementAction.lanesMap[controller.horizontalMovementAction.targetLane].x;
            controller.transform.position = playerPos;
            controller.horizontalMovementAction.isActive = false;
        }
    }
}