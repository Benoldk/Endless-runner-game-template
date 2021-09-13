using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Decisions/MoveLeftDecision", fileName = "Move-left-decision")]
    public class MoveLeftDecision : MoveToLaneDecision
    {
        protected override bool DecideToMove(StateController controller)
        {
            if (!controller.isMovingLeft
                && !controller.isMovingRight
                && controller.transform.position.x != controller.leftLaneOffset
                && Input.GetAxisRaw("Horizontal") < 0)
            {
                controller.targetPosition = new Vector3(controller.transform.position.x + controller.leftLaneOffset, 0, 0);
                controller.isMovingLeft = true;
                return true;
            }
            else if (controller.isMovingLeft && !controller.isMovingRight)
            {
                controller.isMovingLeft = IsMovingToLaneTargetPosition(controller);
                return controller.isMovingLeft;
            }
            return false;
        }
    }
}