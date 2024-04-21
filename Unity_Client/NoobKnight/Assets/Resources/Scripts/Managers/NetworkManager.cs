using Nakama;
using UnityEngine;
using NoobKnight.Utils;
using NoobKnight.Managers.Nakama;
using CustomInspector;

namespace NoobKnight.Managers
{
    public class NetworkManager : MonoBehaviour
    {
        #region Variables
        public IClient client;
        public ISession session;
        public ISocket socket;

        [ForceFill] public NakamaConnection nakamaConnection;

        [HideInInspector] public ServerHandler serverHandler;

        #endregion

        public void ConnectToServer()
        {
            client = new Client(nakamaConnection.scheme, nakamaConnection.host, nakamaConnection.port, nakamaConnection.serverKey, UnityWebRequestAdapter.Instance);
            ZuyLogger.Log(LOG_TYPE.NAKAMA, "Connected to Nakama Server");

            serverHandler = new ServerHandler();
        }

    }
}
