using NoobKnight.Tools;
using UnityEngine;
using CustomInspector;

namespace NoobKnight.Managers
{
    public class CustomizeAppearanceScrollView : BaseSuperScrollView<int>
    {
        #region Variables

        #endregion

        #region Inheritance Methods
        public override void InitView(params int[] items)
        {
            base.InitView(items);

            superScollRect.DoAwake(this);
        }

        public override void SetCell(GameObject cell, int index)
        {
            var item = cell.GetComponent<ItemCustomizeAppearance>();
            item.BindData(_datas[index]);
        }
        #endregion
    }
}
