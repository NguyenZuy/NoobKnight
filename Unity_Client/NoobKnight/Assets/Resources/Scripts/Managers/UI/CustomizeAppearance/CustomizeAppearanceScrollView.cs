using NoobKnight.Tools;
using UnityEngine;
using CustomInspector;

namespace NoobKnight.Managers
{
    public class CustomizeAppearanceScrollView : BaseSuperScrollView<ItemCustomizeAppearance>
    {
        #region Variables

        #endregion

        #region Inheritance Methods
        public override void InitView(params ItemCustomizeAppearance[] items)
        {
            base.InitView(items);

            superScollRect.DoAwake(this);
        }

        public override void SetCell(GameObject cell, int index)
        {

        }
        #endregion
    }
}
