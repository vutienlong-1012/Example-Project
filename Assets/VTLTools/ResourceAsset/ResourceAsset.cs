using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VTLTools.ResoureAsset
{
    public class ResourceAsset : ScriptableObject
    {
        [ShowInInspector, ReadOnly]
        protected static string ITEM_RESOURCE_FOLDER_PATH;

        protected static ResourceLoader<ResourceAsset> asset = new(ITEM_RESOURCE_FOLDER_PATH);


        [SerializeField] List<ResourceData> dataList = new();

        public static List<T> GetDataList<T>() where T : ResourceData
        {
            Debug.Log(ITEM_RESOURCE_FOLDER_PATH);
            Debug.Log(asset);
            Debug.Log(asset.Value);
            Debug.Log(asset.Value.dataList);
            Debug.Log(asset.Value.dataList.Count);
            return asset.Value.dataList.Cast<T>().ToList();
        }
    }

    [System.Serializable]
    [InlineEditor]
    public class ResourceData : ScriptableObject
    {

    }

}