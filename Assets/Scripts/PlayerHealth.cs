using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerHealth : MonoBehaviour
{

    //[SerializeField]
    float multiplicationFactor = 3;

    public float maxhealth = 1000;
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
        currenthealth = maxhealth;
        healthBar.SetMaxHealth(maxhealth);
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
        currenthealth -= damage;
        healthBar.SetHealth(currenthealth);
    }


    void HealHealth(float healXP)
    {
        Debug.Log(currenthealth);
        currenthealth += healXP;
        Debug.Log(currenthealth);
        healthBar.SetHealth(currenthealth);
    }

    // Update is called once per frame
    void FixedUpdate()
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
        if (collision.gameObject.CompareTag("Reward"))
        {
            collision.gameObject.SetActive(false);
            HealHealth(healFactor);
            count = count + 1;
            SetCountText();
        }
    }
}
