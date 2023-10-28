using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castleScript : MonoBehaviour
{

    private int castleHealth;
    // Start is called before the first frame update
    void Start()
    {
        castleHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(castleHealth == 0){
            Debug.Log("Game Over!");
        }
    }

    void OnCollisionEnter(Collision collision){
        //Debug.Log(collision.gameObject);
        Destroy(collision.gameObject);
        castleHealth -= 50;

    }
}
