using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VTLTools.UIAnimation
{
    public class MenuAnimationControl : MonoBehaviour
    {
        [SerializeField] List<MenuItem> menuItems;

        Sequence showSequence;
        Sequence hideSequence;

        [ShowInInspector, ReadOnly]
        public MenuItemState MenuItemState
        {
            get;
            private set;
        }

        private void Start()
        {

            // SetHideSequence();
        }

        public void StartShow(float _delay, Action _onShowStarted, Action _onShowCompleted)
        {
            SetShowSequence();
            MenuItemState = MenuItemState.Showing;
            _onShowStarted.Invoke();
            showSequence.Play().SetDelay(_delay).OnComplete(() =>
            {
                _onShowCompleted.Invoke();
                MenuItemState = MenuItemState.Showed;
            });
        }

        public void StartHide(float _delay, Action _onHideStarted, Action _onHideCompleted)
        {
            MenuItemState = MenuItemState.Hiding;

            _onHideStarted.Invoke();
            showSequence.Play().SetDelay(_delay).OnComplete(() =>
            {
                _onHideCompleted.Invoke();
                MenuItemState = MenuItemState.Hidden;
            });
        }

        void SetShowSequence()
        {
            showSequence = DOTween.Sequence();
            foreach (var _item in menuItems)
            {
                showSequence.Join(_item.GetShowTween());
            }
        }

        void SetHideSequence()
        {
            hideSequence = DOTween.Sequence();
            foreach (var _item in menuItems)
            {
                hideSequence.Join(_item.GetHideTween());
            }
        }

        [Button]
        public void GetAllMenuItem()
        {
            menuItems.Clear();
            menuItems = Helpers.GetAllChildsComponent<MenuItem>(this.transform);
        }
    }


    public enum MenuItemState
    {
        None,
        Showing,
        Showed,
        Hiding,
        Hidden,
    }
}