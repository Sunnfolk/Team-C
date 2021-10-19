using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _Animator;
    private PlayerMovement _Movement;
    private PlayerInput _Input;
    private Rigidbody2D _Rigidbody;
    private TimmyAudio _Audio;

    // Start is called before the first frame update
    void Start()
    {
        _Animator = GetComponent<Animator>();
        _Movement = GetComponent<PlayerMovement>();
        _Input = GetComponent<PlayerInput>();
        _Rigidbody = GetComponent<Rigidbody2D>();
        _Audio = GetComponent<TimmyAudio>();
        
        _Animator.Play("TimmyRespawn");
    }

    // Update is called once per frame
    void Update()
    {
        if (_Movement.canMove && !_Movement.isDead)
        {
            if (!_Movement.canCoyote)
            {
                if (_Rigidbody.velocity.y > 0)
                {
                    _Animator.Play("TimmyJump");
                }
                else if (_Rigidbody.velocity.y < 0)
                {
                    _Animator.Play("TimmyFall");
                }
            }
            else if (_Input.moveVector.x != 0)
            {
                _Animator.Play("TimmyWalk");
            }
            else
            {
                _Animator.Play("TimmyIdle");
            }

            if (_Input.moveVector.x != 0)
            {
                transform.localScale = new Vector2(_Input.moveVector.x * 2f, 2f);
            }
        }
    }

    public void PlayDeathAnimation()
    {
        _Animator.Play("TimmyDeath");
    }

    private void CanMoveAgain()
    {
        _Movement.canMove = true;
    }

    private void PlayWalkSound()
    {
        _Audio.WalkAudio();
    }

    private void PlayDeathSound()
    {
        _Audio.DeathAudio();
    }
}
