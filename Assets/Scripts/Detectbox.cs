using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detectbox : MonoBehaviour {

    //Movement
    public float horSpeed;
    public float verSpeed;
    public float range;
    private Vector2 CurPosition;
    private int numRound;
    private bool rotateMove;
    private bool waitSec;

    // Use this for initialization
    void Start () {
        CurPosition = transform.position;

        horSpeed = 4;
        verSpeed = 3;
        range = 3;
        numRound = 0;
        waitSec = true;
        rotateMove = true;
    }
	
	// Update is called once per frame
	void Update () {

        Controll();
    }

    void Controll()
    {

        if (waitSec)
        {

            //Move();
            CurPosition.x += horSpeed * Time.deltaTime;
            CurPosition.y = Mathf.Sin(Time.realtimeSinceStartup * verSpeed) * range;
            transform.position = CurPosition;
        }
        else if (!waitSec)
        {

            //MoveOp();
        }
    }


    /*void Move()
    {
        if (CurPosition.y <= 0)
        {
            if (!check)
            {

                numRound++;
                check = true;
            }
            if (numRound % 4 == 2)
            {
                CurPosition.x -= horSpeed * Time.deltaTime;
            }
            else if (numRound % 4 == 0)
            {
                CurPosition.x += horSpeed * Time.deltaTime;
            }
        }
        else if (CurPosition.y > 0)
        {
            if (check)
            {

                numRound++;
                check = false;
            }
            if (numRound % 4 == 1)
            {
                CurPosition.x += horSpeed * Time.deltaTime;
            }
            else if (numRound % 4 == 3)
            {
                CurPosition.x -= horSpeed * Time.deltaTime;
            }
        }
        CurPosition.y = Mathf.Sin(Time.realtimeSinceStartup * verSpeed) * range;
        transform.position = CurPosition;
    }
    void MoveOp()
    {
        if (CurPosition.y <= 0)
        {
            if (!check)
            {

                numRound++;
                check = true;
            }
            if (numRound % 4 == 2)
            {
                CurPosition.x += horSpeed * Time.deltaTime;
            }
            else if (numRound % 4 == 0)
            {
                CurPosition.x -= horSpeed * Time.deltaTime;
            }
        }
        else if (CurPosition.y > 0)
        {
            if (check)
            {

                numRound++;
                check = false;
            }
            if (numRound % 4 == 1)
            {
                CurPosition.x -= horSpeed * Time.deltaTime;
            }
            else if (numRound % 4 == 3)
            {
                CurPosition.x += horSpeed * Time.deltaTime;
            }
        }
        CurPosition.y = Mathf.Sin(Time.realtimeSinceStartup * verSpeed) * range;
        transform.position = CurPosition;
    }
    */

    
   /*void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("wall"))
        {
            waitSec = false;
            StartCoroutine(StopforASec());
            
        }
        Debug.Log("None detect box");
    }

    IEnumerable StopforASec()
    {
        yield return new WaitForSeconds(5);
        waitSec = true;

    }
    */
}
