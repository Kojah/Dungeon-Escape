using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int speed;
    [SerializeField] protected int gems;
    [SerializeField] protected Transform pointA, pointB;

    [SerializeField] protected Vector3 currentTarget = default;
    [SerializeField] protected Animator animator = default;
    [SerializeField] protected SpriteRenderer sprite = default;

    public virtual void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        Movement();
    }

    public virtual void Attack()
    {

    }

    public virtual void Movement()
    {
        if (currentTarget == pointA.position)
        {
            sprite.flipX = true;
        }
        else if (currentTarget == pointB.position)
        {
            sprite.flipX = false;
        }

        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            animator.SetTrigger("Idle");

        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            animator.SetTrigger("Idle");

        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }

    
}
