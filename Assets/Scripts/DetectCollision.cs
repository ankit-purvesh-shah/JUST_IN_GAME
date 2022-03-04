using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectCollision : MonoBehaviour
{

    [SerializeField]
    float multiplicationFactor =2;

    PlayerHealth playerHealth;
    GameObject playerObject;

    private bool collided = false;
    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (playerHealth.currenthealth <= 0)
        {
            restartLevel();
        }
    }

    private void OnCollisionEnter(Collision col)
    {

        if (playerHealth.currenthealth <= 0)
        {
            restartLevel();
        }
        if (col.gameObject.name == "End")
        {
            nextLevel();
        }

        if (col.gameObject.name == "Disapperaring Cube")
        {
            Debug.Log("Collision Detected");
            col.gameObject.GetComponent<Renderer>().material.color = Color.red;
            Destroy(col.gameObject, 2);
        }

    }



    private void nextLevel()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        if (activeSceneName == "Level 0")
        {
            Debug.Log("activeSceneName");
            SceneManager.LoadScene("Level 1");

        }
        if (activeSceneName == "Level 1")
        {
            SceneManager.LoadScene("Level 2");
        }
        if ( activeSceneName == "Level 2")
        {
            SceneManager.LoadScene("Level 3");
        }
        if (activeSceneName == "Level 3")
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
    private void restartLevel()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeSceneName);
    }



}
