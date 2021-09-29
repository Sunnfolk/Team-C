using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isDead = false;
    
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float maxVelocity = 24f;
    
    /* COMPONENTS */
    private PlayerInput _Input;
    private Rigidbody2D _Rigidbody2D;
    private Collision _Collision;

    /* LONG JUMP */
    [HideInInspector] public bool isJumping;
    private float _JumpTimeCounter;
    [SerializeField] private float jumpTime = 0.3f;
    
    /* COYOTE TIME */
    [SerializeField] private float coyoteTime;
    private float _CoyoteTimeCounter;
    [HideInInspector] public bool canCoyote;
    
    /* MISC */
    public float fallDistance;

    private void Start()
    {
        _Input = GetComponent<PlayerInput>();
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        _Collision = GetComponent<Collision>();
    }

    private void Update()
    {
        if (!isDead)
        {
            LongJump();
            Coyote();

            Jump();

            SetMaxVelocity();

            DistanceFallen();
        }
        else
        {
            //TODO Death Animation and Reset Scene
        }
    }

    private void LongJump()
    {
        if (_Input.longJump && isJumping)
        {
            if (_JumpTimeCounter > 0)
            {
                _Rigidbody2D.velocity = Vector2.up * jumpForce;
                _JumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (!_Input.longJump)
        {
            isJumping = false;
        }
    }

    private void FixedUpdate()
    {
        _Rigidbody2D.velocity = new Vector2(_Input.moveVector.x * moveSpeed, _Rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        if (_Input.jump)
        {
            if (!canCoyote) return;
            
            isJumping = true;
            _JumpTimeCounter = jumpTime;
            _Rigidbody2D.velocity = new Vector2(_Rigidbody2D.velocity.x, jumpForce);
        }
    }

    private void Coyote()
    {
        if (CheckGroundCollision())
        {
            canCoyote = true;
            _CoyoteTimeCounter = coyoteTime;
        }
        else if (_Rigidbody2D.velocity.y <= 0)
        {
            _CoyoteTimeCounter -= Time.deltaTime;
        }
        else
        {
            canCoyote = false;
        }

        if (_CoyoteTimeCounter < 0)
        {
            canCoyote = false;
        }
    }

    private void SetMaxVelocity()
    {
        if (CheckGroundCollision()) return;
        if (_Rigidbody2D.velocity.y < -maxVelocity)
        {
            _Rigidbody2D.velocity = new Vector2(_Rigidbody2D.velocity.x, -maxVelocity);
        }
    }

    private void DistanceFallen()
    {
        if (_Rigidbody2D.velocity.y < 0)
        {
            fallDistance -= _Rigidbody2D.velocity.y * Time.deltaTime;
        }
        else fallDistance = 0;
    }

    public bool CheckGroundCollision()
    {
        return _Collision.IsGrounded(transform.position + new Vector3(-0.2f, 0f, 0f), 1.1f) ||
               (_Collision.IsGrounded(transform.position + new Vector3(0.2f, 0f, 0f), 1.1f));
    }   
}