using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Decisions/StumbleToRunDecision", fileName = "Stumble-to-run-decision", order = 9)]
    public class TransitionStumbleToRunDecision : Decision
    {
        private float elapsedTime;

        public override bool Decide(PlayerStateController controller)
        {
            return TransitionFromStumbleToRunDecision(controller);
        }

        private bool TransitionFromStumbleToRunDecision(PlayerStateController controller)
        {
            elapsedTime += Time.deltaTime;
            if(elapsedTime > controller.stumbleAction.factor)
            {
                elapsedTime = 0;
                controller.stumbleAction.isActive = false;
                controller.animator.SetBool("isStumbling", controller.stumbleAction.isActive);
                return true;
            }

            return false;
        }
    }
}