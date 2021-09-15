using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Decisions/JumpDecision", fileName = "Jump-decision", order = 3)]
    public class JumpDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            return DecideToJump(controller);
        }

        private bool DecideToJump(StateController controller)
        {
            if(!controller.isJumping 
                && controller.rigidBody.velocity.y == 0
                && Input.GetAxis("Vertical") > 0)
            {
                controller.isJumping = true;
                controller.rigidBody.AddForce(Vector3.up * controller.jumpForce, ForceMode.Impulse);
                return true;
            }
            return false;
        }
    }
}