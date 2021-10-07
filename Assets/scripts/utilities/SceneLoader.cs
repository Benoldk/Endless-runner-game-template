using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace game.package.utilities
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void LoadSceneAsync(string sceneName)
        {
            StartCoroutine(LoadSceneAsyncrhonously(sceneName));
        }

        private IEnumerator LoadSceneAsyncrhonously(string sceneName)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
            while(!asyncLoad.isDone)
            {
                yield return null;
            }
        }
    }
}