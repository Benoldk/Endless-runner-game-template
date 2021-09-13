using game.package.gameplay.services;
using TMPro;
using UnityEngine;

namespace game.package.gameplay
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreTextGUI;
        [SerializeField] private TextMeshProUGUI currencyTextGUI;
        [SerializeField] private TextMeshProUGUI scoreMultiplierTextGUI;
        public GameObject pauseUI;

        private int score = 0;
        private int currency = 0;
        private int scoreMultiplier = 1;

        private void Awake()
        {
            GameEvents.OnUIAddToCurrency += AddToCurrency;
            GameEvents.OnUIAddToScore += AddToScore;
            GameEvents.OnUIAddToScoreMultipler += AddToScoreMultiplier;
        }

        private void Start()
        {
            UpdateUI();
        }

        void UpdateUI()
        {
            scoreTextGUI.text = $"{score}";
            currencyTextGUI.text = $"{currency}";
            scoreMultiplierTextGUI.text = $"x{scoreMultiplier}";
        }

        private void AddToScore(int value)
        {
            score += value * scoreMultiplier;
            UpdateUI();
        }

        private void AddToCurrency(int value)
        {
            currency += value;
            UpdateUI();
        }

        private void AddToScoreMultiplier(int value)
        {
            scoreMultiplier += value;
            UpdateUI();
        }
    }
}