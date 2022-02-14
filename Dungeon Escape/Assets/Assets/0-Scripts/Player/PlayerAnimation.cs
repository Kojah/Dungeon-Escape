using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator = default;
    [SerializeField] private Animator swordAnimator = default;

    public void MoveTransition(float moveValue)
    {
        playerAnimator.SetFloat("Move", Mathf.Abs(moveValue));
    }

    public void JumpTransition(bool jumping)
    {
        playerAnimator.SetBool("Jumping", jumping);
    }

    public void AttackTransition()
    {
        playerAnimator.SetTrigger("Attack");
        swordAnimator.SetTrigger("SwordAnimation");
    }

    public void DeathTransition()
    {
        playerAnimator.SetTrigger("Death");
    }
}
