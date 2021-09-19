using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Decisions/HorizontalMoveTransitionToRunDecision", fileName = "HorizontalMove-Transition-To-Run-Decision", order = 7)]
    public class HorizontalMoveTransitionToRunDecision : Decision
    {
        public override bool Decide(PlayerStateController controller)
        {
            return DecideToTransitionToRun(controller);
        }

        private bool DecideToTransitionToRun(PlayerStateController controller)
        {
            return !controller.horizontalMovementAction.isActive;
        }
    }
}