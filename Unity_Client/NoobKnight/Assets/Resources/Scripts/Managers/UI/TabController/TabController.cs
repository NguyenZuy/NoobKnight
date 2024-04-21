using UnityEngine;
using CustomInspector;
using System;
using UnityEngine.UI;

namespace NoobKnight.Utils 
{
    public class TabController : MonoBehaviour
    {
        #region Variables
        [HorizontalLine("Custom Parameters")]

        public bool isChangeColor;
        [ShowIf(nameof(isChangeColor))] public Color32 selectColor;
        [ShowIf(nameof(isChangeColor))] public Color32 deselectColor;

        public bool isChangeSprite;
        [ShowIf(nameof(isChangeSprite))] public Sprite selectSprite;
        [ShowIf(nameof(isChangeSprite))] public Sprite deselectSprite;

        public bool isChangeText;
        [ShowIf(nameof(isChangeText))] public String selectText;
        [ShowIf(nameof(isChangeText))] public String deselectText;

        private Tab[] _tabs;

        private int _curSelectTabIndex = -1;
        private Action<int> _tabSelectCallback = null;
        #endregion

        #region Unity Lifecycle Methods
        private void Awake()
        {
            _tabs = GetComponentsInChildren<Tab>();
            for(int i = 0; i < _tabs.Length; i++)
            {
                _tabs[i].GetComponent<Button>().onClick.AddListener(() => OnClickSelectTab(i));
            }
        }
        #endregion

        #region Tabs Methods
        public void SetTabSelectCallback(Action<int> callback) => _tabSelectCallback = callback;

        public void SetSelect(Tab tab)
        {
            if (isChangeColor) tab.imgToChangeColor.color = selectColor;
            if (isChangeSprite) tab.imgToChangeColor.sprite = selectSprite;
            if (isChangeText) tab.txtToChangeText.text = selectText;
        }

        public void SetDeselect(Tab tab)
        {
            if (isChangeColor) tab.imgToChangeColor.color = deselectColor;
            if (isChangeSprite) tab.imgToChangeColor.sprite = deselectSprite;
            if (isChangeText) tab.txtToChangeText.text = deselectText;
        }
        #endregion

        #region OnClick Methods
        public void OnClickSelectTab(int index)
        {
            if (_curSelectTabIndex >= 0)
            {
                SetSelect(_tabs[index]);
                SetDeselect(_tabs[_curSelectTabIndex]);
            }

            _curSelectTabIndex = index;
            _tabSelectCallback?.Invoke(index);
        }
        #endregion
    }
}
