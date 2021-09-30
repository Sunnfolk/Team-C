using UnityEngine;

public class BearMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _Positions;
    
    private int _NextPosIndex;
    private Transform _NextPos;
    [SerializeField] private float moveSpeed;

    public bool goingRight;

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
        if (transform.position == _NextPos.position)
        {
            _NextPosIndex++;
            if (_NextPosIndex >= _Positions.Length)
            {
                _NextPosIndex = 0;
            }

            _NextPos = _Positions[_NextPosIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _NextPos.position, moveSpeed * Time.deltaTime);
            if (transform.position.x < _NextPos.position.x) goingRight = true;
            else goingRight = false;
        }
    }
}
