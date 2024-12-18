using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExampleProject.Tools;
using DG.Tweening;
using ExampleProject.UI.UIAnimation;

namespace ExampleProject.UI.SharedAssets
{
    [RequireComponent(typeof(PopupAnimationControl))]
    public class BasePopup : MonoBehaviour
    {
        [SerializeField, BoxGroup("Popup Reference")]
        protected Button closeButton;

        [ShowInInspector, ReadOnly, BoxGroup("Action")]
        protected Action onStartShowAction, onCompleteShowAction, onStartHideAction, onCompleteHideAction;

        protected object data;

        PopupAnimationControl menuAnimationControl;

        [ShowInInspector, BoxGroup("Component")]
        protected PopupAnimationControl ThisMenuAnimationControl => menuAnimationControl = menuAnimationControl != null ? menuAnimationControl : GetComponent<PopupAnimationControl>();

        [ShowInInspector, BoxGroup("Infor")]
        public bool IsShow => this.gameObject.activeSelf;

        [SerializeField, BoxGroup("Infor")]
        bool isDestroyOnHide = true;

        [SerializeField, BoxGroup("Infor"), ReadOnly]
        PopupId id;

        public BasePopup SetData(object _data)
        {
            this.data = _data;
            return this;
        }

        public BasePopup SetOnStartShow(Action _actionOnStartShow)
        {
            this.onStartShowAction = _actionOnStartShow;
            return this;
        }

        public BasePopup SetOnCompleteShow(Action _actionOnCompleteShow)
        {
            this.onCompleteShowAction = _actionOnCompleteShow;
            return this;
        }

        public BasePopup SetOnStartHide(Action _actionOnStartHide)
        {
            this.onStartHideAction = _actionOnStartHide;
            return this;
        }

        public BasePopup SetOnCompleteHide(Action _actionOnCompleteHide)
        {
            this.onCompleteHideAction = _actionOnCompleteHide;
            return this;
        }

        public void Init(PopupId _id)
        {
            id = _id;
        }

        #region SHOW
        public virtual void Show(bool _isDoAnimation = true, float _delay = 0f)
        {
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

            if (isDestroyOnHide)
            {
                UIManager.Instance.RemovePopup(id);
                Destroy(this.gameObject);
            }
            else
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