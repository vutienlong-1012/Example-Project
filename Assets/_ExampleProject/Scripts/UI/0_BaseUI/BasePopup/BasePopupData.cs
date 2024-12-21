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
        DevModePopup = 1,
        LoadingScenePopup = 2,
        HomePopup = 3,
        SettingPopup = 4,
        Gameplay = 5,
    }
}