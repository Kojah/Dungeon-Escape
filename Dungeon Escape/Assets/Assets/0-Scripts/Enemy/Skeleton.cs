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
