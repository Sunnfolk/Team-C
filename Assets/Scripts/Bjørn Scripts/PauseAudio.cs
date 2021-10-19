using UnityEngine;

public class PauseAudio : MonoBehaviour
{
    public static void PauseAllAudio()
    {
        AudioListener.pause = true;
    }
    public static void UnpauseAllAudio()
    {
        AudioListener.pause = false;
    }
}
