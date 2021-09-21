using UnityEngine;

namespace game.package.fsm
{
    public class Action : ScriptableObject
    {
        [SerializeField] protected bool isTest;
        
        public virtual void Act(PlayerStateController controller)
        {
            SetRunAnimationSpeed(controller);
            UpdatePosition(controller);
        }

        protected virtual void UpdatePosition(PlayerStateController controller)
        {
            controller.transform.position += controller.horizontalMovementAction.direction * controller.localStats.Speed * Time.deltaTime;
            if (controller.localStats.Speed < controller.localStats.MaxSpeed)
                controller.localStats.Speed += controller.localStats.Acceleration * Time.deltaTime;
        }

        protected virtual void SetRunAnimationSpeed(PlayerStateController controller)
        {
            if (controller.runAction.runAnimationMultiplier < controller.runAction.runAnimMaxMultiplier)
                controller.runAction.runAnimationMultiplier += controller.runAction.runAnimationAccel * Time.deltaTime;
            controller.animator.SetFloat("runAnimMultiplier", controller.runAction.runAnimationMultiplier);
        }
    }
}