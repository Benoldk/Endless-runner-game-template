using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Decisions/JumpDecision", fileName = "Jump-decision")]
    public class JumpDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            return DecideToJump(controller);
        }

        private bool DecideToJump(StateController controller)
        {
            return controller.rigidBody.velocity.y == 0
                && controller.isGrounded
                && Input.GetAxis("Vertical") > 0;
        }
    }
}