﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    public Transform playerTransform;
    public float shootRange = 100f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Did");
            RaycastHit hit;
            Vector2 raycastDir = Input.mousePosition - playerTransform.position  ;
            


            Debug.DrawRay(playerTransform.position,raycastDir, Color.red, 5);
            if (Physics.Raycast(playerTransform.position, raycastDir, out hit, shootRange))
            {
                hit.collider.gameObject.SetActive(false);
                Debug.Log("Did  Hit");
            }
            //shoot();
        }


    }

    public void shoot() {
       
        RaycastHit hit;
        if (Physics.Raycast(playerTransform.position, Input.mousePosition, out hit, shootRange))
        {
            hit.collider.gameObject.SetActive(false);
        }
    }

}