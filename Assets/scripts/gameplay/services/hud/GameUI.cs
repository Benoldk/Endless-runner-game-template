using game.package.gameplay.services;
using TMPro;
using UnityEngine;

namespace game.package.gameplay
{
    public class GameHUD : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreTextGUI;
        [SerializeField] private TextMeshProUGUI currencyTextGUI;
        [SerializeField] private TextMeshProUGUI scoreMultiplierTextGUI;
        [SerializeField] private HealthHUD healthHUD;
        public GameObject pauseUI;

        private int score = 0;
        private int currency = 0;
        private int scoreMultiplier = 1;

        private void Awake()
        {
            HUDEvents.OnUIAddToCurrency += AddToCurrency;
            HUDEvents.OnUIAddToScore += AddToScore;
            HUDEvents.OnUIAddToScoreMultipler += AddToScoreMultiplier;
            HUDEvents.OnUpdateHP += healthHUD.SetHP;
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