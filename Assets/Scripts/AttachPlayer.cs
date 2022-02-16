using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttachPlayer : MonoBehaviour
{
    public GameObject Player;
    
    private void OnTriggerEnter(Collider other)
    {
            // Player.transform.Translate(0.1152f,0.1152f,0.1152f);
            Player.transform.parent=transform;  
        
    }
    private void OnTriggerExit(Collider other)
    {
       
            Player.transform.parent=null;;
    }
}
    