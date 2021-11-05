using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer _Line;

    private Vector3 target;

    private void Start()
    {
        _Line = GetComponent<LineRenderer>();
    }

    public void AssignTarget(Vector3 start, Vector3 newTarget)
    {
        _Line.positionCount = 2;
        _Line.SetPosition(0,start);
        target = newTarget;
    }

    private void Update()
    {
        _Line.SetPosition(1, target);
    }
}
