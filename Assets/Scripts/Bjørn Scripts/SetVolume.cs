using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;

    public TMP_Text _text;

    public void MusicSetVolume(float volume)
    {
        var vol = 0f;
        if (volume > 0)
        {
            vol = Mathf.Log10(volume / 100) * 20;
        }
        else
        {
            vol = Mathf.Log10(0.0001f) * 20;
        }
        mixer.SetFloat("MusicVolume", vol);

        _text.text = "Music: " + volume + "%";
    }
    public void PlayerSfxSetVolume(float volume)
    {
        var vol = 0f;
        if (volume > 0)
        {
            vol = Mathf.Log10(volume / 100) * 20;
        }
        else
        {
            vol = Mathf.Log10(0.0001f) * 20;
        }
        mixer.SetFloat("PlayerSfxVolume", vol);

        _text.text = "Player Sfx: " + volume + "%";
    }public void EnemySfxSetVolume(float volume)
    {
        var vol = 0f;
        if (volume > 0)
        {
            vol = Mathf.Log10(volume / 100) * 20;
        }
        else
        {
            vol = Mathf.Log10(0.0001f) * 20;
        }
        mixer.SetFloat("EnemySfxVolume", vol);

        _text.text = "Enemy Sfx: " + volume + "%";
    }
    public void AmbianceSetVolume(float volume)
    {
        var vol = 0f;
        if (volume > 0)
        {
            vol = Mathf.Log10(volume / 100) * 20;
        }
        else
        {
            vol = Mathf.Log10(0.0001f) * 20;
        }
        mixer.SetFloat("AmbianceVolume", vol);

        _text.text = "Ambiance: " + volume + "%";
    }
}
