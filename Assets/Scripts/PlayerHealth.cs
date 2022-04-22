using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{

    //[SerializeField]
    float multiplicationFactor = 3;
    //[SerializeField]
    //public Texture2D textureImage;
    public readonly float maxhealth = 1000;
    public float currenthealth;
    public HealthBarScript healthBar;

    private bool collided = false;
    private float enemyMass = 0;
    PlayerHealth playerHealth;
    GameObject playerObject;
    //public GameObject TakingDamageScreen;

    // Rewards Health Heal
    private bool rewardsCollected = false;
    private readonly float healFactor=150.0F;

    // Start is called before the first frame update
    void Start()
    {
        this.currenthealth = this.maxhealth;
        healthBar.SetMaxHealth(this.maxhealth);

    }
    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    void TakeDamage(float damage)
    {
       // TakingDamageScreen.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(Screen.width,Screen.height);
        //TakingDamageScreen.GetComponent<Image>().width = Screen.width;
       // var color = TakingDamageScreen.GetComponent<Image>().color;
       // color.a = 1f;
        //TakingDamageScreen.GetComponent<Image>().color = color;

        this.currenthealth -= damage;
        healthBar.SetHealth(this.currenthealth);
        Debug.Log("Taking Damage: "+this.currenthealth);
    }


    void HealHealth(float healXP)
    {
        Debug.Log(this.currenthealth);
        this.currenthealth = Mathf.Min(this.currenthealth + healXP,this.maxhealth);
        Debug.Log("Reward Picked up. Current Health: "+ this.currenthealth);
        
        healthBar.SetHealth(this.currenthealth);
    }

    // Update is called once per frame
    void Update()
    {
        
        
       
    }
    

    void OnCollisionStay(Collision collision)
    {


        //
        if (collision.gameObject.tag == "Enemy")
        {
            
            TakeDamage(multiplicationFactor * enemyMass);
        }
       // if (TakingDamageScreen.GetComponent<Image>().color.a > 0)
      //  {
      //      var color = TakingDamageScreen.GetComponent<Image>().color;
      //      color.a -= 0.05f;
     //       TakingDamageScreen.GetComponent<Image>().color = color;
       // }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collided = true;
            enemyMass = collision.rigidbody.mass;
            
            string activeSceneName = SceneManager.GetActiveScene().name;
            AnalyticsResult analyticsResult = Analytics.CustomEvent(
                "Enemy_collided",
                new Dictionary<string, object>
                {
                    { "Level", activeSceneName},
                    { "Enemy_type", collision.gameObject.name}
                }
            );
            //GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), textureImage);
            Debug.Log("analyticsResults Enemy_collided -> " + analyticsResult);
            Debug.Log("analyticsResults Enemy_collided -> " + activeSceneName);
            Debug.Log("analyticsResults Enemy_collided -> " + collision.gameObject.name);
        }
        /*if (collision.gameObject.CompareTag("Reward"))
        {
            string activeSceneName = SceneManager.GetActiveScene().name;
            AnalyticsResult analyticsResult = Analytics.CustomEvent(
                "Reward_collection",
                new Dictionary<string, object>
                {
                    { "Level", activeSceneName}
                }
            );
            Debug.Log("analyticsResults Reward_collection -> " + analyticsResult);
            Debug.Log("analyticsResults Reward_collection -> " + activeSceneName);
            collision.gameObject.SetActive(false);
            HealHealth(healFactor);
            count = count + 1;
            SetCountText();
        }*/
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Reward"))
        {
            string activeSceneName = SceneManager.GetActiveScene().name;
            AnalyticsResult analyticsResult = Analytics.CustomEvent(
                "Reward_collection",
                new Dictionary<string, object>
                {
                    { "Level", activeSceneName}
                }
            );
            Debug.Log("analyticsResults Reward_collection -> " + analyticsResult);
            Debug.Log("analyticsResults Reward_collection -> " + activeSceneName);
            collision.gameObject.SetActive(false);
            HealHealth(healFactor);

        }
    }


    private void OnCollisionExit(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy")
        {
            collided = false;
        }
        
    }
}
