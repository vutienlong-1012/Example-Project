using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExampleProject.Tools;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

namespace ExampleProject.UI.BaseUI.BasePopup
{
    [CreateAssetMenu(fileName = "Popups", menuName = "ScriptableObjects/Popups")]
    public class Popups : ScriptableObject
    {
        #region Fields

        [SerializeField] List<PopupData> resourceDataList = new();
        const string resourceFolderPath = "Data/Popups";
        static ResourceLoader<Popups> resourceLoader = new(resourceFolderPath);

        #endregion

        #region Properties



        #endregion

        #region LifeCycle   



        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public static List<PopupData> GetResourceDataList()
        {
            return resourceLoader.Resource.resourceDataList;
        }
        public static PopupData GetResourceData(PopupId _id)
        {
            var _data = GetResourceDataList().Find(x => x.id.Equals(_id));
            return _data;
        }

        #endregion      
    }
}