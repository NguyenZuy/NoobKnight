using Nakama;
using UnityEngine;
using NoobKnight.Utils;
using NoobKnight.Managers.Nakama;
using CustomInspector;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        #region Common Methods
        public void ConnectToServer()
        {
            client = new Client(nakamaConnection.scheme, nakamaConnection.host, nakamaConnection.port, nakamaConnection.serverKey, UnityWebRequestAdapter.Instance);
            ZuyLogger.Log(ZuyLogger.LogType.Nakama, "Connected to Nakama Server");

            serverHandler = new ServerHandler();
        }

        public async Task<string> CallRpc(string RPCName, string payload)
        {
            var response = await client.RpcAsync(session, RPCName, payload);
            return response.Payload;
        }

        public async Task<T> CallRpc<T>(string RPCName, string payload)
        {
            var response = await client.RpcAsync(session, RPCName, payload);
            return JsonConvert.DeserializeObject<T>(response.Payload);
        }

        #endregion
    }
}
