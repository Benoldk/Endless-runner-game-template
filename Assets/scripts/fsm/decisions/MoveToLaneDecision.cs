﻿using UnityEngine;

namespace game.package.fsm
{
    public class MoveToLaneDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            return DecideToMove(controller);
        }

        protected virtual bool DecideToMove(StateController controller)
        {
            return false;
        }

        protected virtual void SetPlayerPositionToTargetLanePosition(StateController controller)
        {
            Vector3 playerPos = controller.transform.position;
            playerPos.x = controller.targetPosition.x;
            controller.transform.position = playerPos;
            controller.isMovingHorizontally = false;
        }
    }
}