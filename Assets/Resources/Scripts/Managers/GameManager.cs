using CustomInspector;
using UnityEngine;

namespace NoobKnight.Managers
{
    public class GameManager : MonoBehaviour
    {
        #region Variables
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null) _instance = new GameManager();
                return _instance;
            }
        }

        [HorizontalLine("Managers & Internal Objects")]
        [ForceFill] public NetworkManager NetworkManager;
        [ForceFill] public SceneManager SceneManager;

        public GameObject[] objs;

        #endregion

        #region Unity Lifecycle Methods
        private void Awake()
        {
            if (_instance == null) _instance = this;
            else Destroy(this.gameObject);

            foreach (var obj in objs) DontDestroyOnLoad(obj);
        }

        private void Start()
        {
            NetworkManager.ConnectToServer();
        }
        #endregion
    }
}
