using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartLevel : MonoBehaviour
{
    [SerializeField]
    KeyCode keyRestart;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyRestart))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        if (collision.gameObject.name == "End" && activeSceneName != "Level 1")
        {
            Debug.Log("activeSceneName");
            SceneManager.LoadScene("Level 1");

        }
        else if (collision.gameObject.name == "End" && activeSceneName == "Level 1")
        {
            SceneManager.LoadScene("Level 0");
        }
    }
}


