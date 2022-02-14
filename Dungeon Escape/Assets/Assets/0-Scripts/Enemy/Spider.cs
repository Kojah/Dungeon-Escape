using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public GameObject acidPrefab = default;
    public int Health { get; set; }
    public override void Init()
    {
        base.Init();
        Health = health;
    }

    public override void Update()
    {
        
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
        //animator.SetBool("InCombat", true);
        //animator.SetTrigger("Hit");
    }

    public void Attack()
    {
        Instantiate(acidPrefab, transform.position, Quaternion.identity);
    }

    public override void Movement()
    {
        //codesmell to sit still
    }
}
