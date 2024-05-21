using CustomInspector;
using Nakama;
using NoobKnight.Utils;
using TMPro;
using UnityEngine;

namespace NoobKnight.Managers.Popups
{
    public class AuthenticatePopup : BasePopup
    {
        #region Variables
        [HorizontalLine("Forms")]
        [ForceFill] public GameObject loginForm;
        [ForceFill] public GameObject registerForm;

        [HorizontalLine("Login Form Components")]
        [ForceFill] public TMP_InputField ip_EmailLogin;
        [ForceFill] public TMP_InputField ip_PasswordLogin;

        [HorizontalLine("Register Form Components")]
        [ForceFill] public TMP_InputField ip_EmailRegister;
        [ForceFill] public TMP_InputField ip_PasswordRegister;
        [ForceFill] public TMP_InputField ip_RePasswordRegister;
        #endregion

        #region Inheritance Methods
        protected override void OnShowing()
        {
            base.OnShowing();
            ResetUI();
        }
        #endregion

        #region UI Methods
        public void ResetUI()
        {
            OnClickSwitchForm(true);
            ClearInputFields(ip_EmailLogin, ip_PasswordLogin, ip_EmailRegister, ip_PasswordRegister, ip_RePasswordRegister);
        }

        private void ClearInputFields(params TMP_InputField[] fields)
        {
            foreach (var field in fields)
            {
                field.text = "";
            }
        }
        #endregion

        #region OnClick Methods
        public async void OnClickSubmitLogin()
        {
            GameManager.Instance.UIManager.ShowLoadingCircle();
            var account = await GameManager.Instance.networkManager.serverHandler.AuthenticateEmail(ip_EmailLogin.text, ip_PasswordLogin.text);
            OnLoginResultAsync(account);
        }

        public async void OnClickSubmitRegister()
        {
            GameManager.Instance.UIManager.ShowLoadingCircle();
            var account = await GameManager.Instance.networkManager.serverHandler.AuthenticateEmail(ip_EmailRegister.text, ip_PasswordRegister.text, true);
            OnRegisterResult(account);
        }

        public void OnClickSwitchForm(bool isLogin)
        {
            loginForm.SetActive(isLogin);
            registerForm.SetActive(!isLogin);
        }
        #endregion

        #region Callback Methods
        public async void OnLoginResultAsync(IApiAccount account)
        {
            if (account != null)
            {
                GameManager.Instance.playerDataManager.InitializeData(account);

                ZuyLogger.Log(ZuyLogger.LogType.Authentication, "login success with ID: " + account.User.Id);
                GameManager.Instance.UIManager.HidePopup(PopupNames.AuthenticatePopup);

                await GameManager.Instance.resourceManager.LoadResourcesAsync();
                
                GameManager.Instance.sceneManager.ChangeScene(SceneNames.BeginnerVillage, (scene, mode) =>
                {
                    GameManager.Instance.charactersManager.localPlayer.ToggleActive(true);
                });

                if(string.IsNullOrEmpty(account.User.DisplayName))
                    GameManager.Instance.UIManager.ShowPopup(PopupNames.CreateCharacterPopup);
            }
            else
            {
                GameManager.Instance.UIManager.ShowMessageBox(Type_MessageBox.OK, "Error", "Login Failed, Please Try Again!!!");
            }
            GameManager.Instance.UIManager.HideLoadingCircle();
        }

        public void OnRegisterResult(IApiAccount account)
        {
            if (account != null)
            {
                ZuyLogger.Log(ZuyLogger.LogType.Authentication, "register success with ID: " + account.User.Id);
                OnClickSwitchForm(true);
                ip_EmailLogin.text = account.Email;
                ClearInputFields(ip_PasswordLogin);
            }
            else
            {
                GameManager.Instance.UIManager.ShowMessageBox(Type_MessageBox.OK, "Error", "Register Failed, Please Try Again!!!");
            }
            GameManager.Instance.UIManager.HideLoadingCircle();
        }
        #endregion
    }
}
