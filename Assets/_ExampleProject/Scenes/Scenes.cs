using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using VTLTools;
using VTLTools.ResourceAsset;

namespace ExampleProject.Scene
{
    [CreateAssetMenu(fileName = "Scenes", menuName = "ScriptableObjects/Scenes")]
    public class Scenes : ResourceAsset
    {
        static Scenes()
        {
            resourceFolderPath = StringsSafeAccess.RESOURCE_DATA_PATH + typeof(Scenes).Name;
            resourceLoader = new(resourceFolderPath);
        }

        public static SceneData GetResourceData(SceneId _id)
        {
            var _data = GetResourceDataList<SceneData>().Find(x => x.id.Equals(_id));
            return _data;
        }

        public static UnityEngine.SceneManagement.Scene GetUnityScene(SceneId _id)
        {
            return SceneManager.GetSceneByName(GetResourceData(_id).SceneName);
        }
    }
}