using TMPro;
using UnityEngine;

namespace game.package.ui
{
    public class GameHUD : MonoBehaviour
    {
        [SerializeField] private HealthHUD healthHUD;
        [SerializeField] private PauseUI pauseUI;

        private void Awake()
        {
            pauseUI.gameObject.SetActive(false);
            HUDEvents.OnUpdateHP += healthHUD.SetHP;
            HUDEvents.OnGamePaused += DisplayPauseUI;
        }

        private void DisplayPauseUI(bool gamePauseState)
        {
            print($"Paused: {gamePauseState}");
            pauseUI.gameObject.SetActive(gamePauseState);
        }
    }
}