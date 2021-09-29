using System;
using UnityEngine;

public class CameraMoveVertical : MonoBehaviour
{
    private PlayerInput _Input;
    [SerializeField] private float maxOffset = 2f;
    private float offset;

    private void Start()
    {
        _Input = GetComponent<PlayerInput>();
    }
}
