using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Decisions/MoveRightDecision", fileName = "Move-right-decision", order = 6)]
    public class MoveRightDecision : MoveToLaneDecision
    {
        protected override bool DecideToMove(PlayerStateController controller)
        {
            if (controller.horizontalMovementAction.targetLane < controller.horizontalMovementAction.maxLaneIndex
                && !controller.horizontalMovementAction.isActive
                && Input.GetAxisRaw("Horizontal") > 0)
            {
                controller.horizontalMovementAction.targetLane++;
                controller.horizontalMovementAction.targetPosition = new Vector3(controller.transform.position.x + controller.horizontalMovementAction.laneOffset, 0, 0);
                controller.horizontalMovementAction.isActive = true;
                return true;
            }
            return false;
        }
    }
}