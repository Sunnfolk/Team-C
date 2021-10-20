using UnityEngine;

public class PauseController : MonoBehaviour
{
    private Animation _gnome;
    [SerializeField] private PlayerInput _Input;
    [SerializeField] private PlayerMovement _Movement;
    private bool justPaused;
    
    [SerializeField] private GameObject _PauseCanvas;
    [SerializeField] private GameObject _AudioCanvas;
    [SerializeField] private GameObject _ControlsCanvas;

    private bool _WasPaused;

    private void Start()
    {
        _PauseCanvas.SetActive(false);
        _AudioCanvas.SetActive(false);
    }
    
    private void Update()
    {
        //Opens and closes pause menu when _Input.pause was pressed this frame
        if (_Input.pause && !_WasPaused)
        {
            _PauseCanvas.SetActive(true);
            _AudioCanvas.SetActive(false);
            _WasPaused = true;
        }
        else if (!_Input.pause && _WasPaused)
        {
            _PauseCanvas.SetActive(false);
            _AudioCanvas.SetActive(false);
            _WasPaused = false;
        }
        
        //Pauses the game, stops movement, animation & audio
        if (_Input.pause)
        {
            if (justPaused) return;
            
            Time.timeScale = 0f;
            AudioListener.pause = true;
            _Movement.canMove = false;
            justPaused = true;
        }
        else if (!_Input.pause)
        {
            if (!justPaused) return;
            
            Time.timeScale = 1f;
            AudioListener.pause = false;
            _Movement.canMove = true;
            justPaused = false;
        }
    }
    
    //Opening and closing of different canvases
    public void EnterAudio()
    {
        _PauseCanvas.SetActive(false);
        _AudioCanvas.SetActive(true);
        _ControlsCanvas.SetActive(false);
    }
    public void EnterPause()
    {
        _PauseCanvas.SetActive(true);
        _AudioCanvas.SetActive(false);
        _ControlsCanvas.SetActive(false);
    }
    
    public void EnterControls()
    {
        _AudioCanvas.SetActive(false);
        _PauseCanvas.SetActive(false);
        _ControlsCanvas.SetActive(true);
    }

    //Opens the Audio Canvas
    public void ResumeGame()
    {
        _Input.pause = false;
    }
    //Exits the game
    public void EnterMainMenu()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        _Movement.canMove = true;
        SceneController.LoadScene("MainScene");
    }
}
