using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddPlayerControlledVelocity : MonoBehaviour
{
    [SerializeField]
    KeyCode keyPositive;

    [SerializeField]
    KeyCode keyNegative;
    
    [SerializeField]
    Vector3 v3Force;
    public TextMeshProUGUI countText;
    private int count;

    void Start()
    {
        count = 0;
        SetCountText();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(keyPositive))
        {
            GetComponent<Rigidbody>().velocity += v3Force;
        }

        if (Input.GetKey(keyNegative))
        {
            GetComponent<Rigidbody>().velocity -= v3Force;
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Reward"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
}
