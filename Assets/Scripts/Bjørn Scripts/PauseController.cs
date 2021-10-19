using UnityEngine;

public class PauseController : MonoBehaviour
{
    private Animation _gnome;
    [SerializeField] private PlayerInput _Input;
    [SerializeField] private PlayerMovement _Movement;
    private bool justPaused;

    private void Update()
    {
        if (_Input.pause)
        {
            if (justPaused) return;
            
            Time.timeScale = 0f;
            AudioListener.pause = true;
            _Movement.canMove = false;
            justPaused = true;
        }
        else if (justPaused)
        {
            Time.timeScale = 1f;
            AudioListener.pause = false;
            _Movement.canMove = true;
            justPaused = false;
        }
    }
    
}
