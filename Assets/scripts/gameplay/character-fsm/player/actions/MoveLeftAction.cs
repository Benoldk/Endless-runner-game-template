﻿using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Actions/MoveLeftAction", fileName = "Move-left-action", order = 3)]
    public class MoveLeftAction : MoveHorizontallyAction
    {
        protected override void MoveHorizontally(PlayerStateController controller)
        {
            float distance = Vector3.Distance(new Vector3(controller.transform.position.x, 0, 0), controller.horizontalMovementAction.targetPosition);
            if (distance > controller.horizontalMovementAction.targetDistanceThreshold)
            {
                controller.horizontalMovementAction.direction = (controller.transform.forward + Vector3.left).normalized;
            }
            else
            {
                SetPlayerPositionToTargetLanePosition(controller);
                controller.horizontalMovementAction.direction = controller.transform.forward;
            }
            controller.animator.SetFloat("speed", controller.localStats.Speed);
        }
    }
}