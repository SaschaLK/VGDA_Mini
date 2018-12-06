using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBehavior : MonoBehaviour {

    private Transform targetPos;//set target from inspector instead of looking in Update
    public float speed;
    public GameObject projectilePrefab;
    private Rigidbody2D rb;
    private Animator mobAnimator;
    public bool isFlying;

    private void Awake() {
        LoadProjectile();
    }

    void Start() {
        mobAnimator = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
        targetPos = MobManager.GetPlayerPosition();
    }

    void Update() {
        if (isFlying) {
            Fly();
        }
        else {
            FollowPlayer(); //move towards the player
        }

        Shoot();
    }

    private void LoadProjectile() {
        projectilePrefab = GameObject.Instantiate(projectilePrefab);
        projectilePrefab.SetActive(false);
    }

    private void FollowPlayer() {
        if ((targetPos.position.x - transform.position.x) > 0.1f) {
            transform.Translate(new Vector3(speed * Time.deltaTime, rb.velocity.y, 0));
        }
        else {
            if ((targetPos.position.x - transform.position.x) < -0.1f) {
                transform.Translate(new Vector3(-1 * speed * Time.deltaTime, rb.velocity.y, 0));
            }
        }
    }

    private void Fly() {
        if(targetPos.position != transform.position) {
            rb.velocity = new Vector2((targetPos.position.x - transform.position.x) * .3f, (targetPos.position.y - transform.position.y) * .3f);
        }
    }

    private void Shoot() {
        if (!projectilePrefab.activeSelf) {
            mobAnimator.SetTrigger("Attack");
            projectilePrefab.SetActive(true);
            projectilePrefab.transform.position = this.transform.position;
            projectilePrefab.GetComponent<Rigidbody2D>().velocity = new Vector2((targetPos.position.x - transform.position.x) * .3f, (targetPos.position.y - transform.position.y) * .3f);
            Invoke("KillProjectile", 4f);
        }

    }

    private void KillProjectile() {
        projectilePrefab.SetActive(false);
    }
}