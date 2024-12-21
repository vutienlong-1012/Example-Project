using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

namespace ExampleProject.UI.UIAnimation
{
    public class PopupItemMove : PopupItem
    {
        #region Fields

        [BoxGroup("Tween setting"), SerializeField] Vector3 showPos;
        [BoxGroup("Tween setting"), SerializeField] Vector3 hidePos;
        [BoxGroup("Tween setting"), SerializeField] Ease easeShow = Ease.Linear;
        [BoxGroup("Tween setting"), SerializeField] Ease easeHide = Ease.Linear;

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
            return ShowTween = ThisRectTransform.DOAnchorPos(showPos, timeShow).SetEase(easeShow).SetDelay(delayShow);
        }
        public override Tween GetHideTween()
        {
            return HideTween = ThisRectTransform.DOAnchorPos(hidePos, timeHide).SetEase(easeHide).SetDelay(delayHide);
        }
        public override void HideImmediately()
        {
            ThisRectTransform.anchoredPosition = hidePos;
        }
        public override void ShowImmediately()
        {
            ThisRectTransform.anchoredPosition = showPos;
        }
        public override void SetThisAsShow()
        {
            showPos = ThisRectTransform.anchoredPosition;
        }
        public override void SetThisAsHide()
        {
            hidePos = ThisRectTransform.anchoredPosition;
        }

        #endregion       
    }
}