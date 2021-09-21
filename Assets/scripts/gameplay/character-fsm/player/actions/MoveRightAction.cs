using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Actions/MoveRightAction", fileName = "Move-right-action", order = 4)]
    public class MoveRightAction : MoveHorizontallyAction
    {
        protected override void MoveHorizontally(PlayerStateController controller)
        {
            float distance = Vector3.Distance(new Vector3(controller.transform.position.x, 0, 0), controller.horizontalMovementAction.lanesMap[controller.horizontalMovementAction.targetLane]);
            if (
                controller.transform.position.x > controller.horizontalMovementAction.lanesMap[controller.horizontalMovementAction.targetLane].x)
            {
                SetPlayerPositionToTargetLanePosition(controller);
                controller.horizontalMovementAction.direction = isTest
                    ? Vector3.zero
                    : controller.transform.forward;
                controller.currentLane = controller.horizontalMovementAction.targetLane;
            }
            controller.animator.SetFloat("speed", controller.localStats.Speed);
        }
    }
}