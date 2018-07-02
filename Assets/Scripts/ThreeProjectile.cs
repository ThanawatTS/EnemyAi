using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeProjectile : MonoBehaviour {

    Rigidbody2D rb2d;
    private Transform player;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
    }

    void StraightBullet(Vector3 dir)
    {
       
    }
    void OnBecameInvisible()
    {
        DestroyObject();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("hit");
            DestroyObject();
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
