using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator = default;

    public void MoveTransition(float moveValue)
    {
        Debug.Log(moveValue);
        animator.SetFloat("Move", Mathf.Abs(moveValue));
    }
}
