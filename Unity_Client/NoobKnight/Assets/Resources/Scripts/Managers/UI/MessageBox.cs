using CustomInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using MagicTween;

namespace NoobKnight.Managers
{
    public enum Type_MessageBox
    {
        OK,
        OK_CANCEL,
        YES_NO
    }

    public class MessageBox : MonoBehaviour
    {
        #region Variables
        [HorizontalLine("Components")]
        [ForceFill] public TextMeshProUGUI txt_Title;
        [ForceFill] public TextMeshProUGUI txt_Content;
        [ForceFill] public Button btn_Ok;
        [ForceFill] public Button btn_Yes;
        [ForceFill] public Button btn_No;
        [ForceFill] public Button btn_Cancel;

        private UnityAction _yesCallback;
        private UnityAction _noCallback;

        #endregion

        #region Action Methods
        public void Show(Type_MessageBox type_MessageBox, string title, string message, UnityAction yesCallback = null, UnityAction noCallback = null)
        {
            this.gameObject.SetActive(true);

            SetInfo(type_MessageBox, title, message);

            _yesCallback = yesCallback;
            _noCallback = noCallback;

            InittializeSequence(1f, Vector3.one).Play();
        }

        public void SetInfo(Type_MessageBox type_MessageBox, string title, string message)
        {
            ActivateButtons(type_MessageBox);
            txt_Title.text = title;
            txt_Content.text = message;
        }

        void ActivateButtons(Type_MessageBox type_MessageBox)
        {
            btn_Ok.gameObject.SetActive(false);
            btn_Yes.gameObject.SetActive(false);
            btn_No.gameObject.SetActive(false);
            btn_Cancel.gameObject.SetActive(false);

            switch (type_MessageBox)
            {
                case Type_MessageBox.OK:
                    btn_Ok.gameObject.SetActive(true);
                    break;

                case Type_MessageBox.OK_CANCEL:
                    btn_Ok.gameObject.SetActive(true);
                    btn_Cancel.gameObject.SetActive(true);
                    break;
                case Type_MessageBox.YES_NO:
                    btn_Yes.gameObject.SetActive(true);
                    btn_No.gameObject.SetActive(true);
                    break;

                default:
                    Debug.LogError("Unknown message box type");
                    break;
            }
        }

        public void Hide()
        {
            InittializeSequence(0f, Vector3.zero)
                .OnComplete(() => this.gameObject.SetActive(false))
                .Play();
        }
        #endregion

        #region OnClick Methods
        public void OnClickOk() => Hide();

        public void OnClickYes()
        {
            _yesCallback?.Invoke();
            _yesCallback = null;
            Hide();
        }

        public void OnClickNo()
        {
            _noCallback?.Invoke();
            _noCallback = null;
            Hide();
        }
        #endregion

        #region Utils Methods
        public Sequence InittializeSequence(float targetAlpha, Vector3 targetScale)
        {
            float duration = 0.2f;
            Sequence sequence = Sequence.Create();

            var canvasGroup = GetComponent<CanvasGroup>();
            if (canvasGroup == null) canvasGroup = gameObject.AddComponent<CanvasGroup>();

            Tween tween1 = canvasGroup.TweenAlpha(targetAlpha, duration);
            Tween tween2 = transform.TweenLocalScale(targetScale, duration);

            sequence.Join(tween1);
            sequence.Join(tween2);

            return sequence;
        }
        #endregion
    }
}
