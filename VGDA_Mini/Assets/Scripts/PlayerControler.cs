using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    public Rigidbody2D myRigidBody; //player RigidBody
    public float jumpForce = 4;
    public float movementSpeed = 5;
    private bool onFloor = true; //to see if it's grounded

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    // this function makes the player move left, right and jump.
    void movePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, 0, 0);

        if (Input.GetButtonDown("Jump") && onFloor)
        {
            myRigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            onFloor = false;
        }
    }
    //check the collision with the floor to avoid jumping in the air
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor") && onFloor == false)
        {
            onFloor = true;
        }
    }
}


