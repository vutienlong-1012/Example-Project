using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VTLTools;

namespace RobotGTA.Scenes
{
    public class KeepOpject : MonoBehaviour
    {
        #region Fields


        #endregion

        #region Properties
        #endregion

        #region LifeCycle    
        void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        #endregion
    }
}