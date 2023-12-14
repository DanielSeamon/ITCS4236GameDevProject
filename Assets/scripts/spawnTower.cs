using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class spawnTower : MonoBehaviour
{

    public Vector3 worldPosition;
    Plane plane = new Plane(Vector3.up, 0);
    public GameObject Tower1;

    public LayerMask unwalkable;
    private float nodeR = 0.5f;

    public static int score;
    [SerializeField] TextMeshProUGUI scoreObj;
    [SerializeField] TextMeshProUGUI healthObj;
    string scoreText;
    string healthText;
    // Start is called before the first frame update
    void Start()
    {
        score = 500;
        scoreText = scoreObj.GetComponent<TextMeshProUGUI>().text;
        healthText = healthObj.GetComponent<TextMeshProUGUI>().text;
    }

    // Update is called once per frame
    void Update()
    {
        //Text objects
        scoreObj.GetComponent<TextMeshProUGUI>().text = scoreText + score;
        healthObj.GetComponent<TextMeshProUGUI>().text = healthText + castleScript.castleHealth;

        //placing towers
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
        }

        if (Input.GetMouseButtonDown(1) && score >= 100)
        {
            if (!(Physics.CheckSphere(worldPosition, nodeR, unwalkable)))
            {
                Debug.Log(worldPosition);
                Instantiate(Tower1, worldPosition, Quaternion.identity);
                score -= 100;
            }
            else
            {
                Debug.Log("Cant place a tower there");
            }
        }
        //Debug.Log(score);

    }
}
