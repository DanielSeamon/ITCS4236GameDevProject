using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class castleScript : MonoBehaviour
{

    public static int castleHealth;
    // Start is called before the first frame update
    void Start()
    {
        castleHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (castleHealth == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject);
        Destroy(collision.gameObject);
        castleHealth -= 10;

    }
}
