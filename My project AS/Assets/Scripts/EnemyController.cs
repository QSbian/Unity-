using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5;
    public bool vertical;
    public float changeTime = 3.0f;
    
    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    bool broken = true;

    Animator animator;
    
    public ParticleSystem smokeEffect;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(!broken)
        {
            return;
        }

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
        //注意，! 符号可以反转测试，因此，如果 broken 为 true，则 !broken 将为 false，并且不会执行 return。
        
    }
    void FixedUpdate()
    {
        if (!broken)
        {
            return;
        }

        Vector2 position = rigidbody2D.position;
        if (vertical)
        {
            position.x += speed * Time.deltaTime * direction;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        else
        {
            position.y += speed * Time.deltaTime * direction;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        rigidbody2D.MovePosition(position);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);

        }
    }
    // 使用 public 可以让这个函数可以多次调用
    public void Fix()
    {
        broken = false;
        rigidbody2D.simulated = false;

        animator.SetTrigger("Fixed");

        smokeEffect.Stop();
    }
}
