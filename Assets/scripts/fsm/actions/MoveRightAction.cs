using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Actions/MoveRightAction", fileName = "Move-right-action", order = 4)]
    public class MoveRightAction : MoveHorizontallyAction
    {
        protected override void MoveHorizontally(PlayerStateController controller)
        {
            float distance = Vector3.Distance(new Vector3(controller.transform.position.x, 0, 0), controller.horizontalMovementAction.targetPosition);
            if (distance > controller.horizontalMovementAction.targetDistanceThreshold)
            {
                controller.horizontalMovementAction.direction = Vector3.right;// (controller.transform.forward + Vector3.right).normalized;
            }
            else
            {
                SetPlayerPositionToTargetLanePosition(controller);
                controller.horizontalMovementAction.direction = Vector3.zero;// controller.transform.forward;
            }
            controller.animator.SetFloat("speed", controller.localStats.Speed);
        }
    }
}