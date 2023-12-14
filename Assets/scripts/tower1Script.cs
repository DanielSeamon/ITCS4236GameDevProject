using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower1Script : MonoBehaviour
{
    bool canSwing = true;
    int swingTimer = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log(collider.gameObject);
        if (canSwing)
        {
            Destroy(collider.gameObject);
            spawnTower.score += 50;
            StartCoroutine(waitForSwing());
        }

    }

    IEnumerator waitForSwing()
    {
        canSwing = false;
        yield return new WaitForSeconds(swingTimer);
        canSwing = true;
    }
}
