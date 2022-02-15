using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}
