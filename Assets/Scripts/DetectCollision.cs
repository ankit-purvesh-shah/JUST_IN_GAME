using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using DG.Tweening;
public class DetectCollision : MonoBehaviour
{
    // [SerializeField]
    // private Texture[] textures;
    public Texture d3;
    
    [SerializeField]
    float multiplicationFactor =2;
    public Material nmaterial;
    PlayerHealth playerHealth;
    GameObject playerObject;

    private bool collided = false;

    private bool OnPlatform;
    private bool OnDisappearingPlatform;
    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (playerHealth.currenthealth <= 0)
        {
            string activeSceneName = SceneManager.GetActiveScene().name;
            AnalyticsResult analyticsResult = Analytics.CustomEvent(
                "Death_By_Health",
                new Dictionary<string, object>
                {
                    { "Level", activeSceneName}
                }
            );
            Debug.Log("analyticsResults Death_By_Health -> " + analyticsResult);
            Debug.Log("analyticsResults Death_By_Health -> " + activeSceneName);
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
            Debug.Log("TIME ->" + Time.timeSinceLevelLoad);
            string activeSceneName = SceneManager.GetActiveScene().name;
            AnalyticsResult analyticsResult = Analytics.CustomEvent(
                "Level_Completion_Time",
                new Dictionary<string, object>
                {
                    { "Level", activeSceneName},
                    { "Time", Time.timeSinceLevelLoad}
                }
            ); 
            Debug.Log("analyticsResults Level_Completion_Time -> " + analyticsResult);
            Debug.Log("analyticsResults Level_Completion_Time -> " + activeSceneName);
            Debug.Log("analyticsResults Level_Completion_Time -> " + Time.timeSinceLevelLoad);
            nextLevel();
        }

        if (col.gameObject.name == "Disapperaring Cube")
        {
            Debug.Log("Collision Detected for disappearing");
            string activeSceneName = SceneManager.GetActiveScene().name;
            AnalyticsResult analyticsResult = Analytics.CustomEvent(
                "Disappearing_tile_touched",
                new Dictionary<string, object>
                {
                    { "Level", activeSceneName}
                }
                );
            Debug.Log("analyticsResults Disappearing_tile_touched -> " + analyticsResult);
            Debug.Log("analyticsResults Disappearing_tile_touched -> " + activeSceneName);
            col.gameObject.GetComponent<Renderer>().material.color = Color.red;
            Debug.Log(col.gameObject);

            // col.gameObject.GetComponent<Animator>().SetBool("isCollided",true); 

            
            // col.gameObject.GetComponent<Renderer>().material.mainTexture = d3;
            // // col.gameObject.GetComponent<Renderer>().material.color = Color.red;
            // // StartCoroutine(changeColorYellow(col));
            // // StartCoroutine(changeColorRed(col));
            // //  col.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            // Debug.Log("Colllllll");
            // Debug.Log(col.gameObject.name);
            // yield return new WaitForSeconds(1);
            // Debug.Log("afrer");
            // Debug.Log(col.gameObject.name);
            // col.gameObject.GetComponent<Renderer>().material.color = Color.red;

            Destroy(col.gameObject, 3);

        }

        if (col.gameObject.tag == "Platform")
        {
            if (col.gameObject.name == "Disapperaring Cube")
            {
                OnDisappearingPlatform = true;
                OnPlatform = false;
                //Debug.Log("collision detected with ->" + col.gameObject.name);
            }
            else
            {
                OnDisappearingPlatform = false;
                OnPlatform = true;
                //Debug.Log("collision detected with ->" + col.gameObject.name);
            }
            
        }

        if(col.gameObject.name == "Lava")
        {
            string activeSceneName = SceneManager.GetActiveScene().name;
            if (OnDisappearingPlatform)
            {
                AnalyticsResult analyticsResult = Analytics.CustomEvent(
                "Death_By_Tile",
                new Dictionary<string, object>
                {
                    { "Level", activeSceneName}
                }
                );
                Debug.Log("analyticsResults Death_By_Tile -> " + analyticsResult);
                Debug.Log("analyticsResults Death_By_Tile -> " + activeSceneName);
            }

            if (OnPlatform)
            {
                AnalyticsResult analyticsResult = Analytics.CustomEvent(
                "Death_By_Fall",
                new Dictionary<string, object>
                {
                    { "Level", activeSceneName}
                }
                );
                Debug.Log("analyticsResults Death_By_Fall -> " + analyticsResult);
                Debug.Log("analyticsResults Death_By_Fall -> " + activeSceneName);
            }
            restartLevel();

        }
    }

    
    // public IEnumerator changeColorRed(Collision col){
    //     Debug.Log(col.gameObject.name);
    //     if (col.gameObject.name == "Disapperaring Cube")
    //     {
    //         Debug.Log("Red");
    //     yield return new WaitForSeconds(2);
    //     col.gameObject.GetComponent<Renderer>().material.color = Color.red;
    //     }

       
    // }



    private void nextLevel()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        
        AnalyticsResult analyticsResult = Analytics.CustomEvent(
               "Level_Completed",
               new Dictionary<string, object>
               {
                    { "Level", activeSceneName}
               }
           );
        Debug.Log("analyticsResults Level_Completed -> " + analyticsResult);
        Debug.Log("analyticsResults Level_Completed -> " + activeSceneName);

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
        AnalyticsResult analyticsResult = Analytics.CustomEvent(
               "Level_Attempts",
               new Dictionary<string, object>
               {
                    { "Level", activeSceneName}
               }
           );
        Debug.Log("analyticsResults Level_Attempts -> " + analyticsResult);
        Debug.Log("analyticsResults Level_Attempts -> " + activeSceneName);
        SceneManager.LoadScene(activeSceneName);
    }



}
