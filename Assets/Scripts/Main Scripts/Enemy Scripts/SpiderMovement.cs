using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    private float Timer;
    private bool HitGround;
    private Rigidbody2D m_Rigidbody2D;
    public string action = "idle";
    
    public float UpTimerCount;
    public float TimerStartAt;
    public float DownTimerCount;

    private Collision _Collision;

    private void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        _Collision = GetComponent<Collision>();
        Timer = TimerStartAt;
        m_Rigidbody2D.gravityScale = 0;
    }
    
    private void Update()
    {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        else if (Timer <= 0 && !HitGround)
        {
            m_Rigidbody2D.gravityScale = 2.2f;
            action = "down";
        }
        else if (Timer <= 0 && HitGround)
        {
            transform.Translate(Vector2.up * Time.deltaTime * 2.8f);
            action = "up";
        }

        if (Timer <= 0)
        {
            if (action == "down")
            {
                if (_Collision.IsGrounded(transform.position, 1f))
                {
                    m_Rigidbody2D.gravityScale = 0;
                    HitGround = true;
                    Timer = UpTimerCount;
                    action = "attack";
                }
            }
            
            else if (action == "up")
            {
                if (_Collision.IsGrounded(transform.position, -1f))
                {
                    HitGround = false;
                    Timer = DownTimerCount;
                    action = "idle";
                }
            }
        }
    }
}
