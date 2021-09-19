using game.package.gameplay.services;
using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Decisions/StumbleDecision", fileName = "Stumble-decision", order = 8)]
    public class StumbleDecision : Decision
    {
        public override bool Decide(PlayerStateController controller)
        {
            return DecideToStumble(controller);
        }

        private bool DecideToStumble(PlayerStateController controller)
        {
            if (controller.stumbleAction.isActive)
            {
                controller.localStats.Health--;
                HUDEvents.OnUpdateHP?.Invoke(controller.localStats.Health);
            }
            return controller.stumbleAction.isActive;
        }
    }
}