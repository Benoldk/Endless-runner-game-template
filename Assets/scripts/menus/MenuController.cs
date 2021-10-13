using UnityEngine;
using UnityEngine.UI;

namespace game.package.menus
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject optionsMenu;
        [SerializeField] private GameObject creditsMenu;
        [SerializeField] private GameObject loadingUI;

        private void Awake()
        {
            loadingUI.gameObject.SetActive(false);
            creditsMenu.SetActive(false);
            optionsMenu.SetActive(false);
            mainMenu.SetActive(true);
        }

        public void DisplayMainMenu()
        {
            mainMenu.SetActive(true);
        }

        public void HideMainMenu()
        {
            mainMenu.SetActive(false);
        }

        public void DisplayOptionsMenu()
        {
            optionsMenu.SetActive(true);
        }

        public void HideOptionsMenu()
        {
            optionsMenu.SetActive(false);
        }

        public void DisplayCreditsMenu()
        {
            creditsMenu.SetActive(true);
        }

        public void HideCreditsMenu()
        {
            creditsMenu.SetActive(false);
        }

        public void HideAllMenus()
        {
            mainMenu.SetActive(false);
            optionsMenu.SetActive(false);
            creditsMenu.SetActive(false);
        }

        public void DisplayLoadingBar()
        {
            loadingUI.gameObject.SetActive(true);
        }
    }
}