using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;


namespace ExampleProject.Manager
{
    public class UserDataManagerEditor : OdinEditorWindow
    {
        [MenuItem("Tools/User Data Editor")]
        private static void OpenWindow()
        {
            GetWindow<UserDataManagerEditor>().Show();
            UserData = UserDataManager.UserData;
        }

        [ShowInInspector] public static UserData UserData;


        private void OnValidate()
        {
            if (UserData != null)
                UserDataManager.SetUserData(UserData);
        }

        [Button(ButtonSizes.Gigantic)]
        void Refresh()
        {
            UserData = UserDataManager.UserData;
        }      
    }
}