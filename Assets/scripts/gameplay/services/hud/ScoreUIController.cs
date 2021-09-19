using UnityEngine;

namespace game.package.gameplay
{
    [CreateAssetMenu(menuName = "CustomUI/ScoreUI", fileName = "score-ui")]
    public class ScoreUIController : ScriptableObject
    {
        public int scoreValue = 5;
        [Range(0.5f, 2f)] public float scoreUpdateInterval = 1f;
    }
}