using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Rigidbody2D rigidBody = default;
    [SerializeField] private float jumpForce = 5;
    [SerializeField] private bool grounded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Raycast layer mask is a 32bit interger array
        //To modify it, a bit has to be present on index 8
        //This is why there is a bit shift to place a 1 at index 8
        RaycastHit2D groundHit = Physics2D.Raycast(transform.position, -Vector2.up, 0.8f, 1 << 8);
        Debug.DrawRay(transform.position, -Vector2.up * 0.8f, Color.red);

        if(groundHit.collider != null)
        {
            Debug.Log($"Hit {groundHit.collider.name}");
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        float move = Input.GetAxisRaw("Horizontal");

        //if input space and grounded
        //add jump force
        if(Input.GetButtonDown("Jump") && grounded)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
            //snierp
        }

        rigidBody.velocity = new Vector2(move, rigidBody.velocity.y);
    }
}
