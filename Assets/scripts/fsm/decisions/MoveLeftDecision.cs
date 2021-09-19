using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Decisions/MoveLeftDecision", fileName = "Move-left-decision", order = 5)]
    public class MoveLeftDecision : MoveToLaneDecision
    {
        protected override bool DecideToMove(PlayerStateController controller)
        {
            if (controller.targetLane > controller.minLaneIndex
                && !controller.isMovingHorizontally
                && Input.GetAxisRaw("Horizontal") < 0)
            {
                controller.targetLane--;
                controller.targetPosition = new Vector3(controller.transform.position.x - controller.laneOffset, 0, 0);
                controller.isMovingHorizontally = true;
                return true;
            }
            return false;
        }
    }
}