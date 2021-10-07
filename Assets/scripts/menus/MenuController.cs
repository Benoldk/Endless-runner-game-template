using UnityEngine;

namespace game.package.menus
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject optionsMenu;
        [SerializeField] private GameObject creditsMenu;

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
    }
}