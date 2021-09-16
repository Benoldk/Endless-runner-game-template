using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Decisions/DeathDecision", fileName = "Death-decision", order = 10)]
    public class DeathDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            return IsDead(controller);
        }

        private bool IsDead(StateController controller)
        {
            return controller.localStats.Health <= 0;
        }
    }
}