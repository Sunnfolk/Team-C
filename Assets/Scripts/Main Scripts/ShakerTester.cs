using UnityEngine;
using UnityEngine.InputSystem;

public class ShakerTester : MonoBehaviour
{
    public CameraShaker shaker;
    public float duration = 1f;
    public float strength = 1f;
    
    void Update()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            shaker.Shake(duration, strength);
        }
    }
}
