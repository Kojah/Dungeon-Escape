using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody = default;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float speed = 5.0f;

    private bool resetJump = false;

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(move * speed, rigidBody.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
            StartCoroutine(ResetJumpRoutine());
        }
    }

    private bool IsGrounded()
    {
        //Raycast layer mask is a 32bit interger array
        //To modify it, a bit has to be present on index 8
        //This is why there is a bit shift to place a 1 at index 8
        RaycastHit2D groundHit = Physics2D.Raycast(transform.position, Vector2.down, 0.7f, 1 << 8);

        if(groundHit.collider != null)
        {
            if(!resetJump)
                return true;
        }

        return false;
    }    

    private IEnumerator ResetJumpRoutine()
    {
        resetJump = true;
        yield return new WaitForSeconds(0.1f);
        resetJump = false;
    }
}
