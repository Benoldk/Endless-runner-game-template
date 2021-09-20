using TMPro;
using UnityEngine;

namespace game.package.ui
{
    public class RewardsUI : MonoBehaviour
    {
        public int scoreUnit = 5;
        [Range(0.5f, 2f)] public float scoreUpdateInterval = 1f;
        public TextMeshProUGUI scoreTMP;
        public TextMeshProUGUI scoreMultiplierTMP;
        public TextMeshProUGUI currencyTMP;

        private int currency;
        private int score;
        private int scoreMultiplier;
        private bool isActive;
        private float elapsedTime;

        private void Start()
        {
            score = 0;
            scoreMultiplier = 1;
            UpdateUI();
        }

        private void Awake()
        {
            HUDEvents.OnUpdateScoringState += UpdateScoringState;
            HUDEvents.OnUIAddToCurrency += AddToCurrency;
            HUDEvents.OnUpdateScoreMultipler += AddToScoreMultiplier;
        }

        private void UpdateScoringState(bool state)
        {
            isActive = state;
        }

        private void Update()
        {
            if(isActive)
            {
                elapsedTime += Time.deltaTime;
                if(elapsedTime > scoreUpdateInterval)
                {
                    elapsedTime = 0;
                    score += scoreUnit * scoreMultiplier;
                    UpdateUI();
                }
            }
        }

        private void UpdateUI()
        {
            scoreTMP.text = score.ToString();
            scoreMultiplierTMP.text = scoreMultiplier.ToString();
            currencyTMP.text = currency.ToString();
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