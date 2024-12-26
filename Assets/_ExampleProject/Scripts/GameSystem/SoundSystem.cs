using System.Collections;
using System.Collections.Generic;
using ExampleProject.Manager;
using ExampleProject.Tools;
using UnityEngine;


namespace ExampleProject.GameSystem
{
    public class SoundSystem : Singleton<SoundSystem>
    {
        #region Fields

        [SerializeField] AudioSource shareAudioSource;
        [SerializeField] AudioSource uIAudioSource;
        [SerializeField] AudioClip uIOnClickAudioClip;

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

        public void PlaySoundOneShot(AudioSource _audioSource, AudioClip _audioClip)
        {
            _audioSource.PlayOneShot(_audioClip, UserDataManager.SoundVolume);
        }

        public void PlayUIClick()
        {
            uIAudioSource.PlayOneShot(uIOnClickAudioClip, UserDataManager.SoundVolume);
        }
        public void SetSound(float _value)
        {
            UserDataManager.SoundVolume = _value;
        }

        #endregion
    }
}