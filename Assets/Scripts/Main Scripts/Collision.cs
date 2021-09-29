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

    //Uses a start position "pos" and a distance "dist" to check if a point under the start position is "ground"
    public bool IsGrounded(Vector3 pos, float dist)
    {
        Debug.DrawRay(pos, Vector2.down, new Color(1f,0f,1f));
        var hit = Physics2D.Raycast(pos, Vector2.down, dist, whatIsGround);

        return hit.collider != null;
    }
}