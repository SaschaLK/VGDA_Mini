using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour {

    // Use this for initialization

    private void Awake()
    {
        Invoke("SelfDestruct", 4f);
    }
    //void Start () {

    //}

    // Update is called once per frame
    //void Update () {

    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
    }

    private void SelfDestruct()
    {
        this.gameObject.SetActive(false);
    }
}
