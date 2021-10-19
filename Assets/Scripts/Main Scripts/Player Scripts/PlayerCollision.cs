using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerAnimation _Animation;
    private PlayerMovement _Movement;
    private TimmyAudio _Audio;
    [SerializeField] private CameraShaker shaker;

    private void Start()
    {
        _Animation = GetComponent<PlayerAnimation>();
        _Movement = GetComponent<PlayerMovement>();
        _Audio = GetComponent<TimmyAudio>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _Movement.isDead = true;
            _Movement.canMove = false;
            shaker.Shake(0.6f, 0.15f);
            _Animation.PlayDeathAnimation();
            _Audio.DeathAudio();
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
            _Movement.canMove = false;
        }

        if (other.CompareTag("Mom"))
        {
            SceneController.LoadScene("endScene");
        }
    }

    private void ResetScene()
    {
        SceneController.ResetScene();
    }
}