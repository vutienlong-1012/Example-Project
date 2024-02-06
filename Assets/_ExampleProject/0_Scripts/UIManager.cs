using ExampleProject.UI.SharedAssets;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using VTLTools;

namespace ExampleProject.UI
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] public RectTransform canvas;
        [ShowInInspector, ReadOnly] Dictionary<PopupId, BasePopup> showingPopupDictionary = new();

        public BasePopup SpawnPopup(PopupId _popupId)
        {
            BasePopup _tempPopup = Instantiate(BasePopups.GetResourceData(_popupId).basePopupPrefab, canvas);
            showingPopupDictionary.Add(_popupId, _tempPopup);
            return _tempPopup;
        }

        public void RemovePopup(PopupId _popupId)
        {
            showingPopupDictionary.Remove(_popupId);
        }

        public BasePopup GetPopup(PopupId _popupId)
        {
            if (showingPopupDictionary.TryGetValue(_popupId, out BasePopup _value))
                return _value;
            else
                return null;
        }
    }
}