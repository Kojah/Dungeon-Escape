using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    void Start()
    {
        Init();
    }

    public int Health { get; set; }
    public override void Init()
    {
        base.Init();
        Health = health;
        Debug.Log(health);
    }

    public override void Movement()
    {
        base.Movement();

        Vector3 direction = player.transform.localPosition - transform.localPosition;

        if(direction.x > 0 && animator.GetBool("InCombat"))
        {
            sprite.flipX = false;
        } else if (direction.x < 9 && animator.GetBool("InCombat"))
        {
            sprite.flipX = true;
        }
    }

    public void Damage(int damageTaken)
    {
        isHit = true;
        Health -= damageTaken;
        if(Health < 0)
        {
            Destroy(gameObject);
            //when death anim implemented, return out of method?
            //return;
        }
        animator.SetBool("InCombat", true);
        animator.SetTrigger("Hit");
    }
}
