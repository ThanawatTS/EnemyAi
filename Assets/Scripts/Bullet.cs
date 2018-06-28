﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;

    private Transform player;
    private Vector2 target;
    private Vector3 dir;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
	}
	
	// Update is called once per frame
	void Update () {
        StraightBullet();
	}

    void StraightBullet()
    {
        Vector2 minCam = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 maxCam = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
       
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