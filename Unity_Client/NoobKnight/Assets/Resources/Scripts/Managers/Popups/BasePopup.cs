using UnityEngine;
using MagicTween;
using CustomInspector;

namespace NoobKnight.Managers.Popups
{
    public abstract class BasePopup : MonoBehaviour
    {
        [HorizontalLine("Popup Components")]
        public bool canBack;

        protected object m_Parameter;

        #region Action Methods
        public void Show(object parameter = null)
        {
            InittializeSequence(1f, Vector3.one)
                    .OnStart(() =>
                    {
                        OnShowing();
                        m_Parameter = parameter;
                    })
                    .OnComplete(() => OnShown())
                    .Play();
        }

        public void Hide()
        {
            InittializeSequence(0f, Vector3.zero)
                    .OnStart(() => OnHiding())
                    .OnComplete(() => OnHidden())
                    .Play();
        }
        #endregion

        #region Popup Lifecirle Methods
        protected virtual void OnShowing()
        {
            this.gameObject.SetActive(true);
            this.transform.SetSiblingIndex(this.transform.parent.transform.childCount - 1);
        }

        protected virtual void OnShown()
        {

        }

        protected virtual void OnHiding()
        {

        }

        protected virtual void OnHidden()
        {
            if (!canBack) this.gameObject.SetActive(false);
        }
        #endregion

        #region Utils Methods
        public Sequence InittializeSequence(float targetAlpha, Vector3 targetScale)
        {
            float duration = 0.2f;

            Sequence sequence = Sequence.Create();

            Tween tween1 = this.GetComponent<CanvasGroup>().TweenAlpha(targetAlpha, duration);
            Tween tween2 = this.transform.TweenLocalScale(targetScale, duration);

            sequence.Join(tween1);
            sequence.Join(tween2);

            return sequence;
        }
        #endregion
    }
}
