using Sirenix.OdinInspector;
using UnityEngine;

namespace ExampleProject.UI.SharedAssets
{
    [CreateAssetMenu(fileName = "BasePopupData", menuName = "ScriptableObjects/BasePopupData"), InlineEditor]
    public class BasePopupData : ScriptableObject
    {
        public PopupId id;
        public BasePopup basePopupPrefab;
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