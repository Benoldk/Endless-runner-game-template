using UnityEngine;

namespace game.package.ui
{
    public class PauseScript : MonoBehaviour
    {
        private bool isGamePaused;

        public void PauseGame()
        {
            isGamePaused = !isGamePaused;
            HUDEvents.OnGamePaused?.Invoke(isGamePaused);
            Time.timeScale = isGamePaused ? 0 : 1;
        }
    }
}