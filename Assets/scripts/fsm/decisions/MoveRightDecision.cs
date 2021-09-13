using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Decisions/MoveRightDecision", fileName = "Move-right-decision")]
    public class MoveRightDecision : MoveToLaneDecision
    {
        protected override bool DecideToMove(StateController controller)
        {
            if (!controller.isMovingRight
                && !controller.isMovingLeft
                && controller.transform.position.x != controller.rightLaneOffset 
                && Input.GetAxisRaw("Horizontal") > 0)
            {
                controller.targetPosition = new Vector3(controller.transform.position.x + controller.rightLaneOffset, 0, 0);
                controller.isMovingRight = true;
                return true;
            }
            else if (controller.isMovingRight && !controller.isMovingLeft)
            {
                controller.isMovingRight = IsMovingToLaneTargetPosition(controller);
                return controller.isMovingRight;
            }
            return false;
        }
    }
}