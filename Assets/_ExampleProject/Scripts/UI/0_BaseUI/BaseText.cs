using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ExampleProject.UI.BaseUI
{
    public class BaseText : MonoBehaviour
    {
        #region Fields

        Text text;

        #endregion

        #region Properties

        [ShowInInspector]
        protected Text ThisText => text = text != null ? text : GetComponent<Text>();

        #endregion

        #region LifeCycle   



        #endregion

        #region Private Methods



        #endregion

        #region Public Methods



        #endregion

    }
}
