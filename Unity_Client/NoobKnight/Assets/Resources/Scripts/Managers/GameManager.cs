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
        [ForceFill] public NetworkManager networkManager;
        [ForceFill] public SceneManager sceneManager;
        [ForceFill] public UIManager UIManager;
        [ForceFill] public PlayerDataManager playerDataManager;
        [ForceFill] public ResourceManager resourceManager;
        [ForceFill] public CharactersManager charactersManager;

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
            networkManager.ConnectToServer();
        }
        #endregion
    }
}
