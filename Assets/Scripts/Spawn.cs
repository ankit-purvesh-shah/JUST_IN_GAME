using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    float fTimeIntervals;

    [SerializeField]
    GameObject gameObjToCreate;

    [SerializeField]
    Vector3 v3SpawnPositionJitter;

    [SerializeField]
    GameObject player;

    [SerializeField]
    int enemyCount = 10; 

    float fTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        fTimer = fTimeIntervals;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   

        fTimer -= Time.deltaTime;
        if(fTimer <= 0)
        {
            float xdif = player.transform.position.x - transform.position.x;
            xdif = xdif < 0 ? xdif * -1 : xdif;

            float zdif = player.transform.position.z - transform.position.z;
            zdif = zdif < 0 ? zdif * -1 : zdif;

            //Debug.Log(player.transform.position.magnitude - transform.position.magnitude);
            if ((xdif < 1f && xdif > 0.1f) && (zdif <1f && zdif > 0.1f) && enemyCount > 0)
            {
                fTimer = fTimeIntervals;
                Vector3 v3SpawnPos = transform.position;
                Vector3 newEnemy = new Vector3(0.25f, 0, 0);
                //v3SpawnPos += Vector3.right * v3SpawnPositionJitter.x * (Random.value - 0.5f);
                //v3SpawnPos += Vector3.up * v3SpawnPositionJitter.y * (Random.value - 0.5f);
                //v3SpawnPos += Vector3.forward * v3SpawnPositionJitter.z * (Random.value - 0.5f);
                Instantiate(gameObjToCreate, v3SpawnPos, Quaternion.identity);
                Instantiate(gameObjToCreate, v3SpawnPos + newEnemy, Quaternion.identity);
                enemyCount -= 2;
                Debug.Log("Enemy created");
            }
            

        }
    }
}
