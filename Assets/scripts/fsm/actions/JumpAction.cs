using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Actions/JumpAction", fileName = "Jump-action")]
    public class JumpAction : Action
    {
        public override void Act(StateController controller)
        {
            Jump(controller);
            UpdatePosition(controller);
        }

        private void Jump(StateController controller)
        {
            if (controller.rigidBody.velocity.y == 0 && controller.isGrounded)
            {
                Debug.Log("Player jump action");
                controller.isGrounded = false;
                controller.animator.SetBool("isJumping", controller.rigidBody.velocity.y > 0);
                controller.rigidBody.AddForce(Vector3.up * controller.jumpForce, ForceMode.Impulse);
            }
        }
    }
}