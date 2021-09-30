using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerAnimation _Animation;
    private PlayerMovement _Movement;

    private void Start()
    {
        _Animation = GetComponent<PlayerAnimation>();
        _Movement = GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _Movement.isDead = true;
            _Animation.PlayDeathAnimation();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Door"))
        {
            SceneController.LoadScene(other.gameObject.GetComponent<DoorTargetedScene>().sceneName);
        }

        if (other.CompareTag("Monsterpit"))
        {
            _Movement.diedByPit = true;
            _Movement.isDead = true;
        }
    }

    private void ResetScene()
    {
        SceneController.ResetScene();
    }
}
