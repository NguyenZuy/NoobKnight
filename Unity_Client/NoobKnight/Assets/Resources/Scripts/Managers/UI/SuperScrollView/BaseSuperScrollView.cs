using UnityEngine;
using GamesTan.UI;
using CustomInspector;
using System.Collections.Generic;

namespace NoobKnight.Tools
{
    public abstract class BaseSuperScrollView<T> : MonoBehaviour, ISuperScrollRectDataProvider
    {
        #region Variables
        [HorizontalLine("Components")]
        [ForceFill] public SuperScollRect superScollRect;

        protected List<T> _datas = new List<T>();
        #endregion 

        #region Super Scroll View Methods
        public virtual void InitView(params T[] items)
        {
            superScollRect.DoAwake(this);
        }

        public abstract void SetCell(GameObject cell, int index);

        public virtual void ReloadData() => superScollRect.ReloadData();

        public int GetCellCount()
        {
            return _datas.Count;
        }

        #endregion
    }
}
