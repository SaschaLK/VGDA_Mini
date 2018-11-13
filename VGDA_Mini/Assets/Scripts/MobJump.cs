using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobJump : MonoBehaviour {

    // Use this for initialization
    public MobBehavior thisMob;
    private Transform targetPos ;
    public float jumpSpeed = 3f;
    public bool isGround = true;

    private void Awake()
    {
        targetPos = MobManager.getplayerPos();
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        jump();

    }

    void jump() {
        if ((targetPos.position.y - thisMob.transform.position.y) > 0f && isGround)
        {
            //thisMob.transform.Translate(new Vector3(thisMob.rb.velocity.x, jumpSpeed * Time.deltaTime, 0));

            thisMob.GetComponent<Rigidbody2D>().velocity = new Vector2(thisMob.rb.velocity.x,
                (targetPos.position.y - thisMob.transform.position.y) * jumpSpeed);


            isGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        thisMob.GetComponent<Rigidbody2D>().velocity = new Vector2(thisMob.rb.velocity.x, 0);
        isGround = true;
    }

  

}
