using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Decisions/SlideDecision", fileName = "Slide-decision", order = 1)]
    public class SlideDecision : Decision
    {
        public override bool Decide(PlayerStateController controller)
        {
            return DecideToSlide(controller);
        }

        private bool DecideToSlide(PlayerStateController controller)
        {
            if(!controller.slideAction.isActive
                && Input.GetAxis("Vertical") < 0)
            {
                controller.slideAction.isActive = true;
            }
            return controller.slideAction.isActive;
        }
    }
}