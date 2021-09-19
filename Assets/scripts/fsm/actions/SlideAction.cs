using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Actions/SlideAction", fileName = "Slide-action", order = 5)]
    public class SlideAction : Action
    {
        public override void Act(PlayerStateController controller)
        {
            Slide(controller);
        }

        private void Slide(PlayerStateController controller)
        {
            controller.animator.SetBool("isSliding", controller.slideAction.isActive);
        }
    }
}