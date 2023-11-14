using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

namespace VTLTools.UIAnimation
{
    public class MenuItemMove : MenuItem
    {
        [Button, BoxGroup("Tween setting"), SerializeField] Vector3 showPos;
        [Button, BoxGroup("Tween setting"), SerializeField] Vector3 hidePos;
        [Button, BoxGroup("Tween setting"), SerializeField] Ease easeShow = Ease.Linear;
        [Button, BoxGroup("Tween setting"), SerializeField] Ease easeHide = Ease.Linear;

        RectTransform rectTransform;
        [ShowInInspector]
        RectTransform ThisRectTransform
        {
            get
            {
                if (rectTransform is null)
                    rectTransform = GetComponent<RectTransform>();
                return rectTransform;
            }
        }

        public override Tween GetShowTween()
        {
            ShowTween = ThisRectTransform.DOAnchorPos(showPos, timeShow).SetEase(easeShow).SetDelay(delayShow);
            return ShowTween;
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
    }
}