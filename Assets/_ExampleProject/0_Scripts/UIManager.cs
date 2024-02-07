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
            _tempPopup.Init(_popupId);
            showingPopupDictionary.Add(_popupId, _tempPopup);
            return _tempPopup;
        }

        public void RemovePopup(PopupId _popupId)
        {
            showingPopupDictionary.Remove(_popupId);
        }

        public bool TryGetGetPopup(PopupId _popupId, out BasePopup _value)
        {
            return showingPopupDictionary.TryGetValue(_popupId, out _value);
        }
    }
}