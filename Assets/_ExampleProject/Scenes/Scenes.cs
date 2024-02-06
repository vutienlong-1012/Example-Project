using ExampleProject.UI.SharedAssets;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using VTLTools;
using VTLTools.ResourceLoader;

namespace ExampleProject.Scene
{
    [CreateAssetMenu(fileName = "Scenes", menuName = "ScriptableObjects/Scenes")]
    public class Scenes : ScriptableObject
    {
        [ShowInInspector, ReadOnly]
        protected const string resourceFolderPath = "Data/Scenes";

        private static ResourceLoader<Scenes> resourceLoader = new(resourceFolderPath);

        [SerializeField] List<SceneData> resourceDataList = new();

        public static List<SceneData> GetResourceDataList()
        {
            return resourceLoader.Resource.resourceDataList;
        }

        public static SceneData GetResourceData(SceneId _id)
        {
            var _data = GetResourceDataList().Find(x => x.id.Equals(_id));
            return _data;
        }

        public static UnityEngine.SceneManagement.Scene GetUnityScene(SceneId _id)
        {
            var _data = GetResourceDataList().Find(x => x.id.Equals(_id)).SceneName;
            return SceneManager.GetSceneByName(_data);
        }
    }
}