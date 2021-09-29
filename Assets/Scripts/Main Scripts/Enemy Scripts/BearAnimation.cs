using System;
using UnityEngine;

public class BearAnimation : MonoBehaviour
{
    private BearMovement _Bear;

    private void Start()
    {
        _Bear = GetComponent<BearMovement>();
    }

    private void Update()
    {
        var dir = _Bear.goingRight ? -1f : 1f;
        transform.localScale = new Vector2( dir * 2f, 2f);
    }
}
