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
                && controller.currentLane == controller.horizontalMovementAction.targetLane
                && GetAxisKeyDown("Horizontal"))
            {
                controller.horizontalMovementAction.targetLane--;
                controller.testTargetLane = controller.horizontalMovementAction.targetLane;
                controller.horizontalMovementAction.direction = (controller.horizontalMovementAction.lanesMap[controller.horizontalMovementAction.targetLane] - controller.horizontalMovementAction.lanesMap[controller.currentLane]).normalized;
                controller.horizontalMovementAction.isActive = true;
                Debug.Log($"lane target {controller.horizontalMovementAction.targetLane}");
                return true;
            }
            return false;
        }

        protected override bool GetAxisKeyDown(string axis)
        {
            return Input.anyKeyDown && Input.GetAxisRaw(axis) < 0;
        }
    }
}