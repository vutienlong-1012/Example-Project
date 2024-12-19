using ExampleProject.Gameplay.Scenes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ExampleProject.UI.BaseUI.BasePopup
{
    [CreateAssetMenu(fileName = "BasePopupData", menuName = "ScriptableObjects/BasePopupData"), InlineEditor]
    public class BasePopupData : ScriptableObject
    {
        #region Fields

        public PopupId id;
        public BasePopup basePopupPrefab;

        #endregion
    }

    public enum PopupId
    {
        None = 0,
        LoadingScenePopup = 1,
        HomePopup = 2,
        SettingPopup = 3,
        DevModePopup = 4,
    }
}