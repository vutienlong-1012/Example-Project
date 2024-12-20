using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using ExampleProject.Tools;
using ExampleProject.UI.BaseUI.BasePopup;
using UnityEngine.Rendering.Universal;

namespace ExampleProject.Manager
{
    public class UIManager : Singleton<UIManager>
    {
        #region Fields

        [SerializeField] RectTransform canvas;
        [SerializeField] Camera uiCam;
        [ShowInInspector, ReadOnly] Dictionary<PopupId, BasePopup> existingPopupDictionary = new();

        #endregion

        #region Properties

        #endregion

        #region LifeCycle

        private void Start()
        {
            //GetPopup(PopupId.DevModePopup).Show();
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
                _tempPopup.SetId(_popupId);
                existingPopupDictionary.Add(_popupId, _tempPopup);
                return _tempPopup;
            }
        }
        public T GetPopup<T>(PopupId _popupId) where T : BasePopup
        {
            return GetPopup(_popupId) as T;
        }
        public void RemovePopup(PopupId _popupId)
        {
            existingPopupDictionary.Remove(_popupId);
        }
        public bool IsHasPopup(PopupId _popupId, out BasePopup _popup)
        {
            if (existingPopupDictionary.TryGetValue(_popupId, out _popup))
                return true;
            else
            {
                _popup = null; // ensure _popup is set to null if not found
                return false;
            }
        }
        public bool IsHasPopup<T>(PopupId _popupId, out T _popup) where T : BasePopup
        {
            if (IsHasPopup(_popupId, out BasePopup _basePopup))
            {
                _popup = _basePopup as T;
                return _popup != null;
            }
            else
            {
                _popup = null;
                return false;
            }
        }
        public void StackCamera(Camera _mainCam)
        {
            _mainCam.GetUniversalAdditionalCameraData().cameraStack.Add(uiCam);
        }
        #endregion
    }
}