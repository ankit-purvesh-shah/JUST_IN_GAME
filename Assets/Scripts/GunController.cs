using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public bool isFiringFront;
    public bool isFiringBack;
    public bool isFiringUp;
    public bool isFiringDown;
    public BulletController bullet;
    public BulletControllerBack bulletBack;
    public BulletControllerUp bulletUp;
    public BulletControllerDown bulletDown;
    public float bulletSpeed;
    public float timeBetweenShots;
    private float shotCounter;
    public Transform firePointFront;
    public Transform firePointBack;
    public Transform firePointUp;
    public Transform firePointDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isFiringBack)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                BulletController newBullet = Instantiate(bullet, firePointFront.position, firePointFront.rotation) as BulletController ;
                newBullet.shootingSpeed = bulletSpeed;
            }
        }

        if (isFiringFront)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                BulletControllerBack newBullet = Instantiate(bulletBack, firePointBack.position, firePointBack.rotation) as BulletControllerBack;
                newBullet.shootingSpeed = bulletSpeed;
            }
        }

        if (isFiringUp)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                BulletControllerUp newBullet = Instantiate(bulletUp, firePointUp.position, firePointUp.rotation) as BulletControllerUp;
                newBullet.shootingSpeed = bulletSpeed;
            }
        }

        if (isFiringDown)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                BulletControllerDown newBullet = Instantiate(bulletDown, firePointDown.position, firePointDown.rotation) as BulletControllerDown;
                newBullet.shootingSpeed = bulletSpeed;
            }
        }
        //else
        //{
        //    shotCounter = 0;
        //}
    }
}
