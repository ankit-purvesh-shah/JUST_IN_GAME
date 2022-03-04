using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxhealth;
        healthBar.SetMaxHealth(maxhealth);
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
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collided = false;
        }
    }
}
