using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Actions/JumpAction", fileName = "Jump-action", order = 2)]
    public class JumpAction : Action
    {
        public override void Act(StateController controller)
        {
            Jump(controller);
            UpdatePosition(controller);
        }

        private void Jump(StateController controller)
        {
            controller.animator.SetBool("isJumping", controller.isJumping);
        }
    }
}