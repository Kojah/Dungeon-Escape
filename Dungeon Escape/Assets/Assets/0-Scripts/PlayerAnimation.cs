using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator = default;

    public void MoveTransition(float moveValue)
    {
        animator.SetFloat("Move", Mathf.Abs(moveValue));
    }

    public void JumpTransition(bool jumping)
    {
        animator.SetBool("Jumping", jumping);
    }

    public void AttackTransition()
    {
        animator.SetTrigger("Attack");
    }
}
