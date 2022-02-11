using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected int health;
    protected int speed;
    protected int gems;

    public virtual void Attack()
    {

    }

    public abstract void Update();
}
