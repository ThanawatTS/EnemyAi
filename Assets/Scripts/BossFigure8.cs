using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFigure8 : MonoBehaviour {
    [SerializeField]
    private float speedFlying;
    [SerializeField]
    private float radius;
    private float teta;
    [SerializeField]
    private float reloadShot;
    [SerializeField]
    private float startShot;

    //Many-Projectile
    private int numOfProjectile;
    private float rangeOfProjectile;
    private float speedbullet;

    



    public GameObject bullet3Pro;
    public GameObject bullet;
    public GameObject bulletFollow;
    private Vector2 offset;
    private Vector2 center;
    private Vector2 dir;
    private Transform player;
	// Use this for initialization
	void Start () {
        center = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
	}
	
	// Update is called once per frame
	void Update () {
        teta += speedFlying * Time.deltaTime;
        Movement(teta);
       
        EnemyShot();
	}

    void Movement(float _teta)
    {
        offset = new Vector2(radius*(speedFlying * Mathf.Sqrt(2) * Mathf.Cos(_teta)) / (0.5f * (1 - Mathf.Cos(2 * _teta)) + 1), (speedFlying * Mathf.Sqrt(2) * Mathf.Cos(_teta) * Mathf.Sin(_teta)) / (0.5f * (1 - Mathf.Cos(2 * _teta)) + 1));
        transform.position = center + offset;
    }
    
    //3Projectile----
    void FireThreeProjectile()
    {
        numOfProjectile = 3;
        rangeOfProjectile = 5;
        speedbullet = 3;

        SetProjectile(numOfProjectile, rangeOfProjectile, speedbullet);
    }
    
    //8Projectile
    void FireEightProjectile()
    {
        numOfProjectile = 8;
        rangeOfProjectile = 30;
        speedbullet = 3;

        SetProjectile(numOfProjectile, rangeOfProjectile, speedbullet);
    }

    //Manyprojectile
    void SetProjectile(int numOfP, float range, float speedBullet)
    {
        float angleTotal = 360f / numOfP;
        float angle = 0f;

        for (int i = 0; i <= numOfP - 1; i++)
        {
            float projectileX = player.transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * range;
            float projectileY = player.transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * range;

            Vector3 projectileVec = new Vector3(projectileX, projectileY, 0);
            Vector3 projectileDir = Vector3.Normalize(projectileVec - this.transform.position) * speedBullet;

            var proj = Instantiate(bullet3Pro, this.transform.position, Quaternion.identity);
            proj.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileDir.x, projectileDir.y);

            angle += angleTotal;

        }
    }


    void EnemyShot()
    {
        if (reloadShot <= 0)
        {
            //no rotate
            var number = Random.Range(0, 4);

            if (number == 0)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
            }
            else if (number == 1)
            {
                Instantiate(bulletFollow, transform.position, Quaternion.identity);
            }
            else if (number == 2)
            {
                FireThreeProjectile();
            }
            else if (number == 3)
            {
                FireEightProjectile();
            }

            reloadShot = startShot;
        }
        else
        {
            reloadShot -= Time.deltaTime;
        }

    }

}
