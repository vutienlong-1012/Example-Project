using System.Collections;
using System.Collections.Generic;
using VTLTools;
using UnityEngine;


namespace ExampleProject
{
    public class SoundSystem : Singleton<SoundSystem>
    {
        [SerializeField] AudioSource shareAudioSource;
        [SerializeField] AudioSource uIAudioSource;
        [SerializeField] AudioClip uIOnClickAudioClip;
        public void PlaySoundOneShot(AudioSource _audioSource, AudioClip _audioClip)
        {
            if (!UserDataManager.IsSoundOn)
                return;
            else
                _audioSource.PlayOneShot(_audioClip);
        }

        public void PlaySoundOneShot(AudioSource _audioSource, AudioClip _audioClip, float _volume)
        {
            if (!UserDataManager.IsSoundOn)
                return;
            else
                _audioSource.PlayOneShot(_audioClip, _volume);
        }

        public void PlayUIClick()
        {
            if (!UserDataManager.IsSoundOn)
                return;
            else
                uIAudioSource.PlayOneShot(uIOnClickAudioClip);
        }

        public void ToggeSound()
        {
            UserDataManager.IsSoundOn = !UserDataManager.IsSoundOn;
        }
    }
}