using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/Decisions/RunDecision", fileName = "Run-decision", order = 0)]
    public class RunDecision : Decision
    {
        private float elapsedTime;

        public override bool Decide(StateController controller)
        {
            return DecideToRun(controller);
        }

        private bool DecideToRun(StateController controller)
        {
            elapsedTime += Time.deltaTime;
            if(elapsedTime > controller.localStats.IdleDuration)
            {
                elapsedTime = 0;
                return true;
            }
            return false;
        }
    }
}