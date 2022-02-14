using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        Health = health; 
    }

    public override void Movement()
    {
        base.Movement();

        Vector3 direction = player.transform.localPosition - transform.localPosition;

        if (direction.x > 0 && animator.GetBool("InCombat"))
        {
            sprite.flipX = false;
        }
        else if (direction.x < 9 && animator.GetBool("InCombat"))
        {
            sprite.flipX = true;
        }
    }

    public void Damage(int damageTaken)
    {
        isHit = true;
        Health -= damageTaken;
        if (Health < 0)
        {
            Destroy(gameObject);
            //when death anim implemented, return out of method?
            //return;
        }
        animator.SetBool("InCombat", true);
        animator.SetTrigger("Hit");
    }
}
