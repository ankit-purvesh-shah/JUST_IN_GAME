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


    //private void FixedUpdate()
    //{
    //    Debug.Log("In Update");
    //    //Debug.Log(playerObject.GetComponent<Collider>().tag);
    //    if (collided)
    //    {
    //        Debug.Log(playerHealth.currenthealth);
    //        //Debug.Log(Time.deltaTime);
    //        float enemyMass = playerObject.GetComponent<Rigidbody>().mass;
    //        playerHealth.currenthealth -= (int)(multiplicationFactor * enemyMass);

    //    }
    //    if (playerHealth.currenthealth <= 0)
    //    {
    //        restartLevel();
    //    }
    //}
    private void Update()
    {
        if (playerHealth.currenthealth <= 0)
        {
            restartLevel();
        }
    }

    private void OnCollisionEnter(Collision col)
    {

        //string activeSceneName = SceneManager.GetActiveScene().name;
        //if (col.gameObject.name == "End" && activeSceneName == "Level 0")
        //{
        //    Debug.Log("activeSceneName");
        //    SceneManager.LoadScene("Level 1");

        //}
        //if (col.gameObject.name == "End" && activeSceneName == "Level 1")
        //{
        //    SceneManager.LoadScene("Level 2");
        //}
        //if (col.gameObject.name == "End" && activeSceneName == "Level 2")
        //{
        //    SceneManager.LoadScene("Level 3");
        //}
        //if (col.gameObject.name == "End" && activeSceneName == "Level 3")
        //{
        //    SceneManager.LoadScene("Level 0");
        //}

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

        //if (col.gameObject.tag == "Enemy")
        //{
        //    collided = true;
        //}
    }


    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        collided = false;
    //    }
    //}

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
            SceneManager.LoadScene("Level 0");
        }
    }
    private void restartLevel()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeSceneName);
    }



}
