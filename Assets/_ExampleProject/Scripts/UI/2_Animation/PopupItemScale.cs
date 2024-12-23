using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

namespace ExampleProject.UI.UIAnimation
{
    public class PopupItemScale : PopupItem
    {
        #region Fields

        [BoxGroup("Tween setting"), SerializeField] Vector3 showScale;
        [BoxGroup("Tween setting"), SerializeField] Vector3 hideScale;
        [BoxGroup("Tween setting"), SerializeField] AnimationCurve easeShow;
        [BoxGroup("Tween setting"), SerializeField] AnimationCurve easeHide;

        RectTransform rectTransform;

        #endregion

        #region Properties

        [ShowInInspector] RectTransform ThisRectTransform => rectTransform = rectTransform != null ? rectTransform : GetComponent<RectTransform>();

        #endregion

        #region LifeCycle   



        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public override Tween GetShowTween()
        {
            return ShowTween = ThisRectTransform.DOScale(showScale, timeShow).SetEase(easeShow).SetDelay(delayShow);
        }
        public override Tween GetHideTween()
        {
            return HideTween = ThisRectTransform.DOScale(hideScale, timeHide).SetEase(easeHide).SetDelay(delayHide);
        }
        public override void HideImmediately()
        {
            ThisRectTransform.localScale = hideScale;
        }
        public override void ShowImmediately()
        {
            ThisRectTransform.localScale = showScale;
        }
        public override void SetThisAsShow()
        {
            showScale = ThisRectTransform.localScale;
        }
        public override void SetThisAsHide()
        {
            hideScale = ThisRectTransform.localScale;
        }

        #endregion
    }
}
