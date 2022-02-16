using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerAnimation playerAnimation = default;
    [SerializeField] private SpriteRenderer playerSprite = default;
    [SerializeField] private SpriteRenderer swordArcSprite = default;
    [SerializeField] private Rigidbody2D rigidBody = default;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float speed = 5.0f;

    private bool resetJump = false;
    private bool isGrounded = false;

    public int Health { get; set; }
    public int diamonds = 0;

    void Start()
    {
        Health = 5;
    }

    void Update()
    {
        Movement();

        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            playerAnimation.AttackTransition();
        }
    }

    public void Damage(int damageTaken)
    {
        Debug.Log("player hurt");
        Health -= damageTaken;

        if(Health < 0)
        {
            playerAnimation.DeathTransition();
        }
    }

    private void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        isGrounded = IsGrounded();

        if (move < 0)
        {
            Flip(false);
        } else if (move > 0)
        {
            Flip(true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
            StartCoroutine(ResetJumpRoutine());
            playerAnimation.JumpTransition(true);
        }

        rigidBody.velocity = new Vector2(move * speed, rigidBody.velocity.y);
        playerAnimation.MoveTransition(move);
    }

    private void Flip(bool faceRight)
    {

        if (faceRight)
        {
            playerSprite.flipX = false;
            //swordArcSprite.flipX = false;
            swordArcSprite.flipY = false;
            Vector3 newPos = swordArcSprite.transform.localPosition;
            newPos.x = 1.01f;
            swordArcSprite.transform.localPosition = newPos;
        }
        else
        {
            playerSprite.flipX = true;
            //swordArcSprite.flipX = true;
            swordArcSprite.flipY = true;
            Vector3 newPos = swordArcSprite.transform.localPosition;
            newPos.x = -1.01f;
            swordArcSprite.transform.localPosition = newPos;
        }
        
    }

    private bool IsGrounded()
    {
        //Raycast layer mask is a 32bit interger array
        //To modify it, a bit has to be present on index 8
        //This is why there is a bit shift to place a 1 at index 8
        RaycastHit2D groundHit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down * 0.8f, Color.green);

        if(groundHit.collider != null)
        {
            if (!resetJump)
            {
                playerAnimation.JumpTransition(false);
                return true;
            }
        }
        return false;
    }    

    private IEnumerator ResetJumpRoutine()
    {
        resetJump = true;
        yield return new WaitForSeconds(0.1f);
        resetJump = false;
    }

    public void AddGems(int gems)
    {
        diamonds += gems;
        UIManager.Instance.UpdateGemCount(diamonds);
    }
}
