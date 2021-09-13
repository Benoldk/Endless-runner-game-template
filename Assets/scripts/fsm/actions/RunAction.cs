using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Actions/Run", fileName = "Run-action", order = 1)]
    public class RunAction : Action
    {
        public override void Act(StateController controller)
        {
            Run(controller);
            UpdatePosition(controller);
        }

        private void Run(StateController controller)
        {
            controller.direction = controller.transform.forward.normalized;
            controller.animator.SetFloat("speed", controller.localStats.Speed);
        }
    }
}