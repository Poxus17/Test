using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public float jumpForce;
    public float maxJumpTime;
    float elapsedJumpTime;

    Rigidbody2D rigidbody2D;

    bool maxJump;
    bool isJumping;

    Vector2 jumpVector;

    public delegate void Jump(Vector2 direction);
    public static event Jump OnJump;

    // Start is called before the first frame update
    void Start()
    {
        maxJump = false;
        isJumping = false;
        jumpVector = Vector2.up;

        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.Space) && !maxJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnJump(Vector2.up);
            }

            maxJump = elapsedJumpTime > maxJumpTime;
            isJumping = !maxJump;
            elapsedJumpTime += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space)){
            maxJump = true;
            isJumping = false;
        }
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            rigidbody2D.AddForce(jumpVector * jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            maxJump = false;
            isJumping = false;
            elapsedJumpTime = 0;
            //OnJump(Vector2.zero);
        }
    }
}
