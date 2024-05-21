using CustomInspector;
using Nakama;
using Newtonsoft.Json;
using NoobKnight.Entities;
using NoobKnight.Managers.Character;
using NoobKnight.Utils;
using System;
using TMPro;

namespace NoobKnight.Managers.Popups
{
    public class CreateCharacterPopup : BasePopup
    {
        #region Variables
        [HorizontalLine("Components")]
        [ForceFill] public CustomizeAppearance customizeAppearance;
        [ForceFill] public CharacterPreview characterPreview;
        [ForceFill] public TMP_InputField ip_DisplayName;

        private PlayerCharacterData _rawPlayerCharacterData;
        #endregion

        #region Inheritance Methods
        protected override void OnShowing()
        {
            base.OnShowing();

            _rawPlayerCharacterData = Tools.DeepCopy<PlayerCharacterData>(GameManager.Instance.playerDataManager.playerCharacterData);

            characterPreview.gameObject.SetActive(true);

            customizeAppearance.OnChangeAppearance += characterPreview.OnChangeAppearance;
            customizeAppearance.OnChangeAppearance += OnChangeAppearance;
            customizeAppearance.OnChangeGender += characterPreview.OnChangeGender;

            customizeAppearance.SetupData(GameManager.Instance.playerDataManager.playerInventoryData.appearanceInventoryData);

            characterPreview.ReloadChacracter(_rawPlayerCharacterData);
        }

        protected override void OnHiding()
        {
            base.OnHiding();

            characterPreview.gameObject.SetActive(false);
        }
        #endregion

        #region OnClick Methods
        public void OnClickSubmitCreateCharacter()
        {
            GameManager.Instance.UIManager.ShowMessageBox(Type_MessageBox.YES_NO, "Warning", $"You are sure you want to set {ip_DisplayName.text} as your name", OnClickOKSubmitCreateCharacter);
        }

        private async void OnClickOKSubmitCreateCharacter()
        {
            NetworkManager networkManager = GameManager.Instance.networkManager;
            string displayName = ip_DisplayName.text;
            try
            {
                await networkManager.client.UpdateAccountAsync(networkManager.session, displayName, displayName); // In this case i use display name for both username and displayname
                var userMetadata = new UserMetadata()
                {
                    playerCharacterData = _rawPlayerCharacterData
                };
                GameManager.Instance.playerDataManager.playerCharacterData = (await networkManager.CallRpc<UserMetadata>(NakamaConstant.RPCNames.UPDATE_USER_METADATA, JsonConvert.SerializeObject(userMetadata))).playerCharacterData;
                GameManager.Instance.sceneManager.curGateID = 0;
                GameManager.Instance.charactersManager.localPlayer.RefreshCharacter();
                GameManager.Instance.sceneManager.ChangeScene(SceneNames.BeginnerVillage);
                GameManager.Instance.UIManager.HidePopup(PopupNames.CreateCharacterPopup);
            }
            catch (Exception ex)
            {
                ZuyLogger.LogError(ZuyLogger.LogType.Nakama, "Error when submit dislay name for new account: " + ex);
            }
        }
        #endregion

        #region Callback Methods
        public void OnChangeAppearance(int ID, AppearanceSubtype typeForCustomize)
        {
            _rawPlayerCharacterData.appearanceData.UpdateData(ID, typeForCustomize);
        }
        #endregion
    }
}
