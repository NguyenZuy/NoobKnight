using UnityEngine;
using TMPro;
using UnityEngine.UI;
using NoobKnight.Utils;
using NoobKnight.Managers;
using CustomInspector;

namespace NoobKnight.Managers.Popup
{
    public class AuthenticatePopup : Popup
    {
        #region Variables
        [HorizontalLine("Login Attributes")]
        [ForceFill] public TextMeshProUGUI txt_Title;
        [ForceFill] public TMP_InputField ip_Email;
        [ForceFill] public TMP_InputField ip_Password;
        #endregion

        #region OnClick Methods
        public async void OnClickSubmitLogin()
        {
            OnLoginResult(await GameManager.Instance.NetworkManager.serverHandler.AuthenticateEmail(ip_Email.text, ip_Password.text));
        }
        #endregion

        #region Callback Methods
        public void OnLoginResult(bool result)
        {
            if (result)
            {
                Debug.Log(LOG_TYPE.AUTH + "login success");
                SceneManager.ChangeScene(SceneNames.BeginnerVillage);
            }
            else
            {
                Debug.Log(LOG_TYPE.AUTH + "login failed");
            }
        }
        #endregion
    }
}
