using CustomInspector;
using NoobKnight.Utils;
using System.Threading.Tasks;
using UnityEngine;

namespace NoobKnight.Managers
{
    public class GameManager : BaseSingleton<GameManager>
    {
        #region Variables
        [HorizontalLine("Managers & Internal Objects")]
        [ForceFill] public NetworkManager NetworkManager;
        [ForceFill] public SceneManager SceneManager;
        [ForceFill] public UIManager UIManager;
        [ForceFill] public PlayerDataManager PlayerDataManager;
        [ForceFill] public ResourceManager ResourceManager;

        public GameObject[] objs;

        #endregion

        #region Inheritance Methods
        protected override void Awake()
        {
            base.Awake();
            foreach (var obj in objs) DontDestroyOnLoad(obj);
        }
        #endregion

        #region Unity Lifecycle Methods
        private void Start()
        {
            NetworkManager.ConnectToServer();
        }
        #endregion
    }
}
