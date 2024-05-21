using Nakama;
using System;

namespace NoobKnight.Entities 
{
    [Serializable]
    public class PlayerAuthenticateData
    {
        public string ID;
        public string email;
        public string username;

        public void InitializeData(IApiAccount account)
        {
            this.ID = account.User.Id;
            this.email = account.Email;
            this.username = account.User.Username;
        }
    }
}
