using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Decisions/JumpToRunDecision", fileName = "Jump-to-run-decision", order = 4)]
    public class JumpToRunDecision : Decision
    {
        public override bool Decide(PlayerStateController controller)
        {
            return DecideToRun(controller);
        }

        private bool DecideToRun(PlayerStateController controller)
        {
            if(!controller.jumpAction.isActive && controller.rigidBody.velocity.y == 0)
            {
                controller.animator.SetBool("isJumping", false);
                return true;
            }
            return false;
        }
    }
}