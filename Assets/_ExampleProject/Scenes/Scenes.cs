using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using VTLTools;
using VTLTools.ResoureAsset;

namespace ExampleProject.Scene
{
    [CreateAssetMenu(fileName = "Scenes", menuName = "ScriptableObjects/Scenes")]
    public class Scenes : ResourceAsset
    {
        static Scenes()
        {
            ITEM_RESOURCE_FOLDER_PATH = StringsSafeAccess.RESOURCE_DATA_PATH + typeof(Scenes).Name;
            asset = new(ITEM_RESOURCE_FOLDER_PATH);
        }

        public static SceneData GetData(SceneId _id)
        {
            var _data = GetDataList<SceneData>().Find(x => x.id.Equals(_id));
            return _data;
        }

        public static UnityEngine.SceneManagement.Scene GetScene(SceneId _id)
        {
            return SceneManager.GetSceneByName(GetData(_id).SceneName);
        }
    }
}