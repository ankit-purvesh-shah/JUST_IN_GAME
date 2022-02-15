using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    float fTimeIntervals;

    [SerializeField]
    GameObject gameObjToCreate;

    [SerializeField]
    Vector3 v3SpawnPositionJitter;

    float fTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        fTimer = fTimeIntervals;
    }

    // Update is called once per frame
    void Update()
    {
        fTimer -= Time.deltaTime;
        if(fTimer <= 0)
        {
            fTimer = fTimeIntervals;
            Vector3 v3SpawnPos = transform.position;
            v3SpawnPos += Vector3.right * v3SpawnPositionJitter.x * (Random.value - 0.5f);
            v3SpawnPos += Vector3.up * v3SpawnPositionJitter.y * (Random.value - 0.5f);
            v3SpawnPos += Vector3.forward * v3SpawnPositionJitter.z * (Random.value - 0.5f);
            Instantiate(gameObjToCreate, v3SpawnPos, Quaternion.identity);
        }
    }
}
