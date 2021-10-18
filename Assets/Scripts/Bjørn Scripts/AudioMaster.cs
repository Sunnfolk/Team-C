using UnityEngine;
using UnityEngine.Audio;

public class AudioMaster : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }
    public void SetAmbianceVolume(float volume)
    {
        audioMixer.SetFloat("AmbianceVolume", volume);
    }
}