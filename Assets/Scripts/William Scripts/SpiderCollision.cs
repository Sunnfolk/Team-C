using System;
using UnityEngine;

public class SpiderCollision : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float range = 1.1f;
    public bool IsGrounded()
    {
        var position = transform.position;
        
        Debug.DrawRay(position, Vector2.down, new Color(1f, 0f, 1f));
        var hit = Physics2D.Raycast(position, Vector2.down, range, whatIsGround);
        return hit.collider != null;
    }

    private void Update()
    {
        print("I am grounded " +IsGrounded());
    }
}