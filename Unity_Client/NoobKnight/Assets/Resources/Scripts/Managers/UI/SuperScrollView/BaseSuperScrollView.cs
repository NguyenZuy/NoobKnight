using UnityEngine;
using GamesTan.UI;
using CustomInspector;
using System.Collections.Generic;

namespace NoobKnight.Managers
{
    public abstract class BaseSuperScrollView<T> : MonoBehaviour, ISuperScrollRectDataProvider
    {
        #region Variables
        [HorizontalLine("Components")]
        [ForceFill] public SuperScollRect superScollRect;

        protected T[] _datas;
        #endregion

        #region Super Scroll View Methods
        public abstract void SetCell(GameObject cell, int index);

        public void SetupData(T[] datas)
        {
            _datas = datas;
        }

        public void InitView()
        {
            superScollRect.DoAwake(this);
        }

        public void ReloadData() => superScollRect.ReloadData();

        public int GetCellCount()
        {
            return _datas.Length;
        }

        #endregion
    }
}
