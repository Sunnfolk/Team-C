using UnityEngine;

public class Collision : MonoBehaviour
{
    private SceneController _sceneController;
    
    public LayerMask whatIsGround;

    private void Start()
    {
        _sceneController = GetComponent<SceneController>();
    }

    //TODO Add deathpit collision

    public bool IsGrounded()
    {
        var pos = transform.position;
        Debug.DrawRay(pos, Vector2.down, new Color(1f,0f,1f));
        var hit = Physics2D.Raycast(pos, Vector2.down, 1.2f, whatIsGround);

        return hit.collider != null;
    }
}