using System.Collections;
using System.Collections.Generic;
using ExampleProject.Tools;
using UnityEngine;


namespace ExampleProject.GameSystem
{
    public class MusicSystem : Singleton<MusicSystem>
    {
        #region Fields

        [SerializeField] private AudioSource musicAudioSource;

        #endregion

        #region Properties



        #endregion

        #region LifeCycle   

        private void OnEnable()
        {
            musicAudioSource.mute = !UserDataManager.IsMusicOn;
        }

        #endregion

        #region Private Methods



        #endregion

        #region Protected Methods



        #endregion

        #region Public Methods

        public void PlayMusic(AudioClip _audioClip)
        {
            if (!UserDataManager.IsMusicOn)
            {
                musicAudioSource.clip = _audioClip;
                return;
            }
            else
            {
                musicAudioSource.clip = _audioClip;
                musicAudioSource.Play();
            }
        }
        public void SetMusic(bool _value)
        {
            UserDataManager.IsMusicOn = _value;
            musicAudioSource.mute = !UserDataManager.IsMusicOn;
        }

        #endregion
    }
}