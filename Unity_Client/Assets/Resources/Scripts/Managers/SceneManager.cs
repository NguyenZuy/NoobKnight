using NoobKnight.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace NoobKnight.Managers
{
    public interface ISceneChange
    {
        void OnSceneChanged();
    }

    public class SceneManager : MonoBehaviour
    {
        public static void ChangeScene(SceneNames sceneName, UnityAction<UnityEngine.SceneManagement.Scene, LoadSceneMode> sceneLoadedCallback = null)
        {
            if (sceneLoadedCallback != null)
            {
                UnityEngine.SceneManagement.SceneManager.sceneLoaded += sceneLoadedCallback;
                UnityEngine.SceneManagement.SceneManager.sceneLoaded += (scene, mode) =>
                {
                    UnityEngine.SceneManagement.SceneManager.sceneLoaded -= sceneLoadedCallback;
                };
            }
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName.ToString());
        }
    }
}