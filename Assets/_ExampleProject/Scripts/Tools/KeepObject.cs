using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExampleProject.Tools;

namespace ExampleProject.Tools
{
    public class KeepObject : MonoBehaviour
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