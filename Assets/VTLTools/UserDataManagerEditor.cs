using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;


namespace VTLTools
{
    public class UserDataManagerEditor : OdinEditorWindow
    {
        [MenuItem("Tools/User Data Editor")]
        private static void OpenWindow()
        {
            GetWindow<UserDataManagerEditor>().Show();
            UserData = VTLPlayerPrefs.GetObjectValue<UserData>(StringsSafeAccess.PREF_USER_DATA);
        }

        [OnValueChanged(nameof(OnValidate)), ShowInInspector]
        public static UserData UserData;


        private void OnValidate()
        {
            VTLPlayerPrefs.SetObjectValue(StringsSafeAccess.PREF_USER_DATA, UserData);
        }

        [Button(ButtonSizes.Gigantic)]
        void Refresh()
        {
            UserData = VTLPlayerPrefs.GetObjectValue<UserData>(StringsSafeAccess.PREF_USER_DATA);
        }
    }
}