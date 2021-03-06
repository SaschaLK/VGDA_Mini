﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    public static PlayerControler instance;

    public Rigidbody2D myRigidBody; //player RigidBody
    public float jumpForce = 4;
    public float movementSpeed = 5;
    public float deathTime;
    private bool isAlive;
    private bool onFloor = true; //to see if it's grounded
    private float horizontalInput;
    private Vector3 right = new Vector3(-1,1,1);
    private Vector3 left = new Vector3(1,1,1);
    private Animator playerAnimator;
    private SpriteRenderer sr;
    private AudioSource audioSource;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        playerAnimator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        sr.enabled = true;
        isAlive = true;
    }

    private void Update() {
        MovePlayer();
    }

    // this function makes the player move left, right and jump.
    private void MovePlayer() {
        if(Input.GetAxis("Horizontal") > 0.5) {
            transform.localScale = right;
            playerAnimator.SetTrigger("playerWalk");
        }
        else if(Input.GetAxis("Horizontal") < -0.5) {
            transform.localScale = left;
            playerAnimator.SetTrigger("playerWalk");
        }
        else {
            playerAnimator.SetTrigger("playerIdle");
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, 0, 0);

        if (Input.GetButtonDown("Jump") && onFloor) {
            myRigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            onFloor = false;
        }
    }
    //check the collision with the floor to avoid jumping in the air

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Floor") && onFloor == false) {
            onFloor = true;
        }
        if (other.gameObject.CompareTag("Enemy") && isAlive) {
            isAlive = false;
            sr.enabled = false;
            audioSource.Play();
            Invoke("Die", deathTime);
        }
    }

    private void Die() {
        GameManagerBehaviour.instance.GoBackToMainMenu();
    }
}


