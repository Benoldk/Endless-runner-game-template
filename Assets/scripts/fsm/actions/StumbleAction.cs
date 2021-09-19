﻿using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Actions/StumbleAction", fileName = "Stumble-action", order = 6)]
    public class StumbleAction : Action
    {
        public override void Act(PlayerStateController controller)
        {
            Stumble(controller);
            UpdatePosition(controller);
        }

        private void Stumble(PlayerStateController controller)
        {
            controller.animator.SetBool("isStumbling", controller.isStumbling);
        }
    }
}