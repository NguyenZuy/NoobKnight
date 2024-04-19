using UnityEngine;
using NoobKnight.Utils;
using CustomInspector;
using NoobKnight.Managers.Popups;
using UnityEngine.Events;
using System.Collections.Generic;

namespace NoobKnight.Managers
{
    public class UIManager : MonoBehaviour
    {
        #region Variables
        [HorizontalLine("Components")]
        [ForceFill] public GameObject popupsContainer;
        [ForceFill] public GameObject loadingCircle;
        [ForceFill] public GameObject messageBox;

        private Dictionary<string, BasePopup> popupsDict = new Dictionary<string, BasePopup>();

        public BasePopup PreviousPopup { get; private set; }
        public BasePopup CurrentPopup { get; private set; }
        #endregion

        #region Unity Lifecycle Methods
        private void Start()
        {
            InitializePopups();
            InitializeMessageBox();
        }
        #endregion

        #region Popups Methods
        private void InitializePopups()
        {
            foreach (Transform child in popupsContainer.transform)
            {
                var popup = child.GetComponent<BasePopup>();
                if (popup == null) continue; // Skip if Popup component is missing

                popupsDict[child.name] = popup; // Use assignment for add or update

                if (child.name == PopupNames.IntroPopup.ToString())
                {
                    CurrentPopup = popup;
                    continue;
                }

                SetPopupVisibility(popup, false);
            }
        }

        private void SetPopupVisibility(BasePopup popup, bool isVisible)
        {
            var canvasGroup = popup.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.alpha = isVisible ? 1f : 0f;
                popup.transform.localScale = isVisible ? Vector3.one : Vector3.zero;
            }
        }

        public void ShowPopup(PopupNames popupName, object parameter = null)
        {
            if (!popupsDict.TryGetValue(popupName.ToString(), out var popup)) return;

            popup.transform.SetAsLastSibling();
            SetPopupVisibility(popup, true);

            if (PreviousPopup != null && !PreviousPopup.canBack)
            {
                SetPopupVisibility(PreviousPopup, false);
                PreviousPopup = null;
            }

            if (CurrentPopup != null)
            {
                if (!CurrentPopup.canBack) SetPopupVisibility(CurrentPopup, false);
                else PreviousPopup = CurrentPopup;
            }

            CurrentPopup = popup;
        }

        public void HidePopup(PopupNames popupName)
        {
            if (!popupsDict.TryGetValue(popupName.ToString(), out var popup)) return;

            SetPopupVisibility(popup, false);

            if (PreviousPopup != null)
            {
                CurrentPopup = PreviousPopup;
                PreviousPopup = null;
            }
        }

        public void HidePopup(BasePopup popup)
        {
            SetPopupVisibility(popup, false);
        }
        #endregion

        #region Loading Methods
        public void ShowLoadingCircle() => loadingCircle.SetActive(true);

        public void HideLoadingCircle() => loadingCircle.SetActive(false);
        #endregion

        #region Message Box Methods

        private void InitializeMessageBox()
        {
            SetPopupVisibility(messageBox.GetComponent<BasePopup>(), false);
        }

        public void ShowMessageBox(Type_MessageBox type_MessageBox, string title, string message, UnityAction yesCallback = null, UnityAction noCallback = null)
        {
            var messageBoxComponent = messageBox.GetComponent<MessageBox>();
            if (messageBoxComponent != null)
            {
                messageBoxComponent.Show(type_MessageBox, title, message, yesCallback, noCallback);
            }
        }
        #endregion
    }
}