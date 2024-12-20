using Sirenix.OdinInspector;
using System;
using UnityEngine;
using UnityEngine.UI;
using ExampleProject.UI.UIAnimation;
using ExampleProject.Manager;

namespace ExampleProject.UI.BaseUI.BasePopup
{
    [RequireComponent(typeof(PopupAnimationControl))]
    public class BasePopup : MonoBehaviour
    {
        #region Fields

        [SerializeField, BoxGroup("Popup Reference")] protected Button closeButton;
        [ShowInInspector, ReadOnly, FoldoutGroup("Action")] protected Action onStartShowAction;
        [ShowInInspector, ReadOnly, FoldoutGroup("Action")] protected Action onCompleteShowAction;
        [ShowInInspector, ReadOnly, FoldoutGroup("Action")] protected Action onStartHideAction;
        [ShowInInspector, ReadOnly, FoldoutGroup("Action")] protected Action onCompleteHideAction;
        [SerializeField, BoxGroup("Infor"), ReadOnly] PopupId id;
        [SerializeField, BoxGroup("Infor")] bool isDestroyOnHide = true;
        [SerializeField, BoxGroup("Infor")] bool isDoAnimation = true;
        PopupAnimationControl menuAnimationControl;

        protected object data;
        #endregion

        #region Properties

        [ShowInInspector, BoxGroup("Infor")] public bool IsShow => this.gameObject.activeSelf;
        [ShowInInspector, BoxGroup("Popup Reference")] protected GameObject RaycastShield => transform.GetChild(transform.childCount - 1).gameObject;
        [ShowInInspector, BoxGroup("Component")] protected PopupAnimationControl ThisMenuAnimationControl => menuAnimationControl = menuAnimationControl != null ? menuAnimationControl : GetComponent<PopupAnimationControl>();
        #endregion

        #region LifeCycle   



        #endregion

        #region Private Methods
        protected virtual void Init() { }
        protected virtual void InitData() { }
        protected virtual void OnShowStarted()
        {
            SetActive(true);
            SetInteractable(false);
            AddListener();
            InitData();
            Init();
            this.onStartShowAction?.Invoke();
        }
        protected virtual void OnShowCompleted()
        {
            SetInteractable(true);
            this.onCompleteShowAction?.Invoke();
        }
        protected virtual void OnHideStarted()
        {
            SetInteractable(false);
            this.onStartHideAction?.Invoke();
        }
        protected virtual void OnHideCompleted()
        {
            SetInteractable(true);
            this.onCompleteHideAction?.Invoke();
            RemoveListener();
            if (isDestroyOnHide)
            {
                UIManager.Instance.RemovePopup(id);
                Destroy(this.gameObject);
            }
            else
                SetActive(false);
        }
        protected virtual void AddListener()
        {
            if (closeButton == null)
                return;
            closeButton.onClick.AddListener(OnClickCloseListener);
        }
        protected virtual void RemoveListener()
        {
            if (closeButton == null)
                return;
            closeButton.onClick.RemoveListener(OnClickCloseListener);
        }
        protected virtual void OnClickCloseListener()
        {
            this.Hide();
        }

        #endregion

        #region Public Methods

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
        public BasePopup SetIsDoAnimation(bool _value)
        {
            isDoAnimation = _value;
            return this;
        }
        public void SetId(PopupId _id)
        {
            id = _id;
        }
        public void SetActive(bool _value)
        {
            this.gameObject.SetActive(_value);
        }
        public void SetInteractable(bool _value)
        {
            RaycastShield.SetActive(!_value);
        }
        public virtual void Show()
        {
            ThisMenuAnimationControl.StartShow(isDoAnimation, _onShowStarted: OnShowStarted, _onShowCompleted: OnShowCompleted);
        }
        public virtual void Hide()
        {
            ThisMenuAnimationControl.StartHide(isDoAnimation, _onHideStarted: OnHideStarted, _onHideCompleted: OnHideCompleted);
        }
        public void PretendShow()
        {
            ThisMenuAnimationControl.StartShow(isDoAnimation, null, null);
        }
        public void PretendHide()
        {
            ThisMenuAnimationControl.StartHide(isDoAnimation,null,null);
        }

        #endregion
    }
}