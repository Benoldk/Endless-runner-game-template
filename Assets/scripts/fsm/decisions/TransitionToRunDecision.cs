using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Decisions/TransitionToRunDecision", fileName = "Transition-To-Run-Decision")]
    public class TransitionToRunDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            return DecideToTransitionToRun(controller);
        }

        private bool DecideToTransitionToRun(StateController controller)
        {
            return !controller.isMovingLeft && !controller.isMovingRight;
        }
    }
}