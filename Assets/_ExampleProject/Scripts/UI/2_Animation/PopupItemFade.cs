using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ExampleProject.UI.UIAnimation
{

    public class PopupItemFade : PopupItem
    {
        #region Fields

        [BoxGroup("Tween setting"), SerializeField] float showAlpha;
        [BoxGroup("Tween setting"), SerializeField] float hideAlpha;
        [BoxGroup("Tween setting"), SerializeField] Ease easeShow = Ease.Linear;
        [BoxGroup("Tween setting"), SerializeField] Ease easeHide = Ease.Linear;

        Image image;

        #endregion

        #region Properties

        [ShowInInspector] Image ThisImage => image = image != null ? image : GetComponent<Image>();


        #endregion

        #region LifeCycle   



        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public override Tween GetShowTween()
        {
            return ShowTween = ThisImage.DOFade(showAlpha, timeShow).SetEase(easeShow).SetDelay(delayShow);
        }
        public override Tween GetHideTween()
        {
            return HideTween = ThisImage.DOFade(hideAlpha, timeHide).SetEase(easeHide).SetDelay(delayHide);
        }
        public override void HideImmediately()
        {
            Color _tempColor = ThisImage.color;
            _tempColor.a = hideAlpha;
            ThisImage.color = _tempColor;
        }
        public override void ShowImmediately()
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

        #endregion       
    }
}