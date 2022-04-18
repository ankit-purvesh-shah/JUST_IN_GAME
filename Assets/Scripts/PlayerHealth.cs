using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;


public class PlayerHealth : MonoBehaviour
{

    //[SerializeField]
    float multiplicationFactor = 3;

    public readonly float maxhealth = 1000;
    public float currenthealth;
    public HealthBarScript healthBar;

    private bool collided = false;
    private float enemyMass = 0;
    PlayerHealth playerHealth;
    GameObject playerObject;


    // Rewards Health Heal
    private bool rewardsCollected = false;
    private readonly float healFactor=150.0F;
    public TextMeshProUGUI countText;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        this.currenthealth = this.maxhealth;
        healthBar.SetMaxHealth(this.maxhealth);
        count = 0;
        SetCountText();
    }
    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    void TakeDamage(float damage)
    {
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
        
        if (collided && enemyMass != 0)
        {
            
            TakeDamage((multiplicationFactor * enemyMass));

        }
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
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
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
