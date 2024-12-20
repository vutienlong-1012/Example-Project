using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

namespace ExampleProject.UI.UIAnimation
{
    public abstract class PopupItem : MonoBehaviour
    {
        #region Fields

        [SerializeField, BoxGroup("Time setting")] protected float delayShow;
        [SerializeField, BoxGroup("Time setting")] protected float delayHide;
        [SerializeField, BoxGroup("Time setting")] protected float timeShow = 0.3f;
        [SerializeField, BoxGroup("Time setting")] protected float timeHide = 0.3f;

        #endregion

        #region Properties

        public Tween ShowTween { get; protected set; }
        public Tween HideTween { get; protected set; }

        #endregion

        #region LifeCycle   



        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public abstract Tween GetShowTween();
        public abstract Tween GetHideTween();

        [Button, BoxGroup("Set Position")]
        public abstract void SetThisAsShow();

        [Button, BoxGroup("Set Position")]
        public abstract void SetThisAsHide();

        [Button, BoxGroup("Preview Position")]
        public abstract void ShowImmediately();

        [Button, BoxGroup("Preview Position")]
        public abstract void HideImmediately();

        #endregion
    }
}