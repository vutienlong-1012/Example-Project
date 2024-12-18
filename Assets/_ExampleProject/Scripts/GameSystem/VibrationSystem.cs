using System.Collections;
using System.Collections.Generic;
using ExampleProject.Tools;
using UnityEngine;
using Lofelt.NiceVibrations;
using Sirenix.OdinInspector;

namespace ExampleProject.GameSystem
{
    public class VibrationSystem : Singleton<VibrationSystem>
    {
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
    }
}