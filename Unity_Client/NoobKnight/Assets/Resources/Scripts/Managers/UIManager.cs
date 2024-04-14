using UnityEngine;
using NoobKnight.Utils;
using CustomInspector;
using NoobKnight.Managers.Popups;
using UnityEngine.Events;

namespace NoobKnight.Managers
{
    public class UIManager : MonoBehaviour
    {
        #region Variables
        [HorizontalLine("Attributes")]
        [ForceFill] public GameObject popupsContainer;
        [ForceFill] public GameObject loadingCircle;
        [ForceFill] public GameObject messageBox;
        
        [SerializeField, ReadOnly] [Dictionary] private SerializableDictionary<string, Popup> popupsDict = new SerializableDictionary<string, Popup>();

        [ReadOnly] public Popup previousPopup;
        [ReadOnly] public Popup currentPopup;
        #endregion

        private void Start()
        {
            try
            {
                foreach (Transform child in popupsContainer.transform)
                {
                    popupsDict.Add(child.name, child.GetComponent<Popup>());
                    if (child.name == PopupNames.IntroPopup.ToString())
                    {
                        currentPopup = child.GetComponent<Popup>();
                        continue;
                    }
                    child.GetComponent<CanvasGroup>().alpha = 0f;
                    child.transform.localScale = Vector3.zero;
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("An error occurred while adding popups to the dictionary: " + e.Message);
            }

            messageBox.GetComponent<CanvasGroup>().alpha = 0f;
            messageBox.transform.localScale = Vector3.zero;
        }

        #region Popups Methods
        public void ShowPopup(PopupNames popupName, object parameter = null)
        {
            var popup = GetPopup(popupName);
            popup.transform.SetSiblingIndex(popupsContainer.transform.childCount - 1);
            popup.Show();

            if (previousPopup != null)
                if (!previousPopup.canBack)
                {
                    HidePopup(previousPopup);
                    previousPopup = null;
                }
            if (currentPopup != null)
            {
                if (!currentPopup.canBack) HidePopup(currentPopup);
                else previousPopup = currentPopup;
            }
            currentPopup = popup;
        }

        public void HidePopup(PopupNames popupName)
        {
            var popup = GetPopup(popupName);
            popup.Hide();

            if(previousPopup != null)
            {
                currentPopup = previousPopup;
                previousPopup = null;
            }
        }

        public void HidePopup(Popup popup)
        {
            popup.Hide();
        }

        public Popup GetPopup(PopupNames popupName)
        {
            // Convert the PopupNames enumeration to a string
            string popupKey = popupName.ToString();

            // Check if the key exists in the dictionary
            if (popupsDict.TryGetValue(popupKey, out Popup popup))
            {
                return popup;
            }
            else
            {
                // Handle the case when the specified popup name is not found
                Debug.LogError("Popup with name " + popupKey + " not found.");
                return null;
            }
        }
        #endregion

        #region Loading Methods
        public void ShowLoadingCircle()
        {
            loadingCircle.SetActive(true);
        }

        public void HideLoadingCircle()
        {
            loadingCircle.SetActive(false);
        }
        #endregion

        #region Message Box Methods
        public void ShowMessageBox(Type_MessageBox type_MessageBox, string title, string message, UnityAction yesCallback = null, UnityAction noCallback = null)
        {
            messageBox.GetComponent<MessageBox>().Show(type_MessageBox, title, message, yesCallback, noCallback);
        }
        #endregion
    }
}
