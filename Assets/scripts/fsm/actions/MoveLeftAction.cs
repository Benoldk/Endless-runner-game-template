using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Actions/MoveLeftAction", fileName = "Move-left-action", order = 2)]
    public class MoveLeftAction : Action
    {
        public override void Act(StateController controller)
        {
            MoveLeft(controller);
            UpdatePosition(controller);
        }

        private void MoveLeft(StateController controller)
        {
            Vector3 direction = (controller.transform.forward + Vector3.left).normalized;
            controller.animator.SetFloat("speed", controller.localStats.Speed);
        }
    }
}