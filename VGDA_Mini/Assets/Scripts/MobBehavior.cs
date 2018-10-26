using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBehavior : MonoBehaviour {

    private Transform targetPos;//set target from inspector instead of looking in Update
    public float speed = 3f;
    public GameObject projectilePrefab;
    //public Vector2 targetPos;

    private void Awake()
    {
        LoadProjectile();
    }

    private void LoadProjectile()
    {
        projectilePrefab = GameObject.Instantiate(projectilePrefab);
        projectilePrefab.SetActive(false);
    }

    private void FollowPlayer()
    {
        if ((targetPos.position.x - transform.position.x) > 0.1f)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        else
        {
            if ((targetPos.position.x - transform.position.x) < -0.1f)
            {
                transform.Translate(new Vector3(-1 * speed * Time.deltaTime, 0, 0));
            }
        }
    }

    private void Shoot() {
        if (!projectilePrefab.activeSelf) {
            projectilePrefab.SetActive(true);
            projectilePrefab.transform.position = this.transform.position;
            projectilePrefab.GetComponent<Rigidbody2D>().velocity = 
                new Vector2((targetPos.position.x - transform.position.x)* .3f,
                (targetPos.position.y - transform.position.y) * .3f);

            Invoke("killProjectile", 4f);

        }

    }

    void Start()
    {
        targetPos = MobManager.getplayerPos();
    }

    void Update()
    {

        FollowPlayer(); //move towards the player
        Shoot();

    }

    private void killProjectile()
    {
        projectilePrefab.SetActive(false);
    }

}