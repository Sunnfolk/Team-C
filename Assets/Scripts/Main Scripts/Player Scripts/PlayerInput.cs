using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [HideInInspector] public Vector2 moveVector;
    [HideInInspector] public bool jump;
    [HideInInspector] public float longJump;
    [HideInInspector] public bool pause;
    [HideInInspector] public bool goBackInMenu;
    
    //Get Input Controls
    private InputActions _Input;
    
    private void Awake()
    {
        _Input = new InputActions();
    }
    private void OnEnable()
    {
        _Input.Enable();
    }
    private void OnDisable()
    {
        _Input.Disable();
    }
    
    
    
    private void Update()
    {
        moveVector = _Input.Player.Move.ReadValue<Vector2>();

        jump = _Input.Player.Jump.triggered;
        longJump = _Input.Player.Jump.ReadValue<float>();

        goBackInMenu = _Input.Player.GoBackInMenu.triggered;

        if (_Input.Player.ResetLevel.triggered && !pause)
        {
            SceneController.ResetScene();
        }

        if (_Input.Player.Pause.triggered)
        {
            pause = !pause;
        }
    }
}