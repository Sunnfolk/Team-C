using UnityEngine;

public class BearAudio : MonoBehaviour
{
    public AudioClip slam;

    private AudioSource _AudioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
    }

    public void SlamAudio()
    {
        _AudioSource.pitch = 1f;
        _AudioSource.volume = 0.6f;
        _AudioSource.PlayOneShot(slam);
    }
}
