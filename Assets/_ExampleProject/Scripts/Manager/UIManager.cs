using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using ExampleProject.Tools;
using ExampleProject.UI.BaseUI.BasePopup;

namespace ExampleProject.Manager
{
    public class UIManager : Singleton<UIManager>
    {
        #region Fields

        [SerializeField] public RectTransform canvas;
        [SerializeField] public RectTransform dynamicUiFx;
        [ShowInInspector, ReadOnly] Dictionary<PopupId, BasePopup> existingPopupDictionary = new();

        #endregion

        #region Properties

        #endregion

        #region LifeCycle

        private void Start()
        {
            GetPopup(PopupId.DevModePopup).Show();
        }

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public BasePopup GetPopup(PopupId _popupId)
        {
            if (existingPopupDictionary.TryGetValue(_popupId, out BasePopup _value))
            {
                return _value;
            }
            else
            {
                BasePopup _tempPopup = Instantiate(Popups.GetResourceData(_popupId).basePopupPrefab, canvas);
                _tempPopup.Init(_popupId);
                existingPopupDictionary.Add(_popupId, _tempPopup);
                return _tempPopup;
            }
        }

        public void RemovePopup(PopupId _popupId)
        {
            existingPopupDictionary.Remove(_popupId);
        }

        public bool IsHasPopup(PopupId popupId)
        {
            return existingPopupDictionary.ContainsKey(popupId);
        }

        #endregion
    }
}