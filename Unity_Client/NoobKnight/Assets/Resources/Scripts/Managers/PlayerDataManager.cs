using Nakama;
using Newtonsoft.Json;
using NoobKnight.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace NoobKnight.Managers
{
    [Serializable]
    public class PlayerDataManager : MonoBehaviour
    {
        #region Variables
        public PlayerAuthenticateData playerAuthenticateData = new PlayerAuthenticateData();
        public PlayerCharacterData playerCharacterData = new PlayerCharacterData();
        public PlayerInventoryData playerInventoryData = new PlayerInventoryData();

        public bool isLocal;
        public bool isOnline;
        #endregion

        public async void InitializeData(IApiAccount account)
        {
            isLocal = true;
            isOnline = true;

            playerAuthenticateData.InitializeData(account);

            // Get UserMetadata
            var userMetadata = JsonConvert.DeserializeObject<UserMetadata>(account.User.Metadata);
            playerCharacterData = userMetadata.playerCharacterData;

            // Get PlayerInventoryData Data
            ISession session = GameManager.Instance.networkManager.session;
            IClient client = GameManager.Instance.networkManager.client;

            var listStorage = await client.ListUsersStorageObjectsAsync(session, "Inventory", session.UserId, 3);
            foreach (var storageObject in listStorage.Objects)
            {
                switch (storageObject.Key)
                {
                    case "Appearance":
                        playerInventoryData.appearanceInventoryData = JsonConvert.DeserializeObject<PlayerInventoryData.AppearanceInventoryData>(storageObject.Value);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
