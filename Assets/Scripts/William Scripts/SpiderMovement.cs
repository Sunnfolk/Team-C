using System.Timers;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    private float _FallSpeed = 2f;

    private float SpiderAttackTimer;
    private float ResetTimer = 4f;
    private Rigidbody2D _Rigidbody2D;
    private Collision _Collision;

    private string _Action = "idle";

    void Start()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        _Collision = GetComponent<Collision>();
        
        SpiderAttackTimer = ResetTimer;
    }
    
    void Update()
    {
        if (_Action == "idle")
        {
            SpiderAttackTimer -= Time.deltaTime;

            if (SpiderAttackTimer <= 0)
            {
                _Action = "down";
                SpiderAttackTimer = ResetTimer;
            }
        }
        else if (_Action == "down")
        {
            Move(-_FallSpeed);
        }
        else if (_Action == "attack")
        {
            print("attack");
            _Action = "up";
        }
        else if (_Action == "up")
        {
            Move(_FallSpeed);
        }
    }

    private void Move(float y)
    {
        _Rigidbody2D.velocity = new Vector2(0f, y);
        if (_Collision.IsGrounded())
        {
            _Action = "attack";
        }
    }
    
}
