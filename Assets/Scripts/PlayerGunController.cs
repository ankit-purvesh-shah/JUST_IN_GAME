using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunController : MonoBehaviour
{
    public GunController theGun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right"))
        {
            theGun.isFiringFront = true;
        }
        if (Input.GetKeyUp("right"))
        {
            theGun.isFiringFront = false;
        }
        if (Input.GetKeyDown("left"))
        {
            theGun.isFiringBack = true;
        }
        if (Input.GetKeyUp("left"))
        {
            theGun.isFiringBack = false;
        }
        if (Input.GetKeyDown("up"))
        {
            theGun.isFiringDown = true;
        }
        if (Input.GetKeyUp("up"))
        {
            theGun.isFiringDown = false;
        }
        if (Input.GetKeyDown("down"))
        {
            theGun.isFiringUp = true;
        }
        if (Input.GetKeyUp("down"))
        {
            theGun.isFiringUp = false;
        }

    }
}
