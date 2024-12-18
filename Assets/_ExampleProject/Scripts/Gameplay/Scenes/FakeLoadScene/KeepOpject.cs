using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExampleProject.Tools;

namespace ExampleProject.Scenes
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