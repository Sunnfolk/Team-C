using Cinemachine;
using UnityEngine;

public class CameraMoveVertical : MonoBehaviour
{
    private PlayerInput _Input;
    [SerializeField] private float maxOffset = 2f;
    private float _Offset;
    private float _Timer;
    [SerializeField] private float _TimeBeforeCameraMove = 0.5f;
    [SerializeField] private float _MoveSpeed = 0.6f;
    
    /* Cinemachine */


    private void Start()
    {
        _Input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        
        if (_Input.moveVector.y > 0)
        {
            _Timer -= Time.deltaTime;
            if (_Timer <= 0)
            {
                
            }
        }
        else if (_Input.moveVector.y > 0)
        {
            _Timer -= Time.deltaTime;
            if (_Timer <= 0)
            {

            }
        }
        else
        {
            _Timer = _TimeBeforeCameraMove;
        }
    }
}
