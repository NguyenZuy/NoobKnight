using NoobKnight.Entities;
using NoobKnight.Utils;

namespace NoobKnight.Managers
{
    public class PlayerDataManager : BaseSingleton<PlayerDataManager>
    {
        #region Variables
        public PlayerAuthenticateData playerAuthenticateData = new PlayerAuthenticateData();
        #endregion
    }
}
