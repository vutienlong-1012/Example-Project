using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

namespace VTLTools.UIAnimation
{
    public class MenuItemScale : MenuItem
    {
        [Button, BoxGroup("Tween setting"), SerializeField] Vector3 showScale;
        [Button, BoxGroup("Tween setting"), SerializeField] Vector3 hideScale;
        [Button, BoxGroup("Tween setting"), SerializeField] AnimationCurve easeShow;
        [Button, BoxGroup("Tween setting"), SerializeField] AnimationCurve easeHide;

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

        public override void SetShowTween()
        {
            ShowTween = ThisRectTransform.DOScale(showScale, timeShow).SetEase(easeShow).SetDelay(delayShow);
        }

        public override void SetHideTween()
        {
            HideTween = ThisRectTransform.DOScale(hideScale, timeHide).SetEase(easeHide).SetDelay(delayHide);
        }

        public override void HideImidiatly()
        {
            ThisRectTransform.localScale = hideScale;
        }

        public override void ShowImnidiately()
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
    }
}
