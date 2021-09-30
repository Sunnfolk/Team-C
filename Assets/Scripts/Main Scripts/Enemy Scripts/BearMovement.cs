using UnityEngine;

public class BearMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _Positions;
    
    private int _NextPosIndex;
    private Transform _NextPos;
    [SerializeField] private float moveSpeed;
    public GameObject armCollider;
    public GameObject armJumpable;
    public GameObject headCollider;
    
    public bool walking = true;
    public bool attacking;
    public bool retracting;

    public float stuckTime = 6f;
    [HideInInspector] public float timer;

    public bool goingRight;

    private void Start()
    {
        _NextPos = _Positions[0];
    }

    private void Update()
    {
        if (walking) MoveGameObject();
        else if (!attacking && !retracting)
        {
            if (timer <= 0)
            {
                retracting = true;
            }
            else timer -= Time.deltaTime;
        }

        if (!walking && !attacking && !retracting)
        {
            armCollider.SetActive(false);
            headCollider.SetActive(false);
            armJumpable.SetActive(true);
        }
        else
        {
            armCollider.SetActive(true);
            headCollider.SetActive(true);
            armJumpable.SetActive(false);
        }
    }

    private void MoveGameObject()
    {
        //Change to next point in list & attack
        if (transform.position == _NextPos.position)
        {
            walking = false;
            attacking = true;
            
            _NextPosIndex++;
            if (_NextPosIndex >= _Positions.Length)
            {
                _NextPosIndex = 0;
            }

            _NextPos = _Positions[_NextPosIndex];
        }
        //Move towards point
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _NextPos.position, moveSpeed * Time.deltaTime);
            
            if (transform.position.x < _NextPos.position.x) goingRight = true;
            else if (transform.position.x > _NextPos.position.x) goingRight = false;
        }
    }
}
