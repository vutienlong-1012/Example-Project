using ExampleProject.Scene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VTLTools.ResourceLoader;
using VTLTools;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

namespace ExampleProject.UI.SharedAssets
{
    [CreateAssetMenu(fileName = "BasePopups", menuName = "ScriptableObjects/BasePopups")]
    public class BasePopups : ScriptableObject
    {
        [ShowInInspector, ReadOnly]
        protected const string resourceFolderPath = "Data/BasePopups";

        private static ResourceLoader<BasePopups> resourceLoader = new(resourceFolderPath);

        [SerializeField] List<BasePopupData> resourceDataList = new();

        public static List<BasePopupData> GetResourceDataList()
        {
            return resourceLoader.Resource.resourceDataList;
        }

        public static BasePopupData GetResourceData(PopupId _id)
        {
            var _data = GetResourceDataList().Find(x => x.id.Equals(_id));
            return _data;
        }
    }
}