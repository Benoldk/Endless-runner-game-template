using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Actions/MoveRightAction", fileName = "Move-right-action", order = 3)]
    public class MoveRightAction : Action
    {
        public override void Act(StateController controller)
        {
            MoveRight(controller);
            UpdatePosition(controller);
        }

        private void MoveRight(StateController controller)
        {
            controller.direction = (controller.transform.forward + Vector3.right).normalized;
            controller.animator.SetFloat("speed", controller.localStats.Speed);
        }
    }
}