using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    private int timerStatus = 0;
    private int spawnTimer = 2;
    public GameObject enemy1Prefab;
    private Vector3 coordinates;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timerStatus == 0)
        {
            Debug.Log("Start Timer");
            StartCoroutine(waitForSpawn());
        }

    }

    IEnumerator waitForSpawn()
    {
        timerStatus++;
        yield return new WaitForSeconds(spawnTimer);
        coordinates = new Vector3(Random.Range(-20.0f, 20.0f), 0, 21.0f);
        Instantiate(enemy1Prefab, coordinates, Quaternion.identity);
        Debug.Log("Spawn");
        timerStatus--;
    }
}
