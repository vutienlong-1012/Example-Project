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
        public MenuItemState ThisMenuItemState
        {
            get;
            protected set;
        }

        private void Start()
        {
            SetShowSequence();
            SetHideSequence();
        }

        public void StartShow(float _delay, Action _onShowStarted, Action _onShowCompleted)
        {
            ThisMenuItemState = MenuItemState.Showing;

            _onShowStarted.Invoke();
            showSequence.Play().SetDelay(_delay).OnComplete(() =>
            {
                _onShowCompleted.Invoke();
                ThisMenuItemState = MenuItemState.Showed;
            });
        }

        public void StartHide(float _delay, Action _onHideStarted, Action _onHideCompleted)
        {
            ThisMenuItemState = MenuItemState.Hiding;

            _onHideStarted.Invoke();
            showSequence.Play().SetDelay(_delay).OnComplete(() =>
            {
                _onHideCompleted.Invoke();
                ThisMenuItemState = MenuItemState.Hidden;
            });
        }

        void SetShowSequence()
        {
            foreach (var _item in menuItems)
            {
                showSequence.Join(_item.ShowTween);
            }
        }

        void SetHideSequence()
        {
            foreach (var _item in menuItems)
            {
                hideSequence.Join(_item.HideTween);
            }
        }

        [Button]
        public void GetAllMenuItem()
        {
            menuItems.Clear();
            menuItems = Helpers.GetAllChildsComponent<MenuItem>(this.transform);
        }
    }
}