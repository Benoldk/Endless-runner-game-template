using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Decisions/SlideToRunDecision", fileName = "Slide-to-run-decision", order = 2)]
    public class SlideToRunDecision : Decision
    {
        private float _elapsedTime;

        public override bool Decide(PlayerStateController controller)
        {
            return DecideToTransitionFromSlideToRun(controller);
        }

        private bool DecideToTransitionFromSlideToRun(PlayerStateController controller)
        {
            _elapsedTime += Time.deltaTime;
            if(_elapsedTime > controller.slideAction.factor)
            {
                _elapsedTime = 0f;
                controller.slideAction.isActive = false;
                controller.animator.SetBool("isSliding", controller.slideAction.isActive);
                return true;
            }
            return false;
        }
    }
}