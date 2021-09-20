using game.package.ui;
using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Decisions/RunDecision", fileName = "Run-decision", order = 0)]
    public class RunDecision : Decision
    {
        private float elapsedTime;

        public override bool Decide(PlayerStateController controller)
        {
            return DecideToRun(controller);
        }

        private bool DecideToRun(PlayerStateController controller)
        {
            elapsedTime += Time.deltaTime;
            if(elapsedTime > controller.localStats.IdleDuration)
            {
                elapsedTime = 0;
                HUDEvents.OnUpdateScoringState?.Invoke(true);
                return true;
            }
            return false;
        }
    }
}