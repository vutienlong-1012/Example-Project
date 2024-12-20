using DG.Tweening;
using ExampleProject.Tools;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleProject.UI.UIAnimation
{
    public class PopupAnimationControl : MonoBehaviour
    {
        #region Fields

        [SerializeField] List<PopupItem> popupItemList;

        Sequence showSequence;
        Sequence hideSequence;

        #endregion

        #region Properties

        [ShowInInspector, ReadOnly]
        public PopupAnimationState CurrentAnimationState { get; private set; }

        #endregion

        #region LifeCycle   



        #endregion

        #region Private Methods

        void SetShowSequence()
        {
            showSequence = DOTween.Sequence();
            foreach (var _item in popupItemList)
            {
                showSequence.Join(_item.GetShowTween());
            }
        }

        void SetHideSequence()
        {
            hideSequence = DOTween.Sequence();
            foreach (var _item in popupItemList)
            {
                hideSequence.Join(_item.GetHideTween());
            }
        }
        void HideAllImmediately()
        {
            foreach (var item in popupItemList)
            {
                item.HideImmediately();
            }
        }
        void ShowAllImmediately()
        {
            foreach (var item in popupItemList)
            {
                item.ShowImmediately();
            }
        }
        [Button]
        void GetAllMenuItem()
        {
            popupItemList.Clear();
            popupItemList = Helpers.GetAllChildsComponent<PopupItem>(this.transform);
        }

        #endregion

        #region Public Methods

        public void StartShow(bool _isDoAnimation, Action _onShowStarted, Action _onShowCompleted)
        {
            //Hide first, then show
            HideAllImmediately();

            SetShowSequence();
            CurrentAnimationState = PopupAnimationState.Showing;
            _onShowStarted?.Invoke();

            showSequence.Play().OnComplete(() =>
            {
                _onShowCompleted?.Invoke();
                CurrentAnimationState = PopupAnimationState.Showed;
            });

            if (_isDoAnimation is false)
            {
                showSequence.Complete();
            }
        }
        public void StartHide(bool _isDoAnimation, Action _onHideStarted, Action _onHideCompleted)
        {
            SetHideSequence();
            CurrentAnimationState = PopupAnimationState.Hiding;

            _onHideStarted?.Invoke();
            hideSequence.Play().OnComplete(() =>
            {
                _onHideCompleted?.Invoke();
                CurrentAnimationState = PopupAnimationState.Hidden;
            });

            if (_isDoAnimation is false)
            {
                hideSequence.Complete();
            }
        }

        #endregion
    }

    public enum PopupAnimationState
    {
        None,
        Showing,
        Showed,
        Hiding,
        Hidden,
    }
}