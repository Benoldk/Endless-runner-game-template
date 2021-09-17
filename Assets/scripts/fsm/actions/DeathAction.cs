using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Actions/DeathAction", fileName = "Death-action", order = 7)]
    public class DeathAction : Action
    {
        public override void Act(StateController controller)
        {
            Die(controller);
        }

        private void Die(StateController controller)
        {
            controller.animator.SetBool("isDead", controller.isDead);
        }
    }
}