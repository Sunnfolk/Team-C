using UnityEngine;

public class BearAnimation : MonoBehaviour
{
    private BearMovement _Bear;
    private Animator _Animator;
    public Vector2[] armColliderPositions;
    public CameraShaker shaker;

    private void Start()
    {
        _Bear = GetComponent<BearMovement>();
        _Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var dir = _Bear.goingRight ? -1f : 1f;
        transform.localScale = new Vector2( dir * 2f, 2f);

        if (_Bear.walking)
        {
            _Animator.speed = 1;
            _Animator.Play("BearWalk");
        }
        else if (_Bear.attacking)
        {
            _Animator.speed = 1;
            _Animator.Play("BearAttack");
        }
        else if (_Bear.retracting)
        {
            _Animator.speed = 1;
            _Animator.Play("BearRetract");
        }
        else
        {
            _Animator.speed = 1;
            _Animator.Play("BearStuck");
        }
    }

    private void GetStuck()
    {
        _Bear.timer = _Bear.stuckTime;
        _Bear.attacking = false;
    }

    public void MoveArmCollider(int index)
    {
        _Bear.armCollider.transform.localPosition = armColliderPositions[index];
    }

    private void FinishAttack()
    {
        _Bear.retracting = false;
        _Bear.walking = true;
        _Bear.attacking = false;
        _Animator.Play("BearWalk");
    }
    
    private void ShakeScreen()
    {
        shaker.Shake(0.35f, 0.25f);
    }
}
