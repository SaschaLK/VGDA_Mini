﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MobManager : MonoBehaviour {

    private static MobManager thisInstance;
    public  Transform playerPos;
    public GameObject mobPrefab;
    private int mobCount = 0;
    public int maxMob = 5;
    public Transform spawnPoint;

    // Use this for initialization

    private void Awake()
    {
        if (thisInstance == null)
        {
            thisInstance = this;
            DontDestroyOnLoad(thisInstance);
        }

    }
    void Start () {
        spawnMob();



    }
	
	// Update is called once per frame
	void Update () {

    }


    public static Transform getplayerPos()
    {

        return thisInstance.playerPos;
    }

    private void spawnMob() {

        if (thisInstance.mobCount < thisInstance.maxMob) {
            GameObject mobb = GameObject.Instantiate(thisInstance.mobPrefab);
            mobb.transform.position = thisInstance.spawnPoint.position;
            thisInstance.mobCount++;
            
        }

        thisInstance.Invoke("spawnMob", 5f);

    }

   


   
}
