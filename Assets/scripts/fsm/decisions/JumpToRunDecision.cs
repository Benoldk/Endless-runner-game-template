using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Decisions/JumpToRunDecision", fileName = "Jump-to-run-decision")]
    public class JumpToRunDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            return DecideToRun(controller);
        }

        private bool DecideToRun(StateController controller)
        {
            if(!controller.isJumping && controller.rigidBody.velocity.y == 0)
            {
                controller.animator.SetBool("isJumping", false);
                return true;
            }
            return false;
        }
    }
}