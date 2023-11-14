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
                if (rectTransform == null)
                    rectTransform = GetComponent<RectTransform>();
                return rectTransform;
            }
        }

        public override void StartShow()
        {
            if (!this.gameObject.activeSelf)
                return;
            ThisRectTransform.localScale = hideScale;
            ThisRectTransform.DOScale(showScale, timeShow).SetEase(easeShow).SetDelay(delayShow);
        }

        public override void StartHide()
        {
            if (!this.gameObject.activeSelf)
                return;
            ThisRectTransform.DOScale(hideScale, timeHide).SetEase(easeHide).SetDelay(delayHide);
        }

        public override void PreviewHide()
        {
            ThisRectTransform.localScale = hideScale;
        }

        public override void PreviewShow()
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
