using Nakama;
using System.Threading.Tasks;
using UnityEngine;
using NoobKnight.Managers;
using Nakama.TinyJson;

namespace NoobKnight.Managers.Nakama
{
    public class ServerHandler
    {
        public static readonly NetworkManager NetworkManager = GameManager.Instance.networkManager;

        public async Task<IApiAccount> AuthenticateDeviceId()
        {
            try
            {
                NetworkManager.session = await NetworkManager.client.AuthenticateDeviceAsync(System.Guid.NewGuid().ToString());
                var account = await NetworkManager.client.GetAccountAsync(NetworkManager.session);
                return account;
            }
            catch (ApiResponseException ex)
            {
                Debug.LogFormat("Error authenticating with Email: {0}", ex.Message);
                return null;
            }
        }

        public async Task<IApiAccount> AuthenticateEmail(string email, string password, bool isRegister = false)
        {
            try
            {
                NetworkManager.session = await NetworkManager.client.AuthenticateEmailAsync(email, password, "", isRegister);
                var account = await NetworkManager.client.GetAccountAsync(NetworkManager.session);
                return account;
            }
            catch (ApiResponseException ex)
            {
                Debug.LogFormat("Error authenticating with Email: {0}", ex.Message);
                return null;
            }
        }
    }
}
