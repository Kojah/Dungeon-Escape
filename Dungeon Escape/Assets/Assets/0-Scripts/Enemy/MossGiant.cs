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

    public void Damage(int damageTaken)
    {
        isHit = true;
        Health -= damageTaken;
        if (Health <= 0)
        {
            isDead = true;
            animator.SetTrigger("Death");
            dropLoot(gems);
            //when death anim implemented, return out of method?
            //return;
        }
        animator.SetBool("InCombat", true);
        animator.SetTrigger("Hit");
    }
}
