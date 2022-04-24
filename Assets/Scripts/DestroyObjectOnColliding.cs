using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class DestroyObjectOnColliding : MonoBehaviour
{
    [SerializeField]
    bool destroySelf;

    [SerializeField]
    bool destroyOther;

    [SerializeField]
    string objectTag;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == objectTag)
        {
            if (destroySelf)
            {
                Destroy(this.gameObject);
            }

            if (destroyOther)
            {
                Destroy(collision.gameObject);
            }
        }

        else if (collision.collider.tag == "Player")
        {
            /*string activeSceneName = SceneManager.GetActiveScene().name;
            AnalyticsResult analyticsResult = Analytics.CustomEvent(
                "Death_By_Fall",
                new Dictionary<string, object>
                {
                    { "Level", activeSceneName}
                }
            );
            Debug.Log("analyticsResults Death_By_Fall -> " + analyticsResult);
            Debug.Log("analyticsResults Death_By_Fall -> " + activeSceneName);*/

            //FindObjectOfType<AudioManager>().Play("Player Death");
            //Destroy(collision.collider);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}
