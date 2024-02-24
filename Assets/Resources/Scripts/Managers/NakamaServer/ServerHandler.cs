using Nakama;
using System.Threading.Tasks;
using UnityEngine;
using NoobKnight.Managers;

namespace NoobKnight.Managers.Nakama
{
    public class ServerHandler : MonoBehaviour
    {
        public static readonly NetworkManager NetworkManager = GameManager.Instance.NetworkManager;

        public async Task<bool> AuthenticateEmail(string email, string password)
        {
            try
            {
                NetworkManager.session = await NetworkManager.client.AuthenticateEmailAsync(email, password);
                return true;
            }
            catch (ApiResponseException ex)
            {
                Debug.LogFormat("Error authenticating with Email: {0}", ex.Message);
                return false;
            }
        }
    }
}
