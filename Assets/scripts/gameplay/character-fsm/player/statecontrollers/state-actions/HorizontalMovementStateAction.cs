using UnityEngine;

namespace game.package.fsm
{
    //[CreateAssetMenu(menuName = "FSM/PlayerController/HorizontalMovementStateAction", fileName = "horizontal-movement-state-action")]
    public class HorizontalMovementStateAction : MonoBehaviour
    {
        public int minLaneIndex = 0;
        public int maxLaneIndex = 2;
        public int targetLane = 1;
        public float laneOffset = 2.5f;
        public float targetLanePosition;
        public float targetDistanceThreshold = 0.25f;
        public bool isActive;
        public Vector3 targetPosition;
        public Vector3 direction;
    }
}