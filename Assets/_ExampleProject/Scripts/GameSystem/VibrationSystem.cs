using System.Collections;
using System.Collections.Generic;
using ExampleProject.Tools;
using UnityEngine;
using Lofelt.NiceVibrations;
using Sirenix.OdinInspector;
using ExampleProject.Manager;

namespace ExampleProject.GameSystem
{
    public class VibrationSystem : Singleton<VibrationSystem>
    {
        #region Fields



        #endregion

        #region Properties



        #endregion

        #region LifeCycle   



        #endregion

        #region Private Methods



        #endregion

        #region Protected Methods



        #endregion

        #region Public Methods

        public void PlayVibration()
        {
            if (!UserDataManager.IsVibrationOn)
                return;
            HapticPatterns.PlayPreset(HapticPatterns.PresetType.LightImpact);
        }
        [Button]
        public void SetVibration(bool _value)
        {
            UserDataManager.IsVibrationOn = _value;
        }

        #endregion
    }
}