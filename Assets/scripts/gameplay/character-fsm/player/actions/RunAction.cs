using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Actions/Run", fileName = "Run-action", order = 1)]
    public class RunAction : Action
    {
        public override void Act(PlayerStateController controller)
        {
            Run(controller);
            base.Act(controller);
        }

        private void Run(PlayerStateController controller)
        {
            controller.horizontalMovementAction.direction = isTest
                    ? Vector3.zero
                    : controller.transform.forward;
            controller.animator.SetFloat("speed", controller.localStats.Speed);
        }
    }
}