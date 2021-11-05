using UnityEngine;
using Random = UnityEngine.Random;

public class TimmyAudio : MonoBehaviour
{
    public AudioClip jump;
    public AudioClip walk;
    public AudioClip death;

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
        if (_Input.jump && _Movement.canCoyote && !_Movement.isDead)
        {
            _AudioSource.pitch = Random.Range(0.95f, 1.1f);
            _AudioSource.volume = 0.3f;
            _AudioSource.PlayOneShot(jump);
        }
    }

    public void WalkAudio()
    {
        _AudioSource.pitch = Random.Range(0.95f, 1.05f);
        _AudioSource.volume = 1f;
        _AudioSource.PlayOneShot(walk);
    }

    public void DeathAudio()
    {
        _AudioSource.pitch = 1f;
        _AudioSource.volume = 1f;
        _AudioSource.PlayOneShot(death);
    }
}
