using NoobKnight.Managers.Popups;
using NoobKnight.Utils;

namespace NoobKnight.Managers
{
    public class IntroPopup : Popup
    {
        #region Variables
        #endregion

        #region Inheritance Methods
        #endregion

        #region OnClick Methods
        public void OnClickStartGame()
        {
            GameManager.Instance.UIManager.ShowPopup(PopupNames.AuthenticatePopup);
        }
        #endregion
    }
}
