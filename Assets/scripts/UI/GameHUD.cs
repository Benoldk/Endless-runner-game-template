using TMPro;
using UnityEngine;

namespace game.package.ui
{
    public class GameHUD : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreTextGUI;
        [SerializeField] private TextMeshProUGUI currencyTextGUI;
        [SerializeField] private TextMeshProUGUI scoreMultiplierTextGUI;
        [SerializeField] private HealthHUD healthHUD;
        [SerializeField] private PauseUI pauseUI;

        private int score = 0;
        private int currency = 0;
        private int scoreMultiplier = 1;

        private void Awake()
        {
            pauseUI.gameObject.SetActive(false);
            HUDEvents.OnUIAddToCurrency += AddToCurrency;
            HUDEvents.OnUIAddToScore += AddToScore;
            HUDEvents.OnUIAddToScoreMultipler += AddToScoreMultiplier;
            HUDEvents.OnUpdateHP += healthHUD.SetHP;
            HUDEvents.OnGamePaused += DisplayPauseUI;
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

        private void DisplayPauseUI(bool gamePauseState)
        {
            print($"Paused: {gamePauseState}");
            pauseUI.gameObject.SetActive(gamePauseState);
        }
    }
}