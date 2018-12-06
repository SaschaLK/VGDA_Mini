using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBehavior : MonoBehaviour {

    private Transform targetPos;//set target from inspector instead of looking in Update
    public float speed = 3f;
    public GameObject projectilePrefab;
    private Rigidbody2D rb;

    private void Awake() {
        LoadProjectile();
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Start() {
        targetPos = MobManager.GetPlayerPosition();
    }

    void Update() {
        FollowPlayer(); //move towards the player
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

    private void Shoot() {
        if (!projectilePrefab.activeSelf) {
            projectilePrefab.SetActive(true);
            projectilePrefab.transform.position = this.transform.position;
            projectilePrefab.GetComponent<Rigidbody2D>().velocity =
                new Vector2((targetPos.position.x - transform.position.x) * .3f,
                (targetPos.position.y - transform.position.y) * .3f);
            Invoke("KillProjectile", 4f);
        }

    }

    private void KillProjectile() {
        projectilePrefab.SetActive(false);
    }
}