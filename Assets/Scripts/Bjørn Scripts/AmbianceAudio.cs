using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AmbianceAudio : MonoBehaviour
{
    public AudioClip[] ambiance;

    private AudioSource _Source;

    public float ambianceMaxChance = 15f;
    public float ambianceMinChance = 4f;

    private float _TimeUntilAmbiance;
    private bool _GetNewTimeUntil = true;

    private void Start()
    {
        _Source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_GetNewTimeUntil)
        {
            _TimeUntilAmbiance = Random.Range(ambianceMinChance, ambianceMaxChance);
            _GetNewTimeUntil = false;
        }
        else if (_TimeUntilAmbiance <= 0)
        {
            _GetNewTimeUntil = true;
            PlayAmbiance(Mathf.FloorToInt(Random.Range(0f, ambiance.Length)));
        }

        if (_TimeUntilAmbiance > 0 && !_GetNewTimeUntil) _TimeUntilAmbiance -= Time.deltaTime;
    }

    private void PlayAmbiance(int num)
    {
        if (num == 0) _Source.volume = 0.3f;
        else if (num == 1) _Source.volume = 0.5f;
        else _Source.volume = 0.5f;
        _Source.PlayOneShot(ambiance[num]);
    }
}
