using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VTLTools.UIAnimation;
using VTLTools;

namespace ExampleProject.UI
{
    [RequireComponent(typeof(PopupAnimationControl))]
    public class PopupBase : MonoBehaviour
    {
        [SerializeField, BoxGroup("Popup Reference")]
        protected Button closeButton;
        //protected Action onStartShowAction, onCompleteShowAction, onStartHideAction, onCompleteHideAction;
        protected Action onStartShowAction, onCompleteShowAction, onStartHideAction, onCompleteHideAction;
        protected object data;

        PopupAnimationControl menuAnimationControl;
        protected PopupAnimationControl ThisMenuAnimationControl
        {
            get
            {
                if (menuAnimationControl is null)
                    menuAnimationControl = GetComponent<PopupAnimationControl>();
                return menuAnimationControl;
            }
        }

        public bool IsShow => this.gameObject.activeSelf;

        #region SHOW
        public virtual void Show(object _data = null, bool _isDoAnimation = true, float _delay = 0f, Action _actionOnStartShow = null, Action _actionOnCompleteShow = null, Action _actionOnStartHide = null, Action _actionOnCompleteHide = null)
        {
            this.data = _data;
            this.onStartShowAction = _actionOnStartShow;
            this.onCompleteShowAction = _actionOnCompleteShow;
            this.onStartHideAction = _actionOnStartHide;
            this.onCompleteHideAction = _actionOnCompleteHide;

            ButtonAddListener();
            ThisMenuAnimationControl.StartShow(_isDoAnimation, _delay, _onShowStarted: OnShowStarted, _onShowCompleted: OnShowCompleted);
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
        public virtual void Hide()
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
                ThisMenuAnimationControl.StartHide(true, 0f, _onHideStarted: OnHideStarted, _onHideCompleted: OnHideCompleted);
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
            if (!IsShow)
                return;
            this.Hide();
        }
    }
}