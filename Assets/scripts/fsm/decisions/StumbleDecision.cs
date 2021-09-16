﻿using game.package.gameplay.services;
using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Decisions/StumbleDecision", fileName = "Stumble-decision", order = 8)]
    public class StumbleDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            return DecideToStumble(controller);
        }

        private bool DecideToStumble(StateController controller)
        {
            if (controller.isStumbling)
            {
                controller.localStats.Health--;
                HUDEvents.OnUpdateHP?.Invoke(controller.localStats.Health);
            }
            return controller.isStumbling;
        }
    }
}