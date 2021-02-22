using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlatformerPlayerController2D : MonoBehaviour
{
    public delegate void ChangeDirection(Vector2 direction);
    public static event ChangeDirection OnChangeDirection; //This event announces any CHANGE in direction

    Rigidbody2D rigidbody2D;

    public float speed;
    public float jumpForce;

    Vector2 previousPosition; // Keeps track of the position in the previous frame
    bool isMoving;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {

        float inputX = Input.GetAxis("Horizontal");

        movement = new Vector2(
            speed * inputX,
            0);

        if(movement.x == 0){
            //OnChangeDirection(Vector2.zero);
        }
        else
        {
            OnChangeDirection(((movement.x > 0) ? Vector2.right : Vector2.left));
        }


        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = movement;
    }

    void Movement()
    {
        Vector2 newPos;
        newPos = transform.position;

        if (Input.GetKey(KeyCode.A))
        {
            newPos.x -= speed * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.A) && OnChangeDirection != null)
            {
                OnChangeDirection(Vector2.left);
                isMoving = true;
            }

        }
        if (Input.GetKey(KeyCode.D))
        {
            newPos.x += speed * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.D) && OnChangeDirection != null)
            {
                OnChangeDirection(Vector2.right);
                isMoving = true;
            }
        }

        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && isMoving)
        {
            OnChangeDirection(Vector2.zero);
            isMoving = false;
        }

        rigidbody2D.MovePosition(newPos);
    }
}
