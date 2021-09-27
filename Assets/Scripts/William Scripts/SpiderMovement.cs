using System;
using System.Timers;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    private float Timer;
    private bool HitGround = false;
    private Rigidbody2D m_Rigidbody2D;
    public float UpTimerCount;
    public float DownTimerCount;

    private void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        Timer = DownTimerCount;
        m_Rigidbody2D.gravityScale = 0;
    }
    
    private void Update()
    {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        else if (Timer <= 0 && HitGround == false)
        {
            m_Rigidbody2D.gravityScale = 3;
        }
        else if (Timer <= 0 && HitGround == true)
        {
            transform.Translate(Vector2.up * Time.deltaTime * 1.8f);
        }

  
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            m_Rigidbody2D.gravityScale = 0;
            HitGround = true;
            Timer = UpTimerCount;
        }
        else if (other.transform.CompareTag("Top"))
        {
            HitGround = false;
            Timer = DownTimerCount;
        }
    }
}
