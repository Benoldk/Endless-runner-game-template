using UnityEngine;

namespace game.package.fsm
{
    //[CreateAssetMenu(menuName = "FSM/PlayerController/RunStateAction", fileName = "run-state-action")]
    public class RunStateAction : MonoBehaviour
    {
        public float runAnimationMultiplier = 0.6f;
        public float runAnimationAccel = 0.001f;
        public float runAnimMaxMultiplier = 1;
    }
}