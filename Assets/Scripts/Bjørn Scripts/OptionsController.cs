using UnityEngine;

public class OptionsController : MonoBehaviour
{
    [SerializeField] private PlayerInput _Input;
    [SerializeField] private GameObject _PauseCanvas;
    [SerializeField] private GameObject _OptionsCanvas;

    private bool _WasPaused;

    private void Start()
    {
        _PauseCanvas.SetActive(false);
        _OptionsCanvas.SetActive(false);
    }

    private void Update()
    {
        //Opens and closes pause menu when _Input.pause was pressed this frame
        if (_Input.pause && !_WasPaused)
        {
            _PauseCanvas.SetActive(true);
            _OptionsCanvas.SetActive(false);
            _WasPaused = true;
        }
        else if (!_Input.pause && _WasPaused)
        {
            _PauseCanvas.SetActive(false);
            _OptionsCanvas.SetActive(false);
            _WasPaused = false;
        }
    }

    public void EnterOptions()
    {
        _PauseCanvas.SetActive(false);
        _OptionsCanvas.SetActive(true);
    }
    public void ExitOptions()
    {
        _OptionsCanvas.SetActive(false);
        _PauseCanvas.SetActive(true);
    }

    public void ResumeGame()
    {
        _Input.pause = false;
    }

    public void ExitGame()
    {
        SceneController.QuitGame();
    }
}
