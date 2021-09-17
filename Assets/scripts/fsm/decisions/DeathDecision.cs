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
            if(controller.localStats.Health <= 0 && !controller.isDead)
            {
                controller.isDead = true;
                controller.gameObject.layer = LayerMask.NameToLayer("PlayerDeath");
                controller.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, -1) * 3f, ForceMode.Impulse);
            }
            return controller.isDead;
        }
    }
}