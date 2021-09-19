using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Decisions/MoveRightDecision", fileName = "Move-right-decision", order = 6)]
    public class MoveRightDecision : MoveToLaneDecision
    {
        protected override bool DecideToMove(PlayerStateController controller)
        {
            if (controller.targetLane < controller.maxLaneIndex
                && !controller.isMovingHorizontally
                && Input.GetAxisRaw("Horizontal") > 0)
            {
                controller.targetLane++;
                controller.targetPosition = new Vector3(controller.transform.position.x + controller.laneOffset, 0, 0);
                controller.isMovingHorizontally = true;
                return true;
            }
            return false;
        }
    }
}