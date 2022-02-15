using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayerControlledVelocity : MonoBehaviour
{
    [SerializeField]
    KeyCode keyPositive;

    [SerializeField]
    KeyCode keyNegative;

    [SerializeField]
    Vector3 v3Force;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(keyPositive))
        {
            GetComponent<Rigidbody>().velocity += v3Force;
        }

        if (Input.GetKey(keyNegative))
        {
            GetComponent<Rigidbody>().velocity -= v3Force;
        }
    }
}
