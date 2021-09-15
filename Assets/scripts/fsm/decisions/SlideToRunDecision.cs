using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Decisions/SlideToRunDecision", fileName = "Slide-to-run-decision", order = 2)]
    public class SlideToRunDecision : Decision
    {
        private float _elapsedTime;

        public override bool Decide(StateController controller)
        {
            return DecideToTransitionFromSlideToRun(controller);
        }

        private bool DecideToTransitionFromSlideToRun(StateController controller)
        {
            _elapsedTime += Time.deltaTime;
            if(_elapsedTime > controller.slideDuration)
            {
                _elapsedTime = 0f;
                controller.isSliding = false;
                controller.animator.SetBool("isSliding", controller.isSliding);
                return true;
            }
            return false;
        }
    }
}