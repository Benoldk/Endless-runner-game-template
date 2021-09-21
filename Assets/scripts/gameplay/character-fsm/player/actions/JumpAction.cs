using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Actions/JumpAction", fileName = "Jump-action", order = 2)]
    public class JumpAction : Action
    {
        public override void Act(PlayerStateController controller)
        {
            Jump(controller);
            base.Act(controller);
        }

        private void Jump(PlayerStateController controller)
        {
            controller.animator.SetBool("isJumping", controller.jumpAction.isActive);
        }
    }
}