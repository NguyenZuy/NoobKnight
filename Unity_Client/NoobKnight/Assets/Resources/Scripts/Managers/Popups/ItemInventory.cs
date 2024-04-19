using NoobKnight.Tools;
using UnityEngine;
using CustomInspector;
using UnityEngine.UI;

namespace NoobKnight.Managers
{
    public class ItemInventory : MonoBehaviour, IScrollBaseCell<ItemInventoryData>
    {
        #region Vaiables
        [HorizontalLine("Components")]
        [ForceFill] public Image imgIcon;
        #endregion

        #region Abstract Methods
        public void BindData(ItemInventoryData itemCellData)
        {
            imgIcon.sprite = itemCellData.icon;
        }

        public void OnClick()
        {
            
        }
        #endregion
    }
}
