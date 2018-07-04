using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacktoBackBullet : MonoBehaviour {
    
    
    private float speed = 2;
    private Transform player;
    private Vector3 target;
    private bool secondMove;
    private bool lastMove;

    Rigidbody2D rb2d;
    private Vector3 Dir;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        rb2d = GetComponent<Rigidbody2D>();
        secondMove = true;
        lastMove = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        if(secondMove && (transform.position != target))
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            Debug.Log("now" + transform.position);
            Debug.Log("targettttttttttttttt" + target);
            Debug.Log("check1111111111111111111111111111111111" + secondMove);
        }
        
        
        else if((transform.position == target) && secondMove)
        {
            Debug.Log("check2" + secondMove);
            Dir = Vector3.Normalize(player.position - this.transform.position) * speed * Time.deltaTime;
            Debug.Log("2222222222222222222222");
            StepTwo();
        }

        else if (lastMove)
        {
            Debug.Log("333333333333333333333333");
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            rb2d.velocity = new Vector2(Dir.x, Dir.y);
        }

    }

    void StepTwo()
    {
        
        //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        
        //dir = Vector3.Normalize(player.position - this.transform.position);

        secondMove = false;
        lastMove = true;
    }
}
