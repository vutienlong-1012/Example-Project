using Sirenix.OdinInspector;
using ExampleProject.Tools;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ExampleProject.Tools
{
    public class FixResolutionCanvasV2 : MonoBehaviour
    {
        #region Fields

        [SerializeField] float longScreenMatch = 1;
        [SerializeField] float shortScreenMatch = 0;
        CanvasScaler canvasScaler;

        #endregion

        #region Properties

        [ShowInInspector] CanvasScaler ThisanvasScaler => canvasScaler = canvasScaler != null ? canvasScaler : GetComponent<CanvasScaler>();

        #endregion

        #region LifeCycle

        private void Start()
        {
            SetCanvasScalerMatch();
        }

        private void Update()
        {
#if UNITY_EDITOR
            SetCanvasScalerMatch();
#endif
        }

        #endregion

        #region Private Methods       

        void SetCanvasScalerMatch()
        {
            ThisanvasScaler.matchWidthOrHeight = Helpers.IsLongScreen() ? longScreenMatch : shortScreenMatch;
        }

        #endregion

        #region Public Methods



        #endregion
    }
}
