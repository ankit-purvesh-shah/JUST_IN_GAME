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

    private AddPlayerControlledVelocity addPlayerControlledVelocity;

    // Start is called before the first frame update
    void Start()
    {
        addPlayerControlledVelocity = gameObject.GetComponent<AddPlayerControlledVelocity>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFiringBack && addPlayerControlledVelocity.onPlatform)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                FindObjectOfType<AudioManager>().Play("Player Shooting");
                BulletController newBullet = Instantiate(bullet, firePointFront.position, firePointFront.rotation) as BulletController ;
                newBullet.shootingSpeed = bulletSpeed;
            }
        }

        if (isFiringFront && addPlayerControlledVelocity.onPlatform)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                FindObjectOfType<AudioManager>().Play("Player Shooting");
                BulletControllerBack newBullet = Instantiate(bulletBack, firePointBack.position, firePointBack.rotation) as BulletControllerBack;
                newBullet.shootingSpeed = bulletSpeed;
            }
        }

        if (isFiringUp && addPlayerControlledVelocity.onPlatform)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                FindObjectOfType<AudioManager>().Play("Player Shooting");
                BulletControllerUp newBullet = Instantiate(bulletUp, firePointUp.position, firePointUp.rotation) as BulletControllerUp;
                newBullet.shootingSpeed = bulletSpeed;
            }
        }

        if (isFiringDown && addPlayerControlledVelocity.onPlatform)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                FindObjectOfType<AudioManager>().Play("Player Shooting");
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
