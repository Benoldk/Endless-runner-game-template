using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Decisions/JumpDecision", fileName = "Jump-decision", order = 3)]
    public class JumpDecision : Decision
    {
        public override bool Decide(PlayerStateController controller)
        {
            return DecideToJump(controller);
        }

        private bool DecideToJump(PlayerStateController controller)
        {
            if(!controller.jumpAction.isActive
                && controller.rigidBody.velocity.y == 0
                && Input.GetAxis("Vertical") > 0)
            {
                controller.jumpAction.isActive = true;
                controller.rigidBody.AddForce(Vector3.up * controller.jumpAction.factor, ForceMode.Impulse);
                return true;
            }
            return false;
        }
    }
}