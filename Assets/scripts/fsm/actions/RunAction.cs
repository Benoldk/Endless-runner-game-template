using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Actions/Run", fileName = "Run-action", order = 1)]
    public class RunAction : Action
    {
        public override void Act(PlayerStateController controller)
        {
            SetRunAnimationSpeed(controller);
            Run(controller);
            UpdatePosition(controller);
        }

        private void Run(PlayerStateController controller)
        {
            controller.horizontalMovementAction.direction = Vector3.zero;// controller.transform.forward.normalized;
            controller.animator.SetFloat("speed", controller.localStats.Speed);
        }

        private void SetRunAnimationSpeed(PlayerStateController controller)
        {
            if(controller.runAction.runAnimationMultiplier < controller.runAction.runAnimMaxMultiplier)
                controller.runAction.runAnimationMultiplier += controller.runAction.runAnimationAccel * Time.deltaTime;
            controller.animator.SetFloat("runAnimMultiplier", controller.runAction.runAnimationMultiplier);
        }
    }
}