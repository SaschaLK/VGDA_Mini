using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBehavior : MonoBehaviour {

    private Transform targetPos;//set target from inspector instead of looking in Update
    public float speed = 3f;
    //public Vector2 targetPos;


    void Start()
    {
        targetPos = MobManager.getplayerPos();
    }

    void Update()
    {

        //rotate to look at the player
        // transform.LookAt(target.position);
        //transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation


        //move towards the player
        if ((targetPos.position.x - transform.position.x) > 0.1f)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        else {
            if ((targetPos.position.x - transform.position.x)  < -0.1f)
            {
                transform.Translate(new Vector3(-1 * speed * Time.deltaTime, 0, 0));
            }
        }


    }

}