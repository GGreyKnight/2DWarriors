using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixer audioMixerGame;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MenuVolume", volume);
    }
    public void SetGameVolume(float volume)
    {
        audioMixerGame.SetFloat("GameVolume", volume);
    }
}
