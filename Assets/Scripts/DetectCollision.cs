using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectCollision : MonoBehaviour
{
   
    private void OnCollisionEnter(Collision col)
    {

        string activeSceneName = SceneManager.GetActiveScene().name;
        if (col.gameObject.name == "End" && activeSceneName == "Level 0")
        {
            Debug.Log("activeSceneName");
            SceneManager.LoadScene("Level 1");

        }
        if (col.gameObject.name == "End" && activeSceneName == "Level 1")
        {
            SceneManager.LoadScene("Level 2");
        }
        if (col.gameObject.name == "End" && activeSceneName == "Level 2")
        {
            SceneManager.LoadScene("Level 3");
        }
        if (col.gameObject.name == "End" && activeSceneName == "Level 3")
        {
            SceneManager.LoadScene("Level 0");
        }

        if (col.gameObject.name == "Disapperaring Cube")
        {
            Debug.Log("Collision Detected");
            col.gameObject.GetComponent<Renderer>().material.color = Color.red;
            Destroy(col.gameObject, 2);
        }
    }

}
