using UnityEngine;
using CustomInspector;
using UnityEngine.UI;
using NoobKnight.Utils;
using UnityEngine.Events;
using NoobKnight.Managers.Popups;

namespace NoobKnight.Managers
{
    public class ItemCustomizeAppearance : MonoBehaviour
    {
        #region Variables
        [HorizontalLine("Components")]
        [ForceFill] public Image imgIcon;

        [HideInInspector] public int index;
        [HideInInspector] public int ID;

        private UnityAction<ItemCustomizeAppearance> _onClickCallback;
        #endregion

        public void BindData(int index, int ID, AppearanceSubtype subType, UnityAction<ItemCustomizeAppearance> onClickCallback)
        {
            this.index = index;
            this.ID = ID;
            this._onClickCallback = onClickCallback;

            if (ID != -99)
                imgIcon.sprite = GameManager.Instance.resourceManager.GetSpriteByID(ID, Direction.Front);
            else
                imgIcon.sprite = GameManager.Instance.resourceManager.GetSpriteUIByName("Icon_None");

            bool isUsing = GameManager.Instance.playerDataManager.playerCharacterData.appearanceData.IsUsing(ID, subType);
            this.GetComponent<Button>().interactable = !isUsing;
            if (isUsing)
                GameManager.Instance.UIManager.GetCurrentPopup<CreateCharacterPopup>().customizeAppearance.curItemCustomizeAppearance = this;
        }

        public void OnClickThisItem()
        {
            _onClickCallback?.Invoke(this);
        }
    }
}
