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
        [SerializeField] public HomePopup.HomePopup homePopup;
        [SerializeField] public SettingPopup.SettingPopup settingPopup;
        [SerializeField] public LoadingScenePopup.LoadingScenePopup loadingScenePopup;

        [SerializeField] public RectTransform canvas;
        [ShowInInspector, ReadOnly] Dictionary<BasePopup, BasePopup> showingPopupDictionary = new();

        public BasePopup SpawnPopup(BasePopup _popupPrefab)
        {
            BasePopup _tempPopup = Instantiate(_popupPrefab, canvas);
            showingPopupDictionary.Add(_popupPrefab, _tempPopup);
            return _tempPopup;
        }

        public void RemovePopup(BasePopup _popupPrefab)
        {
            showingPopupDictionary.Remove(_popupPrefab);
        }

        public BasePopup GetPopup(BasePopup _popupPrefab)
        {
            if (showingPopupDictionary.TryGetValue(_popupPrefab, out BasePopup _value))
                return _value;
            else
                return null;
        }
    }
}