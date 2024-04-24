using UnityEngine;
using GamesTan.UI;
using CustomInspector;
using System.Collections.Generic;
using UnityEngine.Events;
using System;
using System.Linq;

namespace NoobKnight.Managers
{
    public abstract class BaseSuperScrollView<T> : MonoBehaviour, ISuperScrollRectDataProvider
    {
        #region Variables
        [HorizontalLine("Components")]
        [ForceFill] public SuperScollRect superScollRect;

        [HideInInspector] public bool isDoAwake;

        protected T[] m_datas;
        protected UnityAction<T> m_onClickCallback;
        #endregion

        #region Super Scroll View Methods
        public abstract void SetCell(GameObject cell, int index);

        public void SetupData(T[] datas, UnityAction<T> onClickCallback)
        {
            m_datas = datas;
            m_onClickCallback = onClickCallback;
        }

        public void InitView()
        {
            superScollRect.DoAwake(this);
            isDoAwake = true;
        }

        public void ReloadData() => superScollRect.ReloadData();

        public int GetCellCount()
        {
            if (m_datas == null) return 0;
            return m_datas.Length;
        }

        #endregion
    }
}
