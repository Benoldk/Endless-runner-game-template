using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Actions/Idle", fileName = "Idle-action", order = 0)]
    public class IdleAction : Action
    {
        public override void Act(StateController controller)
        {
            Idle(controller);
        }

        protected virtual void Idle(StateController controller)
        {
        }
    }
}