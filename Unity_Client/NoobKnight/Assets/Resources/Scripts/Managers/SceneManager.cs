using NoobKnight.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace NoobKnight.Managers
{
    public class SceneManager : MonoBehaviour
    {
        #region Variables
        public int curGateID; // Convention 0 is default
        #endregion

        #region Common Methods
        public void ChangeScene(SceneNames sceneName, UnityAction<UnityEngine.SceneManagement.Scene, LoadSceneMode> sceneLoadedCallback = null)
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
        #endregion
    }
}