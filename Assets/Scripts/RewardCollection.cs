using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RewardCollection : MonoBehaviour
{
    // Start is called before the first frame update


    public TextMeshProUGUI countText;
    private int count;

    void Start()
    {
        count = 0;
        SetCountText();
    }



    // Update is called once per frame
    void Update()
    {
        
    }


    // Rewards

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Reward"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
}
