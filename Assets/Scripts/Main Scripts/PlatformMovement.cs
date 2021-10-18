using System;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _Positions;
    private int _NextPosIndex;
    private Transform _NextPos;
    
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float pauseLength;
    private bool pausing;
    private float pauseTimer;

    private void Start()
    {
        _NextPos = _Positions[0];
    }

    private void Update()
    {
        MoveGameObject();
    }

    private void MoveGameObject()
    {
        //Change to next point in list & attack
        if (transform.position == _NextPos.position)
        {
            pausing = true;
            pauseTimer = pauseLength;
            
            _NextPosIndex++;
            if (_NextPosIndex >= _Positions.Length)
            {
                _NextPosIndex = 0;
            }

            _NextPos = _Positions[_NextPosIndex];
        }
        //Move towards point
        else if (!pausing)
        {
            transform.position = Vector3.MoveTowards(transform.position, _NextPos.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            pauseTimer -= Time.deltaTime;
            if (pauseTimer < 0)
            {
                pausing = false;
            }
        }
    }
}
