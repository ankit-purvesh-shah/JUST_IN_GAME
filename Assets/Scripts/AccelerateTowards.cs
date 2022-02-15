using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerateTowards : MonoBehaviour
{
    [SerializeField]
    Rigidbody rigidBody;

    Transform transformTowards;

    [SerializeField]
    float fSpeed;

    [SerializeField]
    string followObjectTag; 

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        if (transformTowards == null)
        {
            transformTowards = GameObject.FindWithTag(followObjectTag).transform;

        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocityTowardsTarget = (transformTowards.position - transform.position).normalized;
        rigidBody.velocity += velocityTowardsTarget * fSpeed * Time.deltaTime;

    }
}
