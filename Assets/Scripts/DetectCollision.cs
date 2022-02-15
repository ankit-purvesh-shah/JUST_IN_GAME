using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectCollision : MonoBehaviour
{
   
    private void OnCollisionEnter(Collision col)
    {
        Debug.Log("testing");

        string activeSceneName = SceneManager.GetActiveScene().name;
        if (col.gameObject.name == "End" && activeSceneName != "Level 1")
        {
            Debug.Log("activeSceneName");
            SceneManager.LoadScene("Level 1");

        }
        else if (col.gameObject.name == "End" && activeSceneName == "Level 1")
        {
            SceneManager.LoadScene("Level 0");
        }

        if (col.gameObject.name=="Disapperaring Cube")
        {
            Debug.Log("Collision Detected");
            Destroy (col.gameObject,3);
        }
    }

}
