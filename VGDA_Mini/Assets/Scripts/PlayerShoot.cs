using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    public Transform playerTransform;
    public float shootRange = 100f;
    // Use this for initialization
    Camera cam;
	void Start () {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }

    public void shoot() {

        //RaycastHit hit;

        Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

        Vector2 raycastDir = new Vector2(mousePos.x - playerTransform.position.x, mousePos.y - playerTransform.position.y);


        //Debug.Log("X");
        // Debug.Log(raycastDir.x);
  

        Debug.DrawRay(playerTransform.position, raycastDir, Color.red, 5);


        //if (Physics.Raycast(playerTransform.position, raycastDir, out hit, shootRange)) // DOESNT WORK FOR 2D STUFF
       // {
         //   hit.collider.gameObject.SetActive(false);
         //   Debug.Log("Did  Hit");
       // }
     




         RaycastHit2D hitt = Physics2D.Raycast(playerTransform.position, raycastDir);

        if (hitt.collider != null)
        {

            if (hitt.collider.tag == "Enemy") {
                hitt.collider.gameObject.SetActive(false);
                Debug.Log("Did  Hit");
            }
            
            
        }
    }

}
