using UnityEngine;

namespace game.package.fsm
{
    public class MoveHorizontallyAction : Action
    {
        public override void Act(StateController controller)
        {
            MoveHorizontally(controller);
            UpdatePosition(controller);
        }

        protected virtual void MoveHorizontally(StateController controller)
        {

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