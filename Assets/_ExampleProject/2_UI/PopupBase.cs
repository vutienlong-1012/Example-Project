using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VTLTools.UIAnimation;
using VTLTools;

namespace ExampleProject.UI
{
    [RequireComponent(typeof(MenuAnimationControl))]
    public class PopupBase : MonoBehaviour
    {
        [SerializeField, BoxGroup("Popup Reference")]
        protected Button closeButton;
        protected Action actionOnStartShow, actionOnCompleteShow, actionOnStartHide, actionOnCompleteHide;
        protected object data;

        MenuAnimationControl menuAnimationControl;
        protected MenuAnimationControl ThisMenuAnimationControl
        {
            get
            {
                if (menuAnimationControl is null)
                    menuAnimationControl = GetComponent<MenuAnimationControl>();
                return menuAnimationControl;
            }
        }

        public bool IsShow
        {
            get
            {
                return ThisMenuAnimationControl.MenuItemState == MenuItemState.Showing || ThisMenuAnimationControl.MenuItemState == MenuItemState.Showed;
            }
        }

        #region SHOW
        public virtual void Show(object _data = null, bool _isDoAnimation = true, float _delay = 0f, Action _actionOnStartShow = null, Action _actionOnCompleteShow = null, Action _actionOnStartHide = null, Action _actionOnCompleteHide = null)
        {
            this.data = _data;
            this.actionOnStartShow = _actionOnStartShow;
            this.actionOnCompleteShow = _actionOnCompleteShow;
            this.actionOnStartHide = _actionOnStartHide;
            this.actionOnCompleteHide = _actionOnCompleteHide;
            this.Init();

            ButtonAddListener();
            if (_isDoAnimation is false)
            {
                OnShowStarted();
                OnShowCompleted();
            }
            else
            {
                ThisMenuAnimationControl.StartShow(_delay, _onShowStarted: OnShowStarted, _onShowCompleted: OnShowCompleted);
            }
        }
        protected virtual void OnShowStarted()
        {
            this.gameObject.SetActive(true);
            this.actionOnStartShow?.Invoke();
        }
        protected virtual void OnShowCompleted()
        {
            this.actionOnCompleteShow?.Invoke();
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
                ThisMenuAnimationControl.StartHide(0f, _onHideStarted: OnHideStarted, _onHideCompleted: OnHideCompleted);
            }
        }
        protected virtual void OnHideStarted()
        {
            this.actionOnStartHide?.Invoke();
        }
        protected virtual void OnHideCompleted()
        {
            this.actionOnCompleteHide?.Invoke();
            this.gameObject.SetActive(false);
        }
        #endregion

        protected virtual void Init()
        {

        }
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