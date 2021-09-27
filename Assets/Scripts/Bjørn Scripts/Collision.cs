using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    public LayerMask whatIsGround;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Death"))
        {
            RestartScene();
        }
    }
    
    public bool IsGrounded()
    {
        var pos = transform.position;
        Debug.DrawRay(pos, Vector2.down, new Color(1f,0f,1f));
        var hit = Physics2D.Raycast(pos, Vector2.down, 1.2f, whatIsGround);

        return hit.collider != null;
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
