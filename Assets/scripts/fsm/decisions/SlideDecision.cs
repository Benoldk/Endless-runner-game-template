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
            if(!controller.isSliding
                && Input.GetAxis("Vertical") < 0)
            {
                controller.isSliding = true;
            }
            return controller.isSliding;
        }
    }
}