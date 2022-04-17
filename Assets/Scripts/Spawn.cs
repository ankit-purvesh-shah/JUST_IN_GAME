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
    GameObject portalGameObject;

    [SerializeField]
    float minValue;

    [SerializeField]
    float maxValue;

    [SerializeField]
    Vector3 v3SpawnPositionJitter;

    [SerializeField]
    Vector3 RandomnessJitter;

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
        //Random rand = new System.Random();
        float res;
        if (fTimer <= 0)
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
                Vector3 newEnemy1 = new Vector3(0, 0, 0);
                Vector3 newEnemy2 = new Vector3(0, 0, 0);
                //v3SpawnPos += Vector3.right * v3SpawnPositionJitter.x * (Random.value - 0.5f);
                //v3SpawnPos += Vector3.up * v3SpawnPositionJitter.y * (Random.value - 0.5f);
                //v3SpawnPos += Vector3.forward * v3SpawnPositionJitter.z * (Random.value - 0.5f);

                if (RandomnessJitter.x != 0.0f)
                {
                    res = UnityEngine.Random.Range(minValue, (maxValue - minValue)/2.0f);
                    //Debug.Log(res);
                    newEnemy1.x = res;
                    res = UnityEngine.Random.Range(minValue, (maxValue - minValue) / 2.0f);
                    newEnemy2.x = res;
                }
                else if (RandomnessJitter.z != 0.0f)
                {
                    res = UnityEngine.Random.Range(minValue, maxValue);
                    Debug.Log(res);
                    newEnemy1.z = res;
                    res = UnityEngine.Random.Range(minValue, maxValue);
                    newEnemy2.z = res;
                }
                
                GameObject portal1 =  Instantiate(portalGameObject, v3SpawnPos + newEnemy1, Quaternion.identity);
                portal1.transform.rotation = Quaternion.Euler(90, 0, 0);
                //portalGameObject.Transform.Rotation();
                StartCoroutine(AddDelay(0.6f));
                Instantiate(gameObjToCreate, v3SpawnPos + newEnemy1, Quaternion.identity);
                GameObject portal2 = Instantiate(portalGameObject, v3SpawnPos + newEnemy1, Quaternion.identity);
                portal2.transform.rotation = Quaternion.Euler(90, 0, 0);
                StartCoroutine(AddDelay(0.6f));
                Instantiate(gameObjToCreate, v3SpawnPos + newEnemy2, Quaternion.identity);
                enemyCount -= 2;
                Debug.Log("Enemy created");
            }
            

        }
    }
    IEnumerator AddDelay(float time)
    {
        yield return new WaitForSeconds(time);
        //Destroy(gameObject);
    }
}
