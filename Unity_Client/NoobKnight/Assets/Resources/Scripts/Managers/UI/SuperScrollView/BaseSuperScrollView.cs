using UnityEngine;
using GamesTan.UI;
using CustomInspector;
using System.Collections.Generic;
using UnityEngine.Events;
using System;
using System.Linq;

namespace NoobKnight.Managers
{
    public abstract class BaseSuperScrollView<T, T1, T2> : MonoBehaviour, ISuperScrollRectDataProvider
    {
        #region Variables
        [HorizontalLine("Components")]
        [ForceFill] public SuperScollRect superScollRect;

        [HideInInspector] public bool isDoAwake;

        protected T[] m_datas;
        protected T1 m_subType;
        protected UnityAction<T2> m_onClickCallback;
        #endregion

        #region Super Scroll View Methods
        public abstract void SetCell(GameObject cell, int index);

        public void SetupData(T[] datas, T1 subType, UnityAction<T2> onClickCallback)
        {
            m_datas = datas;
            m_subType = subType;
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
