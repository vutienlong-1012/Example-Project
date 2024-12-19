using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using ExampleProject.Tools;

namespace ExampleProject.Gameplay.Scenes
{
    [CreateAssetMenu(fileName = "Scenes", menuName = "ScriptableObjects/Scenes")]
    public class Scenes : ScriptableObject
    {
        #region Fields

        [SerializeField] List<SceneData> resourceDataList = new();
        const string resourceFolderPath = "Data/Scenes";
        static ResourceLoader<Scenes> resourceLoader = new(resourceFolderPath);

        #endregion

        #region Public Methods

        public static List<SceneData> GetResourceDataList()
        {
            return resourceLoader.Resource.resourceDataList;
        }

        public static SceneData GetResourceData(SceneId _id)
        {
            var _data = GetResourceDataList().Find(x => x.id.Equals(_id));
            return _data;
        }

        public static Scene GetUnityScene(SceneId _id)
        {
            var _data = GetResourceDataList().Find(x => x.id.Equals(_id)).SceneName;
            return SceneManager.GetSceneByName(_data);
        }

        #endregion
    }
}