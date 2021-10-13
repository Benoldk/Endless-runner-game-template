using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace game.package.utilities
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private Slider loadingBar;

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void LoadGameplaySceneAsync()
        {
            StartCoroutine(LoadSceneAsyncrhonously("Gameplay"));
        }

        private IEnumerator LoadSceneAsyncrhonously(string sceneName)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
            while(!asyncLoad.isDone)
            {
                loadingBar.value = Mathf.Clamp01(asyncLoad.progress / 0.9f);
                yield return null;
            }
        }
    }
}