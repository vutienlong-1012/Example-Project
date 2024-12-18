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
        [SerializeField] List<PopupItem> popupItemList;

        Sequence showSequence;
        Sequence hideSequence;

        [ShowInInspector, ReadOnly]
        public PopupAnimState CurrentPopupAnimState
        {
            get;
            private set;
        }

        public void StartShow(bool _isDoAnimation, float _delay, Action _onShowStarted, Action _onShowCompleted)
        {
            //Hide first, then show
            HideAllImmediately();

            SetShowSequence();
            CurrentPopupAnimState = PopupAnimState.Showing;
            _onShowStarted?.Invoke();

            showSequence.Play().SetDelay(_delay).OnComplete(() =>
            {
                _onShowCompleted?.Invoke();
                CurrentPopupAnimState = PopupAnimState.Showed;
            });

            if (_isDoAnimation is false)
            {
                showSequence.Complete();
            }
        }

        public void StartHide(bool _isDoAnimation, float _delay, Action _onHideStarted, Action _onHideCompleted)
        {
            SetHideSequence();
            CurrentPopupAnimState = PopupAnimState.Hiding;

            _onHideStarted?.Invoke();
            hideSequence.Play().SetDelay(_delay).OnComplete(() =>
            {
                _onHideCompleted?.Invoke();
                CurrentPopupAnimState = PopupAnimState.Hidden;
            });

            if (_isDoAnimation is false)
            {
                hideSequence.Complete();
            }
        }

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

        [Button]
        public void GetAllMenuItem()
        {
            popupItemList.Clear();
            popupItemList = Helpers.GetAllChildsComponent<PopupItem>(this.transform);
        }

        [Button]
        void HideAllImmediately()
        {
            foreach (var item in popupItemList)
            {
                item.HideImmediately();
            }
        }
        [Button]
        void ShowAllImmediately()
        {
            foreach (var item in popupItemList)
            {
                item.ShowImmediately();
            }
        }
    }

    public enum PopupAnimState
    {
        None,
        Showing,
        Showed,
        Hiding,
        Hidden,
    }
}