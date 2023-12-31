using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VTLTools.UIAnimation;
using VTLTools;
using DG.Tweening;

namespace ExampleProject.UI
{
    [RequireComponent(typeof(PopupAnimationControl))]
    public class PopupBase : MonoBehaviour
    {
        [SerializeField, BoxGroup("Popup Reference")]
        protected Button closeButton;
        [ShowInInspector] protected Action onStartShowAction, onCompleteShowAction, onStartHideAction, onCompleteHideAction;
        protected object data;

        PopupAnimationControl menuAnimationControl;
        [ShowInInspector]
        protected PopupAnimationControl ThisMenuAnimationControl
        {
            get
            {
                if (menuAnimationControl == null)
                    menuAnimationControl = GetComponent<PopupAnimationControl>();
                return menuAnimationControl;
            }
        }

        public bool IsShow => this.gameObject.activeSelf;

        #region SHOW
        public virtual void Show(bool _isDoAnimation = true, float _delay = 0f)
        {
            ButtonAddListener();
            ThisMenuAnimationControl.StartShow(_isDoAnimation, _delay, _onShowStarted: OnShowStarted, _onShowCompleted: OnShowCompleted);
        }

        public PopupBase SetData(object _data)
        {
            this.data = _data;
            return this;
        }

        public PopupBase SetOnStartShow(Action _actionOnStartShow)
        {
            this.onStartShowAction = _actionOnStartShow;
            return this;
        }

        public PopupBase SetOnCompleteShow(Action _actionOnCompleteShow)
        {
            this.onCompleteShowAction = _actionOnCompleteShow;
            return this;
        }

        public PopupBase SetOnStartHide(Action _actionOnStartHide)
        {
            this.onStartHideAction = _actionOnStartHide;
            return this;
        }

        public PopupBase SetOnCompleteHide(Action _actionOnCompleteHide)
        {
            this.onCompleteHideAction = _actionOnCompleteHide;
            return this;
        }

        protected virtual void OnShowStarted()
        {
            this.gameObject.SetActive(true);
            this.onStartShowAction?.Invoke();
        }
        protected virtual void OnShowCompleted()
        {
            this.onCompleteShowAction?.Invoke();
        }
        #endregion

        #region HIDE
        public virtual void Hide(bool _isDoAnimation = true, float _delay = 0f)
        {
            if (!IsShow)
                return;
            ButtonRemoveListener();
            if (ThisMenuAnimationControl == null)
            {
                OnHideStarted();
                OnHideCompleted();
            }
            else
            {
                ThisMenuAnimationControl.StartHide(_isDoAnimation, _delay, _onHideStarted: OnHideStarted, _onHideCompleted: OnHideCompleted);
            }
        }
        protected virtual void OnHideStarted()
        {
            this.onStartHideAction?.Invoke();
        }
        protected virtual void OnHideCompleted()
        {
            this.onCompleteHideAction?.Invoke();
            this.gameObject.SetActive(false);
        }
        #endregion

        protected virtual void ButtonAddListener()
        {
            closeButton?.onClick.AddListener(OnClickCloseListenerMethod);
        }
        protected virtual void ButtonRemoveListener()
        {
            closeButton?.onClick.RemoveListener(OnClickCloseListenerMethod);
        }
        protected virtual void OnClickCloseListenerMethod()
        {
            this.Hide();
        }
    }
}