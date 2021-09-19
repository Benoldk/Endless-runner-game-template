using UnityEngine;

namespace game.package.ui
{
    [CreateAssetMenu(menuName = "CustomUI/ScoreUI", fileName = "score-ui")]
    public class ScoreUIController : ScriptableObject
    {
        public int scoreValue = 5;
        [Range(0.5f, 2f)] public float scoreUpdateInterval = 1f;
    }
}