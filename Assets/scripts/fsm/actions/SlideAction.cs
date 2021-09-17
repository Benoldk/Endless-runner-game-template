using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Actions/SlideAction", fileName = "Slide-action", order = 5)]
    public class SlideAction : Action
    {
        public override void Act(StateController controller)
        {
            Slide(controller);
        }

        private void Slide(StateController controller)
        {
            controller.animator.SetBool("isSliding", controller.isSliding);
        }
    }
}