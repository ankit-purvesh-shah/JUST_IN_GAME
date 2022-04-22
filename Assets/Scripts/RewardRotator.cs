using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardRotator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 180, 0) * Time.deltaTime);
    }
}
