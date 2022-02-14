using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }
    public override void Init()
    {
        base.Init();
        Health = health;
    }

    public void Damage(int damageTaken)
    {
        //subtract damage from health
        //if no health, destroy object

        Health -= damageTaken;
        if(Health < 0)
        {
            Destroy(gameObject);
        }
    }
}
