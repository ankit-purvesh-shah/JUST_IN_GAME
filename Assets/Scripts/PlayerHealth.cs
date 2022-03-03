using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    //[SerializeField]
    float multiplicationFactor = 3;

    public int maxhealth = 1000;
    public int currenthealth;
    public HealthBarScript healthBar;

    private bool collided = false;
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

    void TakeDamage(int damage)
    {
        currenthealth -= damage;
        healthBar.SetHealth(currenthealth);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("In Update");
        //Debug.Log(playerObject.GetComponent<Collider>().tag);
        if (collided)
        {
            //Debug.Log(playerHealth.currenthealth);
            //Debug.Log(Time.deltaTime);
            Debug.Log(currenthealth);
            float enemyMass = playerObject.GetComponent<Rigidbody>().mass;
            TakeDamage((int)(multiplicationFactor * enemyMass));

        }
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collided = true;
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
