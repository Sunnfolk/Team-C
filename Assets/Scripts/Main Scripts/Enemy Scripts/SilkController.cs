using System;
using Unity.VisualScripting;
using UnityEngine;

public class SilkController : MonoBehaviour
{
    private Vector2 _StartPos;
    private LineController _Line;
    [SerializeField] private Rigidbody2D _Spider;

    private void Start()
    {
        _Line = GetComponent<LineController>();
        _StartPos = _Spider.position + new Vector2(0f, 1.1f);
    }

    private void Update()
    {
        _Line.AssignTarget(_StartPos, _Spider.position);
    }
}
