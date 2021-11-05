using UnityEngine;
using UnityEngine.EventSystems;

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
    
    [SerializeField] private GameObject pauseFirstButton, audioFirstButton, audioClosedButton, controlsFirstButton, controlsClosedButton;

    private void Start()
    {
        _PauseCanvas.SetActive(false);
        _AudioCanvas.SetActive(false);
    }
    
    private void Update()
    {
        if (_Input.goBackInMenu)
        {
            if (_AudioCanvas.activeSelf) EnterPause(audioClosedButton);
            else if (_ControlsCanvas.activeSelf) EnterPause(controlsClosedButton);
            else _Input.pause = false;
        }
        //Opens and closes pause menu when _Input.pause was pressed this frame
        if (_Input.pause && !_WasPaused)
        {
            _PauseCanvas.SetActive(true);
            _AudioCanvas.SetActive(false);
            _ControlsCanvas.SetActive(false);
            _WasPaused = true;
        }
        else if (!_Input.pause && _WasPaused)
        {
            _PauseCanvas.SetActive(false);
            _AudioCanvas.SetActive(false);
            _ControlsCanvas.SetActive(false);
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
            
            UISetSelected(pauseFirstButton);
        }
        //Unpauses game
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
        
        UISetSelected(audioFirstButton);
    }
    public void EnterPause(GameObject obj)
    {
        _PauseCanvas.SetActive(true);
        _AudioCanvas.SetActive(false);
        _ControlsCanvas.SetActive(false);
        
        UISetSelected(obj);
    }
    
    public void EnterControls()
    {
        _AudioCanvas.SetActive(false);
        _PauseCanvas.SetActive(false);
        _ControlsCanvas.SetActive(true);
        
        UISetSelected(controlsFirstButton);
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

    //Set selected UI object
    public void UISetSelected(GameObject obj)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(obj);
    }
}
