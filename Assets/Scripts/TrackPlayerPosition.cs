using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayerPosition : MonoBehaviour
{
    [SerializeField]
    Transform trackPlayer;
    // Update is called once per frame
    void Update()
    {
        transform.position = trackPlayer.position;
    }
}
