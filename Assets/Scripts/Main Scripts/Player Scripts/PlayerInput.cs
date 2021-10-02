using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    [HideInInspector] public Vector2 moveVector;
    [HideInInspector] public bool jump;
    [HideInInspector] public bool longJump;
    [HideInInspector] public bool playMusic = true;
    [HideInInspector] public bool pause;

    private void Update()
    {
        moveVector.x = (Keyboard.current.dKey.isPressed ? 1f : 0f) + (Keyboard.current.aKey.isPressed ? -1f : 0f);
        moveVector.y = (Keyboard.current.wKey.isPressed ? 1f : 0f) + (Keyboard.current.sKey.isPressed ? -1f : 0f);

        jump = Keyboard.current.spaceKey.wasPressedThisFrame;
        longJump = Keyboard.current.spaceKey.isPressed;

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneController.ResetScene();
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            SceneController.LoadScene("MainMenuVideo");
        }
        if (Keyboard.current.mKey.wasPressedThisFrame)
        {
            playMusic = !playMusic;
            print(playMusic);
        }
        
    }
}