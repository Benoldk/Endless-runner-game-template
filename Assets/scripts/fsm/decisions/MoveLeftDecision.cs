using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Decisions/MoveLeftDecision", fileName = "Move-left-decision", order = 5)]
    public class MoveLeftDecision : MoveToLaneDecision
    {
        protected override bool DecideToMove(PlayerStateController controller)
        {
            if (controller.horizontalMovementAction.targetLane > controller.horizontalMovementAction.minLaneIndex
                && !controller.horizontalMovementAction.isActive
                && Input.GetAxisRaw("Horizontal") < 0)
            {
                controller.horizontalMovementAction.targetLane--;
                controller.horizontalMovementAction.targetPosition = new Vector3(controller.transform.position.x - controller.horizontalMovementAction.laneOffset, 0, 0);
                controller.horizontalMovementAction.isActive = true;
                return true;
            }
            return false;
        }
    }
}