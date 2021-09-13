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
            Debug.Log($"Player y velocity: {controller.rigidBody.velocity.y}");
            if(controller.rigidBody.velocity.y <= 0)
            {
                Debug.Log("Player jump decision");
                controller.rigidBody.velocity = Vector3.zero;
                controller.rigidBody.angularVelocity = Vector3.zero;
                return true;
            }
            return false;
        }
    }
}