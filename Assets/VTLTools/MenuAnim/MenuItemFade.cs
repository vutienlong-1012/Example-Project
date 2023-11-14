using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace VTLTools.UIAnimation
{
    public class MenuItemFade : MenuItem
    {
        [Button, BoxGroup("Tween setting"), SerializeField] float showAlpha;
        [Button, BoxGroup("Tween setting"), SerializeField] float hideAlpha;
        [Button, BoxGroup("Tween setting"), SerializeField] Ease easeShow = Ease.Linear;
        [Button, BoxGroup("Tween setting"), SerializeField] Ease easeHide = Ease.Linear;

        Image image;
        [ShowInInspector]
        Image ThisImage
        {
            get
            {
                if (image is null)
                    image = GetComponent<Image>();
                return image;
            }
        }

        private void Start()
        { 
            SetShowTween();
            SetHideTween();
        }

        public override void SetShowTween()
        {
            ShowTween = ThisImage.DOFade(showAlpha, timeShow).SetEase(easeShow).SetDelay(delayShow);
        }

        public override void SetHideTween()
        {

            HideTween = ThisImage.DOFade(hideAlpha, timeHide).SetEase(easeHide).SetDelay(delayHide);
        }

        public override void HideImidiatly()
        {
            Color _tempColor = ThisImage.color;
            _tempColor.a = hideAlpha;
            ThisImage.color = _tempColor;
        }

        public override void ShowImnidiately()
        {
            Color _tempColor = ThisImage.color;
            _tempColor.a = showAlpha;
            ThisImage.color = _tempColor;
        }

        public override void SetThisAsShow()
        {
            showAlpha = ThisImage.color.a;
        }

        public override void SetThisAsHide()
        {
            hideAlpha = ThisImage.color.a;
        }
    }
}