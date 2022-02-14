using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int gems;
    [SerializeField] protected Transform pointA, pointB;

    [SerializeField] protected Vector3 currentTarget = default;
    [SerializeField] protected Animator animator = default;
    [SerializeField] protected SpriteRenderer sprite = default;
    [SerializeField] protected Player player;

    protected bool isHit = false;

    //for later
    public virtual void Init()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public virtual void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && animator.GetBool("InCombat") == false)
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

        if(!isHit)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }
        //if distance between enemy and player is greater than 2 units, isHit is set to faux
        //set is InCombat to FAUX also

        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        if(distance > 2)
        {
            isHit = false;
            animator.SetBool("InCombat", false);
        }

        Vector3 direction = player.transform.localPosition - transform.localPosition;

        if (direction.x > 0 && animator.GetBool("InCombat"))
        {
            sprite.flipX = false;
        }
        else if (direction.x < 0 && animator.GetBool("InCombat"))
        {
            sprite.flipX = true;
        }
    }


}
