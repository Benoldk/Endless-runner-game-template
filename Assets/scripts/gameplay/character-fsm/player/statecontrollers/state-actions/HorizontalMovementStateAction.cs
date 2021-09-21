using System.Collections.Generic;
using UnityEngine;

namespace game.package.fsm
{
    public class HorizontalMovementStateAction : MonoBehaviour
    {
        public bool isActive;
        public int minLaneIndex = -1;
        public int maxLaneIndex = 1;
        public int targetLane = 1;
        public float laneOffset = 2.5f;
        public float targetLanePosition;
        public float targetDistanceThreshold = 0.25f;
        public Vector3 direction;
        public Vector3 leftLanePosition = new Vector3(-2.5f, 0, 0);
        public Vector3 middleLanePosition = new Vector3(0, 0, 0);
        public Vector3 rightLanePosition = new Vector3(2.5f, 0, 0);
        public Dictionary<int, Vector3> lanesMap = new Dictionary<int, Vector3>();

        public void Initialize()
        {
            lanesMap.Add(-1, leftLanePosition);
            lanesMap.Add(0, middleLanePosition);
            lanesMap.Add(1, rightLanePosition);
        }
    }
}