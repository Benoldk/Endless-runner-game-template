using UnityEngine;

namespace game.package.fsm.stats
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Character Stats", menuName = "Stats/Character Stats")]
    public class CharacterStats : ScriptableObject
    {
        public int Health;
        public float Speed;
        public float MaxSpeed;
        public float Acceleration;
        public float IdleDuration;
    }
}