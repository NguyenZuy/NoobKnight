using NoobKnight.Utils;
using UnityEngine;
using CustomInspector;

namespace NoobKnight.Managers
{
    public class CustomizeAppearanceScrollView : BaseSuperScrollView<int, AppearanceSubtype, ItemCustomizeAppearance>
    {
        #region Variables

        #endregion

        #region Inheritance Methods
        public override void SetCell(GameObject cell, int index)
        {
            var item = cell.GetComponent<ItemCustomizeAppearance>();
            item.BindData(index, m_datas[index], m_subType, m_onClickCallback);
        }
        #endregion
    }
}
