using NoobKnight.Entities;
using NoobKnight.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoobKnight.Managers
{
    public class CreateCharacterSuperScrollView : BaseSuperScrollView<ItemInventory>
    {
        #region Inheritance Methods
        public override void InitView(params ItemInventory[] items)
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
