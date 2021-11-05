using UnityEngine;

public class BearJumpableArmMove : MonoBehaviour
{
    public GameObject armCollider;

    private void Update()
    {
        transform.position = armCollider.transform.position;
    }
}
