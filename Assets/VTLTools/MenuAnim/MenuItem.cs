using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

namespace VTLTools.UIAnimation
{
    public abstract class MenuItem : MonoBehaviour
    {
        [Button, BoxGroup("Time setting")] protected float delayShow;
        [Button, BoxGroup("Time setting")] protected float delayHide;
        [Button, BoxGroup("Time setting")] protected float timeShow = 0.3f;
        [Button, BoxGroup("Time setting")] protected float timeHide = 0.3f;

        public Tween ShowTween
        {
            get;
            protected set;
        }
        public Tween HideTween
        {
            get;
            protected set;
        }

        public abstract void SetShowTween();
        public abstract void SetHideTween();

        [Button, BoxGroup("Set Position")]
        public abstract void SetThisAsShow();

        [Button, BoxGroup("Set Position")]
        public abstract void SetThisAsHide();

        [Button, BoxGroup("Preview Position")]
        public abstract void ShowImnidiately();

        [Button, BoxGroup("Preview Position")]
        public abstract void HideImidiatly();

    }

}