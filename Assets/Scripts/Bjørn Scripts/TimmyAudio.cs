using UnityEngine;
using Random = UnityEngine.Random;

public class TimmyAudio : MonoBehaviour
{
    public AudioClip jump;

    private AudioSource _AudioSource;
    private PlayerInput _Input;
    private PlayerMovement _Movement;

    private void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
        _Input = GetComponent<PlayerInput>();
        _Movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        JumpAudio();
    }

    private void JumpAudio()
    {
        if (_Input.jump && _Movement.canCoyote)
        {
            _AudioSource.pitch = Random.Range(0.95f, 1.1f);
            _AudioSource.volume = 0.3f;
            _AudioSource.PlayOneShot(jump);
        }
    }
}
