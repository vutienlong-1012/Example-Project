using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VTLTools;

namespace ExampleProject.UI
{
    public class MusicToggle : MonoBehaviour
    {
        [SerializeField] Toggle musicToggle;
        private void OnEnable()
        {
            musicToggle.isOn = StaticVariables.IsMusicOn;
            musicToggle.onValueChanged.AddListener(delegate
            {
                MusicSystem.Instance.ToggeMusic();
                SoundSystem.Instance.PlayUIClick();
                VibrationSystem.Instance.PlayVibration();
            });
        }
        private void OnDisable()
        {
            musicToggle.onValueChanged.RemoveListener(delegate
            {
                MusicSystem.Instance.ToggeMusic();
                SoundSystem.Instance.PlayUIClick();
                VibrationSystem.Instance.PlayVibration();

            });
        }
    }
}