using UnityEngine;
using CustomInspector;
using UnityEngine.UI;
using NoobKnight.Utils;
using UnityEngine.Events;

namespace NoobKnight.Managers
{
    public class ItemCustomizeAppearance : MonoBehaviour
    {
        #region Variables
        [HorizontalLine("Components")]
        [ForceFill] public Image imgIcon;

        [HideInInspector] public int ID;

        private UnityAction<int> _onClickCallback;
        #endregion

        public void BindData(int ID, UnityAction<int> onClickCallback)
        {
            this.ID = ID;
            this._onClickCallback = onClickCallback;

            imgIcon.sprite = GameManager.Instance.ResourceManager.GetSpriteByID(ID, Direction.Front);
        }

        public void OnClickThisItem()
        {
            _onClickCallback?.Invoke(ID);
        }
    }
}
