using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Actions/StumbleAction", fileName = "Stumble-action")]
    public class StumbleAction : Action
    {
        public override void Act(StateController controller)
        {
            Stumble(controller);
            UpdatePosition(controller);
        }

        private void Stumble(StateController controller)
        {
            controller.animator.SetBool("isStumbling", controller.isStumbling);
        }
    }
}