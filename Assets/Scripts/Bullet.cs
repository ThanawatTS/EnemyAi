using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;

    Rigidbody2D rb2d;
    private Transform player;
    private Vector3 dir;
    
    
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = GetComponent<Rigidbody2D>();
        dir = Vector3.Normalize(player.position - this.transform.position);
       
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        StraightBullet(dir);
    }

    void StraightBullet(Vector3 dir)
    {
        
        rb2d.velocity = dir*speed;
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
